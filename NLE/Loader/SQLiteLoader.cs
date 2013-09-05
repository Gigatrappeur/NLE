using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SQLite;

using NLE.Glossary;
using NLE.Grammar;
using NLE.Engine;

namespace NLE.Loader
{
    public class SQLiteLoader : ILoader
    {
        private SQLiteDB db = null;


        // utilisé uniquement pour le chargement !
        //private LanguageDictionary refdico = null;


        public SQLiteLoader(string filename)
        {
            this.db = new SQLiteDB(filename);
        }

        ~SQLiteLoader()
        {
            this.db.close();
        }

        bool ILoader.Load(LanguageDictionary dico)
        {
            // chargement du dico à partir d'une base SQLite

            //this.refdico = dico;

            this.db.connect();

            this.createSchema();

            // ----------------------------------------------------------------
            // --  début des chargements  -------------------------------------


            // --  chargement des tables de paramètres  -----------------------

            dico.moods = this.loadMoods();
            if (dico.moods == null)
            {
                // une erreur s'est produite lors du chargement des personnes
            }

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

            Utils.translations = this.loadTranslations();


            // chargement factory
            Factory factory = new Factory(null, dico.tenses, dico.persons, this);



            // --  chargement des mots  ---------------------------------------

            List<Dictionary<string, object>> words = this.db.select("words", new string[] { "word", "type", "attributs", "definition" });
            for (int i = 0; i < words.Count; i++)
            {
                string w = (string)words[i]["word"];
                string t = (string)words[i]["type"];
                string a = (string)words[i]["attributs"];
                string d = (string)words[i]["definition"];

                if (a == null) a = "";
                if (d == null) d = "";

                Word word = factory.create(w, t, a.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries), d);

                if (word.IsTypeOf(typeof(VerbType)))
                {
                    //charger la table de conjugaison

                }

                dico.AddWord(word);
            }

            // test
            ConjugationTable partirTable = new ConjugationTable();
            Word partir = new Word("partir", new VerbType("infinitif", null, null, partirTable));
            partirTable.setBase(partir);
            partirTable.Add(partir);
            dico.AddWord(partir);

            Word jePars = new Word("pars", new VerbType("indicatif", "présent", new Person(1, 1, "1", "je", "je..."), null));
            Word tuPars = new Word("pars", new VerbType("indicatif", "présent", new Person(1, 2, "2", "tu", "tu..."), null));
            Word ilPart = new Word("part", new VerbType("indicatif", "présent", new Person(1, 3, "4", "il", "il..."), null));

            partirTable.Add(jePars);
            partirTable.Add(tuPars);
            partirTable.Add(ilPart);
            
            dico.AddWord(jePars);
            dico.AddWord(tuPars);
            dico.AddWord(ilPart);




            // charger table de conjugaison
            

            // --  fin des chargements  ---------------------------------------
            // ----------------------------------------------------------------

            this.db.close();

            //this.refdico = null;

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

                rt.Add(id, n);
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

                rt.Add(e, new Person(id, p, n, pp, d));
            }

            return rt;
        }

        private Dictionary<int, string> loadMoods()
        {
            //  TODO: écrire chargement
            return null;
        }

        private string loadLanguage()
        {
            List<Dictionary<string, object>> parametres = this.db.select("params", new string[] { "name", "value" }, new string[] { "name='language'" });
            if (parametres.Count != 1)
                throw new Exception("language unknown");

            return (string)parametres[0]["value"];
        }

        private Dictionary<string, string> loadTranslations()
        {
            Dictionary<string, string> rt = new Dictionary<string, string>();
            List<Dictionary<string, object>> translations = this.db.select("translations", new string[] { "key", "value" });

            for (int i = 0; i < translations.Count; i++)
            {
                string k = (string)translations[i]["key"];
                string v = (string)translations[i]["value"];

                rt.Add(k, v);
            }

            return rt;
        }

        /*List<ConjugatedVerbType> ILoader.getConjugatedVerbsFor(InfinitiveVerbType verb, Factory factory)
        {
            List<Dictionary<string, object>> verbsRaw = this.db.select("conjugated_verbs", new string[] { "tense", "person", "word" }, new string[] { "infinitive='" + verb.word + "'" });

            List<ConjugatedVerbType> verbs = new List<ConjugatedVerbType>();
            for (int i = 0; i < verbsRaw.Count; i++)
            {
                int t = (int)((decimal)verbsRaw[i]["tense"]);
                int p = (int)((decimal)verbsRaw[i]["person"]);
                string w = (string)verbsRaw[i]["word"];

                verbs.Add(factory.create_ConjugatedVerb(w, verb, t, p));
            }

            return verbs;
        }*/

        bool ILoader.UnLoad()
        {
            return this.db.close();
        }

        private bool createSchema()
        {
            // créer le schéma

            bool success = true;

            if (success && !this.db.existsTable("params"))
            {
                // table params
                // CREATE TABLE params (id INTEGER PRIMARY KEY, name TEXT, value TEXT);
                // INSERT INTO params VALUES(1,'language','unknown');
                success = success && this.db.createTable("params", new string[] { "id INTEGER PRIMARY KEY", "name TEXT", "value TEXT" });

                if (success)
                    success = success && this.db.insert("params", new string[] { "name", "value" }, new string[] { "language", "unknown" });
            }

            if (success && !this.db.existsTable("translations"))
            {
                // table translations
                // CREATE TABLE translations (key TEXT, value TEXT);
                success = success && this.db.createTable("translations", new string[] { "key TEXT", "value TEXT" });
            }

            if (success && !this.db.existsTable("tenses"))
            {
                // table tenses
                // CREATE TABLE tenses (id INTEGER PRIMARY KEY, name TEXT);
                success = success && this.db.createTable("tenses", new string[] { "id INTEGER PRIMARY KEY", "name TEXT" });
            }

            if (success && !this.db.existsTable("persons"))
            {
                // table persons
                // CREATE TABLE persons (id INTEGER PRIMARY KEY, enum NUMERIC, position NUMERIC, number TEXT, personal_pronoun TEXT, description TEXT);
                success = success && this.db.createTable("persons", new string[] { "id INTEGER PRIMARY KEY", "enum NUMERIC", "position NUMERIC", "number TEXT", "personal_pronoun TEXT", "description TEXT" });
            }

            if (success && !this.db.existsTable("words"))
            {
                // table words
                // CREATE TABLE words (id INTEGER PRIMARY KEY, word TEXT, type TEXT, attributs TEXT, definition TEXT);
                success = success && this.db.createTable("words", new string[] { "id INTEGER PRIMARY KEY", "word TEXT", "type TEXT", "attributs TEXT", "definition TEXT" });
            }

            if (success && !this.db.existsTable("conjugated_verbs"))
            {
                // table conjugated_verbs
                // CREATE TABLE conjugated_verbs (id INTEGER PRIMARY KEY, infinitive TEXT, tense NUMERIC, person NUMERIC, word TEXT);
                success = success && this.db.createTable("conjugated_verbs", new string[] { "id INTEGER PRIMARY KEY", "infinitive TEXT", "tense NUMERIC", "person NUMERIC", "word TEXT" });
            }


            // table rules
            // ...
            // this.db.createTable("rules", new string[] { });

            return success;
        }


        


        // --  classe de gestion de la base de données SQLite  ----------------

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

            public bool createTable(string name, string[] fields)
            {
                this.query(@"CREATE TABLE " + name + " (" + string.Join(", ", fields) + ")");
                return true;
            }

            public bool existsTable(string name)
            {
                List<Dictionary<string, object>> res = this.select("sqlite_master", new string[] {"count(name)"}, new string[] {"type = 'table'", "name = '" + name + "'"});
                return ((long)res[0]["count(name)"]) == 1;
            }

            public bool insert(string table, string[] fields, string[] values)
            {
                string request = @"INSERT INTO " + table + " (" + string.Join(", ", fields) + ") VALUES ('" + string.Join("', '", values) + "')";
                return this.query(request) == 1;
            }

            public int query(string request)
            {
                using (SQLiteCommand cmd = this.link.CreateCommand())
                {
                    cmd.CommandText = request;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
