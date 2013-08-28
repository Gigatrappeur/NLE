using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NLE.Glossary;

namespace DicoManagement
{
    public partial class WordPanel : UserControl
    {
        protected Word _word;
        public virtual Word word
        {
            get
            {
                return this._word;
            }
            set
            {
                this._word = value;

                this.wordSpelling.Text = "";
                this.wordDefinition.Text = "";

                if (this._word != null)
                {
                    this.wordSpelling.Text = this._word.word.Substring(0, 1).ToUpper() + this._word.word.Substring(1).ToLower();

                    if (this._word.definition != null)
                    {
                        this.wordDefinition.Text = this._word.definition.Replace("\n", Environment.NewLine);
                    }
                }
            }
        }

        public WordPanel()
        {
            InitializeComponent();
        }
    }
}
