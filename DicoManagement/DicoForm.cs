using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using NLE;
using NLE.Glossary;

namespace DicoManagement
{
    public partial class DicoForm : Form
    {
        private Word[] source = null;

        public DicoForm()
        {
            InitializeComponent();
        }

        private void DicoForm_Load(object sender, EventArgs e)
        {
            // chargement du dico en asynchrone
            //loadingEngineTerminated(NLEEngine.load());
            NLEEngine.loadAsync(new NLEEngine.LoadTerminated(loadingEngineTerminated));
        }

        private void loadingEngineTerminated(bool success)
        {
            if (!success)
            {
                MessageBox.Show("Erreur lors du chargmeent du moteur NLE !");
                return;
            }

            // on initialise la datasource
            endLoadingEngine();
        }


        private delegate void endLoadingEngineDelegate();
        private void endLoadingEngine()
        {
            if (this.listWords.InvokeRequired)
            {
                this.Invoke(new endLoadingEngineDelegate(endLoadingEngine), new object[] { });
            }
            else
            {
                int oldWidth = this.languageIndicator.Width;
                this.languageIndicator.Text = Utils.firstLetterToUpper(NLEEngine.language);
                this.languageIndicator.Left += oldWidth - this.languageIndicator.Width;

                this.source = NLEEngine.getAll();
                Array.Sort(this.source);
                this.listWords.DisplayMember = "word";
                this.listWords.DataSource = this.source;
            }
        }

        private void listWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listWords.SelectedItem == null) return;

            // trace
            detail.Text = listWords.SelectedItem.ToString();

            bool isVerb = false, isBaseVerb = false;
            if (listWords.SelectedItem is Word)
            {
                isVerb = (listWords.SelectedItem as Word).IsTypeOf(typeof(VerbType));
                foreach (WordType type in (listWords.SelectedItem as Word).types)
	            {
                    if (type is VerbType && (type as VerbType).table != null && (type as VerbType).table.verbBase == (listWords.SelectedItem as Word))
                        isBaseVerb = true;
	            }
                
            }


            if (isBaseVerb)
            {
                this.wordPanel.Visible = false;
                this.verbPanel.Dock = DockStyle.Fill;
                this.verbPanel.word = (Word)listWords.SelectedItem;
                this.verbPanel.Visible = true;

                // trace
                //detail.Text += Environment.NewLine + Environment.NewLine + (listWords.SelectedItem as InfinitiveVerbType).ConjugationTablesToString();
                detail.Text += Environment.NewLine + Environment.NewLine + "l'affichage des tables sont en cours développement !";
            }
            else
            {
                this.verbPanel.Visible = false;
                this.wordPanel.Dock = DockStyle.Fill;
                this.wordPanel.word = (Word) listWords.SelectedItem;
                this.wordPanel.Visible = true;
            }
        }

        private void depuisCSVStandardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // charger DicFra.csv
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.Multiselect = false;
            dialog.Title = "Importer dictionnaire";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                string filename = dialog.FileName;

                // ...
            }
        }



        // --  Gestion recherche  ---------------------------------------------

        private void searchWord_Enter(object sender, EventArgs e)
        {
            // focus in
            if (this.searchWord.Text == "Rechercher...")
            {
                this.searchWord.Text = "";
                this.searchWord.ForeColor = Color.Black;
                this.searchWord.Font = new Font(this.searchWord.Font, FontStyle.Regular);
            }
        }

        private void searchWord_Leave(object sender, EventArgs e)
        {
            // focus out
            if (this.searchWord.Text == "")
            {
                this.searchWord.Text = "Rechercher...";
                this.searchWord.ForeColor = Color.DarkGray;
                this.searchWord.Font = new Font(this.searchWord.Font, FontStyle.Italic);
            }
        }

        private void searchWord_KeyUp(object sender, KeyEventArgs e)
        {
            this.listWords.DataSource = this.source.Where(new Func<Word,bool>(wordListfilter)).ToArray();
        }

        private bool wordListfilter(Word w)
        {
            return w.word.IndexOf(this.searchWord.Text) > -1;
        }
    }
}
