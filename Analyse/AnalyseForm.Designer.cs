namespace Analyse
{
    partial class AnalyseForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.analyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.analyseText = new System.Windows.Forms.TextBox();
            this.analyseBtn = new System.Windows.Forms.Button();
            this.predictionText = new System.Windows.Forms.TextBox();
            this.predictionListBox = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.resultatAnalyseText = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analyseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(857, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // analyseToolStripMenuItem
            // 
            this.analyseToolStripMenuItem.Name = "analyseToolStripMenuItem";
            this.analyseToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.analyseToolStripMenuItem.Text = "Analyse";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(857, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // analyseText
            // 
            this.analyseText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analyseText.Location = new System.Drawing.Point(9, 19);
            this.analyseText.Multiline = true;
            this.analyseText.Name = "analyseText";
            this.analyseText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.analyseText.Size = new System.Drawing.Size(301, 121);
            this.analyseText.TabIndex = 3;
            // 
            // analyseBtn
            // 
            this.analyseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.analyseBtn.Location = new System.Drawing.Point(235, 282);
            this.analyseBtn.Name = "analyseBtn";
            this.analyseBtn.Size = new System.Drawing.Size(75, 23);
            this.analyseBtn.TabIndex = 4;
            this.analyseBtn.Text = "Analyse";
            this.analyseBtn.UseVisualStyleBackColor = true;
            this.analyseBtn.Click += new System.EventHandler(this.analyseBtn_Click);
            // 
            // predictionText
            // 
            this.predictionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.predictionText.Location = new System.Drawing.Point(6, 19);
            this.predictionText.Name = "predictionText";
            this.predictionText.Size = new System.Drawing.Size(304, 20);
            this.predictionText.TabIndex = 0;
            this.predictionText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.predictionText_KeyUp);
            // 
            // predictionListBox
            // 
            this.predictionListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.predictionListBox.FormattingEnabled = true;
            this.predictionListBox.Location = new System.Drawing.Point(6, 45);
            this.predictionListBox.Name = "predictionListBox";
            this.predictionListBox.Size = new System.Drawing.Size(304, 95);
            this.predictionListBox.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(857, 377);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resultatAnalyseText);
            this.groupBox1.Controls.Add(this.analyseText);
            this.groupBox1.Controls.Add(this.analyseBtn);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 311);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analyse";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.predictionListBox);
            this.groupBox2.Controls.Add(this.predictionText);
            this.groupBox2.Location = new System.Drawing.Point(325, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 157);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Prédiction";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(82, 17);
            this.statusLabel.Text = "Chargement...";
            // 
            // resultatAnalyseText
            // 
            this.resultatAnalyseText.Location = new System.Drawing.Point(9, 146);
            this.resultatAnalyseText.Multiline = true;
            this.resultatAnalyseText.Name = "resultatAnalyseText";
            this.resultatAnalyseText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultatAnalyseText.Size = new System.Drawing.Size(301, 130);
            this.resultatAnalyseText.TabIndex = 5;
            // 
            // AnalyseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 423);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnalyseForm";
            this.Text = "AnalyseForm";
            this.Load += new System.EventHandler(this.AnalyseForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem analyseToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox analyseText;
        private System.Windows.Forms.Button analyseBtn;
        private System.Windows.Forms.TextBox predictionText;
        private System.Windows.Forms.ListBox predictionListBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TextBox resultatAnalyseText;
    }
}