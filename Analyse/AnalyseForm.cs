using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using NLE;

namespace Analyse
{
    public partial class AnalyseForm : Form
    {
        public AnalyseForm()
        {
            InitializeComponent();
        }

        private void AnalyseForm_Load(object sender, EventArgs e)
        {
            this.progressBar.Visible = true;
            NLEEngine.loadAsync(new NLEEngine.LoadTerminated(loadingEngineTerminated));
        }

        private delegate void endLoadingEngineTerminatedDelegate(bool success);
        private void loadingEngineTerminated(bool success)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new endLoadingEngineTerminatedDelegate(loadingEngineTerminated), new object[] { success });
            }
            else
            {
                
                if (success)
                {
                    this.statusLabel.Text = "Prêt";
                }
                else
                {
                    this.statusLabel.Text = "Erreur lors du chargement du moteur";
                }

                this.progressBar.Visible = false;
            }
        }



        private void analyseBtn_Click(object sender, EventArgs e)
        {
            this.resultatAnalyseText.Text = string.Join<NLE.Glossary.Word>(Environment.NewLine, NLEEngine.lexicalAnalyse(this.analyseText.Text));
        }

        private void predictionText_KeyUp(object sender, KeyEventArgs e)
        {
            this.predictionListBox.DataSource = NLEEngine.predictionSimple(predictionText.Text);
        }

    }
}
