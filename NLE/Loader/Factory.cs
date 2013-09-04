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
        private ILoader loader;

        public Factory(Dictionary<int, string> moods, Dictionary<int, string> tenses, Dictionary<int, Person> persons, ILoader loader)
        {
            this.tenses = tenses;
            this.persons = persons.OrderByDescending(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            this.loader = loader;
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

            /*CommonNounType.Gender g = CommonNounType.Gender.Unknown;
            foreach (CommonNounType.Gender item in Enum.GetValues(typeof(CommonNounType.Gender)))
            {
                if (attrs.Contains(item.ToString().ToLower()))
                    g = item;
            }*/
            CommonNounType.Gender g = this.getEnumIfFound(attrs, CommonNounType.Gender.Unknown);
            CommonNounType.Number n = this.getEnumIfFound(attrs, CommonNounType.Number.Unknown);

            return new CommonNounType(g, n);
        }

        private T getEnumIfFound<T>(string[] attrs, T defaut)
        {
            T e = defaut;
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (attrs.Contains(item.ToString().ToLower()))
                    e = item;
            }
            return e;
        }


        public VerbType createVerbType(string[] attrs)
        {
            return new VerbType("infinitive", null, null, new ConjugationTable());


            // chargement de la table de conjugaison
            /*List<ConjugatedVerbType> verbs = this.loader.getConjugatedVerbsFor(verb, this);
            for (int i = 0; i < verbs.Count; i++)
            {
                string tense = verbs[i].tense;
                Person[] persons = verbs[i].persons;

                if (!verb.conjugationTables.ContainsKey(tense)) // on créé la table correspondante au temps
                    verb.conjugationTables[tense] = new Dictionary<Person, ConjugatedVerbType>();

                for (int j = 0; j < persons.Length; j++)
                {
                    verb.conjugationTables[tense][persons[j]] = verbs[i]; // ajout du verbe conjugué pour toutes les personnes correspondantes
                }
            }

            // trie des verbes conjugués par personne
            var tenses = verb.conjugationTables.Keys.ToList();
            foreach (var tense in tenses)
            {
                verb.conjugationTables[tense] = verb.conjugationTables[tense].OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }*/

        }

        /*public ConjugatedVerbType create_ConjugatedVerb(string v, InfinitiveVerbType infinitive, int tense, int persons)
        {
            return new ConjugatedVerbType(v, this.getTense(tense), infinitive, this.getPersons(persons));
        }*/




        private string getTense(int i)
        {
            return this.tenses[i];
        }

        private Person[] getPersons(int i)
        {
            List<Person> resultat = new List<Person>();
            int current = i;
            foreach (var person in this.persons)
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

    }
}
