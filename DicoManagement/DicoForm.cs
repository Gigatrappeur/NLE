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
            setDataSource();
        }


        private delegate void setDataSourceDelegate();
        private void setDataSource()
        {
            if (this.listWords.InvokeRequired)
            {
                this.Invoke(new setDataSourceDelegate(setDataSource), new object[] { });
            }
            else
            {
                Word[] words = NLEEngine.getAll();
                Array.Sort(words);
                this.listWords.DisplayMember = "word";
                this.listWords.DataSource = words;
            }
        }

        private void listWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listWords.SelectedItem == null) return;

            detail.Text = listWords.SelectedItem.ToString();
            if (listWords.SelectedItem is InfinitiveVerb)
            {
                detail.Text += Environment.NewLine + Environment.NewLine + (listWords.SelectedItem as InfinitiveVerb).ConjugationTablesToString();
            }
        }
    }
}
