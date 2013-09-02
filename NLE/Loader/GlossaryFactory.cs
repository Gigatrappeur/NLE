using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE.Glossary;
using NLE.Engine;

namespace NLE.Loader
{
    class GlossaryFactory
    {
        private Dictionary<int, string> tenses;
        private Dictionary<int, Person> persons;
        private ILoader loader;

        public GlossaryFactory(Dictionary<int, string> tenses, Dictionary<int, Person> persons, ILoader loader)
        {
            this.tenses = tenses;
            this.persons = persons.OrderByDescending(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            this.loader = loader;
        }


        public Word create(string w, string type, string attrs, string def)
        {
            if (type.Length < 2)
            {
                // TODO: logger le fait que "type" est incorrecte

                return this.createUnknown(w, attrs, def);
            }

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
                    // on execute la méthode de création correspondante au type
                    return (Word)m.Invoke(this, new object[] { w, attrs, def });
                }
                catch (Exception /*e*/)
                {
                    // TODO: logger exception

                    return this.createUnknown(w, attrs, def);
                }
            }
        }


        public UnknownWord createUnknown(string u, string attrs, string def)
        {
            return new UnknownWord(u, def);
        }


        public Noun createNoun(string n, string attrs, string def)
        {
            return new Noun(n, attrs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries), def);
        }


        // InfinitiveVerb
        public Verb createVerb(string v, string attrs, string def)
        {
            // verbe à l'infinitif
            InfinitiveVerb verb = new InfinitiveVerb(v, def);

            // chargement de la table de conjugaison
            List<ConjugatedVerb> verbs = this.loader.getConjugatedVerbsFor(verb, this);
            for (int i = 0; i < verbs.Count; i++)
            {
                string tense = verbs[i].tense;
                Person[] persons = verbs[i].persons;

                if (!verb.conjugationTables.ContainsKey(tense)) // on créé la table correspondante au temps
                    verb.conjugationTables[tense] = new Dictionary<Person, ConjugatedVerb>();

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
            }

            return verb;
        }

        public ConjugatedVerb create_ConjugatedVerb(string v, InfinitiveVerb infinitive, int tense, int persons)
        {
            return new ConjugatedVerb(v, this.getTense(tense), infinitive, this.getPersons(persons));
        }




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
