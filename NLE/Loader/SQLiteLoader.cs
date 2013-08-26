using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SQLite;

using NLE.Glossary;
using NLE.Engine;

namespace NLE.Loader
{
    public class SQLiteLoader : ILoader
    {
        private string filename;

        private SQLiteConnection link = null;

        public SQLiteLoader(string filename)
        {
            this.filename = filename;
        }

        ~SQLiteLoader()
        {
            this.deconnection();
        }

        bool ILoader.Load(Words dico)
        {
            // charger le dico à partir d'une base SQLite

            this.connection();

            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM words", this.link);
            DataSet dataset = new DataSet();

            adapter.Fill(dataset);
            DataTable table = dataset.Tables[0];
            int nbRow = table.Rows.Count;
            for (int i = 0; i < nbRow; i++)
            {
                object w = table.Rows[i].ItemArray[1];
                object t = table.Rows[i].ItemArray[2];
                object a = table.Rows[i].ItemArray[3];
                object d = table.Rows[i].ItemArray[4];

                if (w is System.DBNull) w = "";
                if (t is System.DBNull) t = "";
                if (a is System.DBNull) a = "";
                if (d is System.DBNull) d = "";

                

                Word word = this.createWord((string)w, (string)t, (string)a, (string)d);
                dico.AddWord(word);
            }

            this.deconnection();


            return true;
        }

        private Word createWord(string w, string type, string attrs, string def)
        {
            switch (type.ToLower())
            {
                case "nom":     return this.createNoun(w);
                case "verbe":   return this.createVerb(w);
                    /* ... */
                default:        return new UnknownWord(w);
            }
        }

        private Noun createNoun(string n)
        {
            return new Noun(n);
        }

        private Verb createVerb(string v)
        {
            // verbe à l'infinitif
            InfinitiveVerb verb = new InfinitiveVerb(v);

            // chargement de la table de conjugaison
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM conjugated_verbs WHERE infinitive='" + verb.word + "'", this.link);
            DataSet dataset = new DataSet();

            adapter.Fill(dataset);
            DataTable table = dataset.Tables[0];
            int nbRow = table.Rows.Count;
            for (int i = 0; i < nbRow; i++)
            {
                object t = table.Rows[i].ItemArray[2];
                object p = table.Rows[i].ItemArray[3];
                object w = table.Rows[i].ItemArray[4];

                if (t is System.DBNull) t = "";
                if (p is System.DBNull) p = "";
                if (w is System.DBNull) w = "";

                string tense = (string)t;
                string[] persons = (p as string).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                ConjugatedVerb cv = new ConjugatedVerb((string)w, tense, verb, persons);

                if (!verb.conjugationTables.ContainsKey(tense)) // on créé la table correspondante au temps
                    verb.conjugationTables[tense] = new Dictionary<string, ConjugatedVerb>();

                for (int j = 0; j < persons.Length; j++)
                {
                    verb.conjugationTables[tense][persons[j].Trim()] = cv; // ajout du verbe conjugué pour toutes les personnes correspondantes
                }
            }

            return verb;
        }


        bool ILoader.UnLoad()
        {
            return this.deconnection();
        }

        private bool createSchema()
        {
            // créer le schéma

            return false;
        }

        private bool connection()
        {
            try
            {
                if (this.link != null)
                {
                    this.deconnection();
                }

                this.link = new SQLiteConnection("Data Source=" + this.filename + ";Version=3;Compress=True;");
                this.link.Open();


                // vérifier présence du schéma
                //    si pas de schéma, appeler this.createSchema()

                return true;
            }
            catch (SQLiteException e)
            {
                // logger erreur !
                Console.WriteLine(e);

                return false;
            }
        }

        private bool deconnection()
        {
            if (this.link != null)
            {
                this.link.Close();
                this.link = null; // on supprime toute référence pour le Garbage collector
            }
            return true;
        }
    }
}
