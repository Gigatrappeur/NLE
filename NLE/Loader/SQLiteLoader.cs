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
        private SQLiteDB db = null;


        // utilisé uniquement pour le chargement !
        private Words refdico = null;


        public SQLiteLoader(string filename)
        {
            this.db = new SQLiteDB(filename);
        }

        ~SQLiteLoader()
        {
            this.db.close();
        }

        bool ILoader.Load(Words dico)
        {
            // charger le dico à partir d'une base SQLite

            this.refdico = dico;

            this.db.connect();

            // ----------------------------------------------------------------
            // --  début des chargements  -------------------------------------


            // --  chargement des tables de paramètres  -----------------------

            dico.persons = this.loadPersons();
            if (dico.persons == null)
            {
                // une erreur s'est produite lors du chargement des personnes
            }


            dico.tenses = this.loadTenses();
            if (dico.tenses == null)
            {
                // une erreur s'est produite lors du chargement des personnes
            }


            dico.language = this.loadLanguage();


            // --  chargement des mots  ---------------------------------------

            List<Dictionary<string, object>> words = this.db.select("words", new string[] { "word", "type", "attributs", "definition" });
            for (int i = 0; i < words.Count; i++)
            {
                string w = (string)words[i]["word"];
                string t = (string)words[i]["type"];
                string a = (string)words[i]["attributs"];
                string d = (string)words[i]["definition"];
                Word word = this.createWord(w, t, a, d);
                dico.AddWord(word);
            }


            // --  fin des chargements  ---------------------------------------
            // ----------------------------------------------------------------

            this.db.close();


            this.refdico = null;

            return true;
        }

        private Dictionary<int, string> loadTenses()
        {
            Dictionary<int, string> rt = new Dictionary<int, string>();
            List<Dictionary<string, object>> tenses = this.db.select("tenses", new string[] { "id", "name" });
            for (int i = 0; i < tenses.Count; i++)
            {
                int id = (int)((Int64)tenses[i]["id"]);
                string n = (string)tenses[i]["name"];

                rt[id] = n;
            }

            return rt;
        }

        private Dictionary<int, Person> loadPersons()
        {
            Dictionary<int, Person> rt = new Dictionary<int, Person>();
            List<Dictionary<string, object>> persons = this.db.select("persons", new string[] { "id", "enum", "position", "number", "personal_pronoun", "description" });
            for (int i = 0; i < persons.Count; i++)
            {
                int id = (int)((Int64)persons[i]["id"]);
                int e = (int)((decimal)persons[i]["enum"]);
                int p = (int)((decimal)persons[i]["position"]);
                string n = (string)persons[i]["number"];
                string pp = (string)persons[i]["personal_pronoun"];
                string d = (string)persons[i]["description"];

                rt[e] = new Person(id, p, n, pp, d);
            }

            return rt;
        }

        private string loadLanguage()
        {
            List<Dictionary<string, object>> parametres = this.db.select("params", new string[] { "name", "value" }, new string[] { "name='language'" });
            if (parametres.Count != 1)
                throw new Exception("language unknown");

            return (string)parametres[0]["value"];
        }

        public Word createWord(string w, string type, string attrs, string def)
        {
            string method = "create" + type.Substring(0, 1).ToUpper() + type.Substring(1).ToLower();
            var m = this.GetType().GetMethod(method);
            if (m == null)
            {
                // TODO: logger le fait que "method" n'existe pas

                return this.createUnknown(w, attrs, def);
            }
            else
            {
                try
                {
                   return (Word) m.Invoke(this, new object[] { w, attrs, def });
                }
                catch (Exception /*e*/)
                {
                    // TODO: logger exception

                    return this.createUnknown(w, attrs, def);
                }
            }

            /*
            switch (type.ToLower())
            {
                case "nom":     return this.createNoun(w, attrs, def);
                case "verbe":   return this.createVerb(w, attrs, def);
                    // ...
                default:        return new UnknownWord(w, def);
            }
            */
        }

        public Noun createNoun(string n, string attrs, string def)
        {
            return new Noun(n, attrs.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries), def);
        }

        public Verb createVerb(string v, string attrs, string def)
        {
            // verbe à l'infinitif
            InfinitiveVerb verb = new InfinitiveVerb(v, def);

            // chargement de la table de conjugaison
            List<Dictionary<string, object>> verbs = this.db.select("conjugated_verbs", new string[] { "tense", "person", "word" }, new string[] { "infinitive='" + verb.word + "'"});
            for (int i = 0; i < verbs.Count; i++)
            {
                int t = (int)((decimal)verbs[i]["tense"]);
                int p = (int)((decimal)verbs[i]["person"]);
                string w = (string)verbs[i]["word"];

                string tense = this.getTense(t);
                Person[] persons = this.getPersons(p);

                ConjugatedVerb cv = new ConjugatedVerb(w, tense, verb, persons);

                if (!verb.conjugationTables.ContainsKey(tense)) // on créé la table correspondante au temps
                    verb.conjugationTables[tense] = new Dictionary<Person, ConjugatedVerb>();

                for (int j = 0; j < persons.Length; j++)
                {
                    verb.conjugationTables[tense][persons[j]] = cv; // ajout du verbe conjugué pour toutes les personnes correspondantes
                }
            }

            // trie des verbes conjugués par personne
            var tenses = verb.conjugationTables.Keys.ToList();
            foreach (var tense in tenses)
            {
                verb.conjugationTables[tense] = verb.conjugationTables[tense].OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }
            
            return verb;
        }

        public UnknownWord createUnknown(string u, string attrs, string def)
        {
            return new UnknownWord(u, def);
        }

        private string getTense(int i)
        {
            return this.refdico.tenses[i];
        }

        private Person[] getPersons(int i)
        {
            Dictionary<int, Person> persons = this.refdico.persons.OrderByDescending(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            List<Person> resultat = new List<Person>();
            int current = i;
            foreach (var person in persons)
            {
                if (current - person.Key >= 0)
                {
                    current -= person.Key;
                    resultat.Add(person.Value);
                }
            }

            resultat.Reverse();
            return resultat.ToArray();
        }

        bool ILoader.UnLoad()
        {
            return this.db.close();
        }

        private bool createSchema()
        {
            // créer le schéma

            return false;
        }


        




        private class SQLiteDB
        {

            private SQLiteConnection link = null;

            private string filename;

            public SQLiteDB(string filename)
            {
                this.filename = filename;
            }

            public bool isOpen()
            {
                return this.link != null;
            }

            public bool connect()
            {
                try
                {
                    if (this.isOpen())
                    {
                        this.close();
                    }

                    this.link = new SQLiteConnection("Data Source=" + this.filename + ";Version=3;Compress=True;");
                    this.link.Open();

                    return true;
                }
                catch (SQLiteException e)
                {
                    // logger erreur !
                    Console.WriteLine(e);

                    return false;
                }
            }


            public bool close()
            {
                if (this.link != null)
                {
                    this.link.Close();
                    this.link = null; // on supprime toute référence pour le Garbage collector
                }
                return true;
            }


            public List<Dictionary<string, object>> select(string tablename, string[] fields, string[] filters = null)
            {
                if (!this.isOpen() || fields == null || tablename == null || tablename == "") return null;


                string query = "SELECT " + string.Join(", ", fields) + " FROM " + tablename;
                if (filters != null)
                {
                    query += " WHERE (" + string.Join(") AND (", filters) + ")";
                }

                List<Dictionary<string, object>> resultat = new List<Dictionary<string, object>>();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, this.link);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                DataTable table = dataset.Tables[0];
                int nbRow = table.Rows.Count;
                for (int i = 0; i < nbRow; i++)
                {
                    Dictionary<string, object> line = new Dictionary<string, object>();
                    for (int j = 0; j < table.Rows[i].ItemArray.Length; j++)
                    {
                        object value = table.Rows[i].ItemArray[j];
                        if (value is System.DBNull) value = null;

                        line[fields[j]] = value;
                    }
                    resultat.Add(line);
                }

                return resultat;
            }
        }
    }
}
