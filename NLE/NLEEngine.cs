using System;

using NLE.Loader;
using NLE.Glossary;
using NLE.Engine;
using System.Threading;

namespace NLE
{
    public static class NLEEngine
    {

        public delegate void LoadTerminated(bool success);



        private static string dbpath = @"..\..\..\Data\fr-test.db";

        private static Words dico = null;



        // --   loader    -----------------------------------------------------

        public static bool load()
        {
            NLEEngine.dico = NLEEngine.createWords();
            return NLEEngine.dico.load();
        }

        //delegate void DloadAsyncNext(OnLoadTerminated callback);
        public static void loadAsync(LoadTerminated callback = null)
        {
            NLEEngine.dico = NLEEngine.createWords();

            // chargement asynchrone
            new Thread(new ParameterizedThreadStart(NLEEngine.loadAsyncNext)).Start(callback);
        }

        private static Words createWords()
        {
            if (NLEEngine.dico != null)
            {
                // désallouer le précédent dico

            }


            // paramétrer loader du moteur en fonction d'argument passer à la méthode load
            SQLiteLoader loader = new SQLiteLoader(NLEEngine.dbpath);


           return new Words(loader);
        }

        private static void loadAsyncNext(object callback)
        {
            bool success = NLEEngine.dico.load();

            if (callback != null && callback is LoadTerminated)
                (callback as LoadTerminated)(success);
        }



        // --  accesseur   ----------------------------------------------------

        public static Word get(string w)
        {
            return dico.get(w);
        }

        public static string showDico()
        {
            return NLEEngine.dico.ToString();
        }

        public static Word[] getAll()
        {
            return NLEEngine.dico.getAll();
        }



        // --  algorithme  ----------------------------------------------------

        public static Word[] predictionSimple(string startWord)
        {
            return Prediction.simple(NLEEngine.dico, startWord);
        }
    }
}
