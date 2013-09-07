using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE.Glossary;
using NLE.Grammar;
using NLE.Engine;

namespace NLE.Loader
{
    class Factory
    {
        private Dictionary<int, string> moods;
        private Dictionary<int, string> tenses;
        private Dictionary<int, Person> persons;

        public Factory(Dictionary<int, string> moods, Dictionary<int, string> tenses, Dictionary<int, Person> persons)
        {
            this.tenses = tenses;
            this.persons = persons;//.OrderByDescending(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            this.moods = moods;

        }


        public Word create(string w, string type, string[] attrs, string def)
        {

            WordType t = null;

            if (type.Length < 2)
            {
                // TODO: logger le fait que "type" est incorrecte

                t = this.createUnknownType(attrs);
            }

            string method = "create" + type.Substring(0, 1).ToUpper() + type.Substring(1).ToLower() + "Type";
            var m = this.GetType().GetMethod(method);
            if (m == null)
            {
                // TODO: logger le fait que "method" n'existe pas

                t = this.createUnknownType(attrs);
            }
            else
            {
                try
                {
                    // on execute la méthode de création correspondante au type
                    t =  (WordType)m.Invoke(this, new object[] { attrs });
                }
                catch (Exception /*e*/)
                {
                    // TODO: logger exception

                    t = this.createUnknownType(attrs);
                }
            }

            Word word = new Word(w, t, def);
            return word;
        }


        public UnknownType createUnknownType(string[] attrs)
        {
            return new UnknownType();
        }


        public CommonNounType createNounType(string[] attrs)
        {
            CommonNounType.Gender g = this.getEnumIfFound(attrs, CommonNounType.Gender.Unknown);
            CommonNounType.Number n = this.getEnumIfFound(attrs, CommonNounType.Number.Unknown);

            return new CommonNounType(g, n);
        }


        public VerbType createVerbType(string[] attrs)
        {
            if (attrs.Length == 3)
            {
                try
                {
                    int m = int.Parse(attrs[0]);
                    int t = int.Parse(attrs[1]);
                    int p = int.Parse(attrs[2]);
                    return this.createVerbType(m, t, p);
                }
                catch (Exception)
                {
                    // logger erreur
                }
            }

            return new VerbType(this.getMood(1), null, null);
        }

        private VerbType createVerbType(int mood, int tense, int person)
        {
            return new VerbType(this.getMood(mood), this.getTense(tense), this.getPersons(person));
        }




        // méthode permettant de chercher une valeur d'enum en fonction du nom de l'enum
        private T getEnumIfFound<T>(string[] attrs, T defaut)
        {
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (attrs.Contains(item.ToString().ToLower()))
                    return item;
            }
            return defaut;
        }



        private string getMood(int i)
        {
            return (this.moods.ContainsKey(i) ? this.moods[i] : "");
        }

        private string getTense(int i)
        {
            return (this.tenses.ContainsKey(i) ? this.tenses[i] : "");
        }

        private Person getPersons(int i)
        {
            return (this.persons.ContainsKey(i) ? this.persons[i] : new Person(0, 0, "", "", ""));
        }

    }
}
