namespace DicoManagement
{
    partial class VerbPanel
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
            this.conjugatedTablesWrapper = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // wordSpelling
            // 
            this.wordSpelling.Size = new System.Drawing.Size(36, 18);
            this.wordSpelling.Text = "Verb";
            // 
            // conjugatedTablesWrapper
            // 
            this.conjugatedTablesWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.conjugatedTablesWrapper.Location = new System.Drawing.Point(0, 72);
            this.conjugatedTablesWrapper.Name = "conjugatedTablesWrapper";
            this.conjugatedTablesWrapper.Size = new System.Drawing.Size(174, 43);
            this.conjugatedTablesWrapper.TabIndex = 4;
            // 
            // VerbPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.conjugatedTablesWrapper);
            this.Name = "VerbPanel";
            this.Size = new System.Drawing.Size(174, 115);
            this.Controls.SetChildIndex(this.wordSpelling, 0);
            this.Controls.SetChildIndex(this.wordDefinition, 0);
            this.Controls.SetChildIndex(this.conjugatedTablesWrapper, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel conjugatedTablesWrapper;
    }
}
