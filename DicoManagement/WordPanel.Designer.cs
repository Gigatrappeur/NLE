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
            this.SuspendLayout();
            // 
            // wordSpelling
            // 
            this.wordSpelling.AutoSize = true;
            this.wordSpelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordSpelling.Location = new System.Drawing.Point(3, 3);
            this.wordSpelling.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.wordSpelling.Name = "wordSpelling";
            this.wordSpelling.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.wordSpelling.Size = new System.Drawing.Size(40, 18);
            this.wordSpelling.TabIndex = 2;
            this.wordSpelling.Text = "Word";
            // 
            // wordDefinition
            // 
            this.wordDefinition.AcceptsReturn = true;
            this.wordDefinition.AcceptsTab = true;
            this.wordDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wordDefinition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wordDefinition.Location = new System.Drawing.Point(6, 24);
            this.wordDefinition.Multiline = true;
            this.wordDefinition.Name = "wordDefinition";
            this.wordDefinition.ReadOnly = true;
            this.wordDefinition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wordDefinition.Size = new System.Drawing.Size(165, 43);
            this.wordDefinition.TabIndex = 4;
            // 
            // WordPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wordDefinition);
            this.Controls.Add(this.wordSpelling);
            this.Name = "WordPanel";
            this.Size = new System.Drawing.Size(174, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label wordSpelling;
        protected System.Windows.Forms.TextBox wordDefinition;
    }
}
