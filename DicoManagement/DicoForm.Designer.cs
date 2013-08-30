namespace DicoManagement
{
    partial class DicoForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.searchWord = new System.Windows.Forms.TextBox();
            this.listWords = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.verbPanel = new DicoManagement.VerbPanel();
            this.wordPanel = new DicoManagement.WordPanel();
            this.detail = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depuisCSVStandardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.languageIndicator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.searchWord);
            this.splitContainer1.Panel1.Controls.Add(this.listWords);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(717, 492);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 0;
            // 
            // searchWord
            // 
            this.searchWord.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchWord.ForeColor = System.Drawing.Color.DarkGray;
            this.searchWord.Location = new System.Drawing.Point(0, 0);
            this.searchWord.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.searchWord.Name = "searchWord";
            this.searchWord.Size = new System.Drawing.Size(239, 20);
            this.searchWord.TabIndex = 1;
            this.searchWord.Text = "Rechercher...";
            this.searchWord.Enter += new System.EventHandler(this.searchWord_Enter);
            this.searchWord.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchWord_KeyUp);
            this.searchWord.Leave += new System.EventHandler(this.searchWord_Leave);
            // 
            // listWords
            // 
            this.listWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listWords.FormattingEnabled = true;
            this.listWords.IntegralHeight = false;
            this.listWords.Location = new System.Drawing.Point(0, 23);
            this.listWords.Name = "listWords";
            this.listWords.Size = new System.Drawing.Size(239, 469);
            this.listWords.TabIndex = 0;
            this.listWords.SelectedIndexChanged += new System.EventHandler(this.listWords_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer2.Panel1.Controls.Add(this.verbPanel);
            this.splitContainer2.Panel1.Controls.Add(this.wordPanel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.detail);
            this.splitContainer2.Size = new System.Drawing.Size(474, 492);
            this.splitContainer2.SplitterDistance = 379;
            this.splitContainer2.TabIndex = 1;
            // 
            // verbPanel
            // 
            this.verbPanel.BackColor = System.Drawing.SystemColors.Control;
            this.verbPanel.Location = new System.Drawing.Point(3, 99);
            this.verbPanel.Name = "verbPanel";
            this.verbPanel.Size = new System.Drawing.Size(198, 90);
            this.verbPanel.TabIndex = 1;
            this.verbPanel.Visible = false;
            this.verbPanel.word = null;
            // 
            // wordPanel
            // 
            this.wordPanel.BackColor = System.Drawing.SystemColors.Control;
            this.wordPanel.Location = new System.Drawing.Point(3, 3);
            this.wordPanel.Name = "wordPanel";
            this.wordPanel.Size = new System.Drawing.Size(198, 90);
            this.wordPanel.TabIndex = 0;
            this.wordPanel.Visible = false;
            this.wordPanel.word = null;
            // 
            // detail
            // 
            this.detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detail.Location = new System.Drawing.Point(0, 0);
            this.detail.Multiline = true;
            this.detail.Name = "detail";
            this.detail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detail.Size = new System.Drawing.Size(474, 109);
            this.detail.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(717, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importerToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // importerToolStripMenuItem
            // 
            this.importerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depuisCSVStandardToolStripMenuItem});
            this.importerToolStripMenuItem.Name = "importerToolStripMenuItem";
            this.importerToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.importerToolStripMenuItem.Text = "Importer";
            // 
            // depuisCSVStandardToolStripMenuItem
            // 
            this.depuisCSVStandardToolStripMenuItem.Name = "depuisCSVStandardToolStripMenuItem";
            this.depuisCSVStandardToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.depuisCSVStandardToolStripMenuItem.Text = "Depuis CSV (Dictionnaire)";
            this.depuisCSVStandardToolStripMenuItem.Click += new System.EventHandler(this.depuisCSVStandardToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(717, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // languageIndicator
            // 
            this.languageIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.languageIndicator.AutoSize = true;
            this.languageIndicator.BackColor = System.Drawing.Color.White;
            this.languageIndicator.Location = new System.Drawing.Point(669, 3);
            this.languageIndicator.Margin = new System.Windows.Forms.Padding(3);
            this.languageIndicator.Name = "languageIndicator";
            this.languageIndicator.Padding = new System.Windows.Forms.Padding(3);
            this.languageIndicator.Size = new System.Drawing.Size(45, 19);
            this.languageIndicator.TabIndex = 3;
            this.languageIndicator.Text = "langue";
            this.languageIndicator.UseMnemonic = false;
            // 
            // DicoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 538);
            this.Controls.Add(this.languageIndicator);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DicoForm";
            this.Text = "Gestion du dictionnaire";
            this.Load += new System.EventHandler(this.DicoForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listWords;
        private System.Windows.Forms.TextBox detail;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label languageIndicator;
        private VerbPanel verbPanel;
        private WordPanel wordPanel;
        private System.Windows.Forms.ToolStripMenuItem importerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depuisCSVStandardToolStripMenuItem;
        private System.Windows.Forms.TextBox searchWord;
    }
}