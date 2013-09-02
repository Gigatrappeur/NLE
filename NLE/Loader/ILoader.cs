using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE.Engine;
using NLE.Glossary;

namespace NLE.Loader
{
    interface ILoader
    {
        bool Load(LanguageDictionary dico);
        bool UnLoad();

        // doit gérer les interactions entre le dictionnaire et son support de stockage



        // pour récupérer la liste des verbs conjugués correspondante au verbe à l'infinitif
        List<ConjugatedVerb> getConjugatedVerbsFor(InfinitiveVerb verb, GlossaryFactory factory);
    }
}
