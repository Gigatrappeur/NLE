using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE.Glossary;

namespace NLE.Engine
{
    class InferencesEngine
    {
        private List<InferenceRule> rules;


        public InferencesEngine()
        {
            this.rules = new List<InferenceRule>();

            // temporaire
            this.rules.Add(new InferenceRule());

        }


        public InferenceRule match(PhraseItem[] phrase)
        {
            if (this.rules.Count == 0) return null;

            InferenceRule current = this.rules[0];
            int globalDistance = current.distance(phrase);
            for (int i = 1; i < this.rules.Count; i++)
            {
                int distance = rules[i].distance(phrase);
                if (distance != -1 && (globalDistance == -1 || globalDistance > distance))
                {
                    globalDistance = distance;
                    current = rules[i];
                }
            }

            return current;
        }


        class InferenceRule
        {
            public int distance(PhraseItem[] phrase) { return -1; }
        }
    }
}
