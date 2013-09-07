using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE.Engine;
using NLE.Glossary;
using NLE.Grammar;

namespace NLE.Loader
{
    interface ILoader
    {

        Dictionary<int, string> loadTenses();
        Dictionary<int, Person> loadPersons();
        Dictionary<int, string> loadMoods();
        Dictionary<string, string> loadTranslations();
        string loadLanguage();

        void loadDico(LanguageDictionary dico, Factory factory);

        // méthode pour ouverture/fermutre de fichiers, par exemple
        void beforeLoading();
        void afterLoading();

        // méthodes de reset ?

        // ajouter les méthodes concernant le chargement des règles d'inférences

    }
}
