namespace DicoManagement
{
    partial class WordPanel
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.wordSpelling = new System.Windows.Forms.Label();
            this.wordDefinition = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wordSpelling
            // 
            this.wordSpelling.AutoSize = true;
            this.wordSpelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordSpelling.Location = new System.Drawing.Point(3, 13);
            this.wordSpelling.Margin = new System.Windows.Forms.Padding(3);
            this.wordSpelling.Name = "wordSpelling";
            this.wordSpelling.Size = new System.Drawing.Size(40, 15);
            this.wordSpelling.TabIndex = 2;
            this.wordSpelling.Text = "Word";
            // 
            // wordDefinition
            // 
            this.wordDefinition.AcceptsReturn = true;
            this.wordDefinition.AcceptsTab = true;
            this.wordDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wordDefinition.Location = new System.Drawing.Point(6, 39);
            this.wordDefinition.Multiline = true;
            this.wordDefinition.Name = "wordDefinition";
            this.wordDefinition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wordDefinition.Size = new System.Drawing.Size(160, 45);
            this.wordDefinition.TabIndex = 4;
            this.wordDefinition.TextChanged += new System.EventHandler(this.wordDefinition_TextChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(88, 10);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(78, 23);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Sauvegarder";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // WordPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.wordDefinition);
            this.Controls.Add(this.wordSpelling);
            this.Name = "WordPanel";
            this.Padding = new System.Windows.Forms.Padding(0, 7, 5, 5);
            this.Size = new System.Drawing.Size(174, 105);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label wordSpelling;
        protected System.Windows.Forms.TextBox wordDefinition;
        private System.Windows.Forms.Button saveBtn;
    }
}
