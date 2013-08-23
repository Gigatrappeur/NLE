using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SQLite;

using NLE.Glossary;

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

            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM ...", this.link);
            DataSet dataset = new DataSet();

            adapter.Fill(dataset);
            DataTable table = dataset.Tables[0];
            DataTableReader reader = table.CreateDataReader();
            while (reader.NextResult())
            {
                reader.GetString(0); // champs '0'
            }

            this.deconnection();


            return false;
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
