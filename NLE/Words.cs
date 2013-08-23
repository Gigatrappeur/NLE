﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using NLE.Glossary;
using NLE.Loader;

namespace NLE
{

    public class Words
    {
        // racine de l'arbre
        private FragmentWord root;

        // indique si le dictionnaire est déjà chargé
        private bool IsAlreadyLoaded;
        // objet gérant les intéractions entre le dictionnaire et son support de stockage
        private ILoader loader;


        /// <summary>
        /// Constructeur du dictionnaire
        /// </summary>
        /// <param name="loader">Objet permettant de gérer les opération entre le dictionnaire et son support de stockage</param>
        public Words(ILoader loader = null)
        {
            this.loader = loader;
            this.root = new FragmentWord(' ');
        }


        /// <summary>
        /// Charge le dictionnaire à l'aide du loader donné lors de la construction
        /// </summary>
        /// <returns>Si le chargement s'est passé correctement, renvoi true</returns>
        public bool load()
        {
            if (this.loader != null && !this.IsAlreadyLoaded)
            {
                this.IsAlreadyLoaded = this.loader.Load(this);
                return this.IsAlreadyLoaded;
            }

            return false; // pas de loader définit ou dico déjà chargé
        }


        /// <summary>
        /// Ajoute un mot au dictionnaire
        /// </summary>
        /// <param name="w">Mot à ajouter</param>
        /// <returns>Si le mot a été ajouté, retourne true</returns>
        public bool AddWord(Word w)
        {
            return this.root.AddFragment(w, w.word);
        }
        

        /// <summary>
        /// Récupère l'objet Word correspondant à w
        /// </summary>
        /// <param name="w">Chaine contenant le mot à chercher</param>
        /// <returns>Retourne le 'Word' correspondant à w</returns>
        public Word get(string w)
        {
            FragmentWord rt = this.getFragment(w);
            return (rt != null ? rt.word : null);
        }


        /// <summary>
        /// Récupère la liste de Word contenu dans le dictionnaire
        /// </summary>
        /// <returns>Retourne tableau de 'Word'</returns>
        public Word[] getAll()
        {
            return this.root.getAll();
        }


        /// <summary>
        /// Récupère la liste de Word contenu dans le dictionnaire filtré avec "filter"
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Retourne tableau de 'Word'</returns>
        public Word[] getAll(string filter)
        {
            FragmentWord rt = this.getFragment(filter);
            if (rt == null)
            {
                return new Word[0];
            }

            return rt.getAll();
        }


        /*
        A utiliser avec des filtre sur les attributs. Par exemple si l'on cherche un enfant qui est aussi un verbe conjugé à la première personne du singulier.
        public Word[] getAll(Word filter)
        {
            return null;
        }
        */


        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne 'Words' sous forme de chaine</returns>
        public override string ToString()
        {
            string rt = "Words" + this.root;

            return rt;
        }



        #region "Private Method"


        /// <summary>
        /// Retourne le fragment correspondant à la chaine w
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        private FragmentWord getFragment(string w)
        {
            return this.root.get(w.ToLower());
        }


        #endregion



        // on masque le fonctionnement interne
        private class FragmentWord
        {
            private Dictionary<char, FragmentWord> childs;

            public char fragment { get; private set; }
            public Word word { get; private set; }

            public FragmentWord(char fragment)
            {
                this.childs = new Dictionary<char, FragmentWord>();
                this.fragment = fragment;
                this.word = null;
            }

            private FragmentWord search(char c)
            {
                return (this.childs.ContainsKey(c) ? this.childs[c] : null);
            }

            public FragmentWord get(string w)
            {
                FragmentWord fw = this.search(w[0]);
                if (fw == null)
                    return null; // mot pas trouvé

                if (w.Length == 1) // on est arrivé à la fin du mot
                    return fw;

                return fw.get(w.Substring(1)); // on continu de chercher
            }

            public bool AddFragment(Word w, string substr)
            {
                char c = substr[0];

                FragmentWord f = this.search(c);
                if (f == null)
                {
                    f = new FragmentWord(c);
                    this.childs.Add(c, f);
                }

                if (substr.Length > 1)
                {
                    return f.AddFragment(w, substr.Substring(1)); // on propage l'ajout
                }
                else if (substr.Length == 1 && f.word == null)
                {
                    f.word = w;
                    return true; // on a ajouté le mot
                }

                return false; // on a rien ajouté
            }

            public Word[] getAll()
            {
                List<Word> rt = new List<Word>();
                if (this.word != null)
                    rt.Add(this.word);

                foreach (var item in this.childs)
                {
                    rt.AddRange(item.Value.getAll());
                }

                return rt.ToArray();
            }

            public override string ToString()
            {
                return this.ToString();
            }

            protected string ToString(string startLine = "")
            {
                String rt = this.fragment + Environment.NewLine;

                int i = (this.word != null ? 0 : 1);
                foreach (var item in this.childs)
                {
                    string next = (i > this.childs.Count - 1 ? "  " : "| ");

                    rt += startLine + "+-" + item.Value.ToString(startLine + next);

                    i++;
                }

                if (this.word != null)
                {
                    rt += startLine + "+-" + this.word + Environment.NewLine + startLine + Environment.NewLine;
                }

                return rt;
            }

        }
    }
}
