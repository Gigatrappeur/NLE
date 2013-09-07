using System;

using NLE.Loader;
using NLE.Glossary;
using NLE.Engine;
using System.Threading;

namespace NLE
{
    public static class NLEEngine
    {
        // classe permettant de paramétrer le moteur
        public class Parameters { };

        // délégué pour le retour du chargement asynchrone du moteur
        public delegate void LoadTerminated(bool success);


        // --  propriétés pour le fonctionnement interne  ---------------------

        // remplacé par un parametre d'application : private static string dbpath = @"..\..\..\Data\fr-test.db";

        // dictionnaire
        private static LanguageDictionary dico = null;

        // loader
        private static ILoader loader = null;

        // moteur d'inférence
        private static InferencesEngine engine = null;



        // --   loader    -----------------------------------------------------

        public static bool load(Parameters parameters = null)
        {
            NLEEngine.beginLoading(null, parameters);
            return dico.IsLoaded;
        }

        public static void loadAsync(LoadTerminated callback = null, Parameters parameters = null)
        {
            NLEEngine.beginLoading(callback, parameters);
        }


        // --  privates méthodes for loading

        private static void beginLoading(LoadTerminated callback, Parameters parameters = null)
        {
            if (NLEEngine.dico != null)
            {
                // désallouer le précédent dico

            }

            
            // paramétrer loader du moteur en fonction d'argument passer à la méthode load
            // utiliser "parameters"
            loader = new SQLiteLoader(Properties.Settings.Default.dbpath);


            NLEEngine.dico = new LanguageDictionary();

            if (callback == null)
            {
                // chargement synchrone
                NLEEngine.loadAsyncNext();
            }
            else
            {
                // chargement asynchrone
                new Thread(new ParameterizedThreadStart(NLEEngine.loadAsyncNext)).Start(callback);
            }
        }

        private static void loadAsyncNext(object callback = null)
        {
            try
            {
                dico.IsLoaded = false;

                loader.beforeLoading();

                Utils.translations = loader.loadTranslations();

                dico.language = loader.loadLanguage();
                dico.moods = loader.loadMoods();
                dico.persons = loader.loadPersons();
                dico.tenses = loader.loadTenses();

                Factory factory = new Factory(dico.moods, dico.tenses, dico.persons);
                loader.loadDico(dico, factory);

                loader.afterLoading();

                dico.IsLoaded = true;
            }
            catch (Exception)
            {
                // logger erreur
            }

            if (callback != null && callback is LoadTerminated)
                (callback as LoadTerminated)(dico.IsLoaded);
        }



        // --  accesseur   ----------------------------------------------------

        /// <summary>
        /// Retourne le mot correspondant à la chaine "w"
        /// </summary>
        /// <param name="w">Chaine à chercher dans le dictionnaire</param>
        /// <returns>NLE.Glossary.Word</returns>
        public static Word get(string w)
        {
            return dico.get(w);
        }

        /// <summary>
        /// Retourne une chaine représentant le dictionnaire (A éviter !)
        /// </summary>
        /// <returns>string</returns>
        public static string showDico()
        {
            return NLEEngine.dico.ToString();
        }

        /// <summary>
        /// Retourne tous les mots du dictionnaires
        /// </summary>
        /// <returns>Liste de NLE.Glossary.Word</returns>
        public static Word[] getAll()
        {
            return NLEEngine.dico.getAll();
        }

        /// <summary>
        /// Langage du dictionnaire
        /// </summary>
        public static string language
        {
            get { return dico.language; }
        }


        // --  algorithme  ----------------------------------------------------


        // --  analyse

        // temporaire
        public static Word[] lexicalAnalyse(string text)
        {
            return Analyse.lexical(text);
        }

        // temporaire
        public static string testTrasformation(string text)
        {
            return Analyse.whatTypeOfPhrase(text);
        }


        // --  prédiction
        /// <summary>
        /// Retourne tous les mots correspondant au début de mot
        /// </summary>
        /// <param name="startWord">Début de mot</param>
        /// <returns>Liste d'objet NLE.Glossary.Word</returns>
        public static Word[] predictionSimple(string startWord)
        {
            return Prediction.simple(NLEEngine.dico, startWord);
        }
    }
}
