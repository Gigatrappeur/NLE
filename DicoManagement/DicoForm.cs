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

                Word[] words = NLEEngine.getAll();
                Array.Sort(words);
                this.listWords.DisplayMember = "word";
                this.listWords.DataSource = words;
            }
        }

        private void listWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listWords.SelectedItem == null) return;

            // trace
            detail.Text = listWords.SelectedItem.ToString();

            if (listWords.SelectedItem is InfinitiveVerb)
            {
                this.wordPanel.Visible = false;
                this.verbPanel.Dock = DockStyle.Fill;
                this.verbPanel.word = (Word)listWords.SelectedItem;
                this.verbPanel.Visible = true;

                // trace
                detail.Text += Environment.NewLine + Environment.NewLine + (listWords.SelectedItem as InfinitiveVerb).ConjugationTablesToString();
            }
            else
            {
                this.verbPanel.Visible = false;
                this.wordPanel.Dock = DockStyle.Fill;
                this.wordPanel.word = (Word) listWords.SelectedItem;
                this.wordPanel.Visible = true;
            }
        }
    }
}
