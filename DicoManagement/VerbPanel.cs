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
    public partial class VerbPanel : WordPanel
    {
        public VerbPanel()
        {
            InitializeComponent();
        }

        public override NLE.Glossary.Word word
        {
            get
            {
                return base.word;
            }
            set
            {
                if (value is Verb)
                {
                    base.word = value;

                    this.conjugatedTablesWrapper.Controls.Clear();
                    this.conjugatedTablesWrapper.Top = this.wordDefinition.Top + (this.wordDefinition.Text != "" ? this.wordDefinition.Height : 0) + this.wordDefinition.Margin.Bottom + this.conjugatedTablesWrapper.Margin.Top;
                    this.conjugatedTablesWrapper.Height = this.Height - this.conjugatedTablesWrapper.Top;


                    foreach (var table in (this.word as InfinitiveVerb).conjugationTables)
                    {
                        // 
                        // tenseGroup
                        // 
                        GroupBox tenseGroup = new GroupBox();
                        tenseGroup.AutoSize = true;
                        //tenseGroup.Location = new System.Drawing.Point(6, nextY);
                        tenseGroup.Padding = new Padding(0, 0, 10, 0);
                        tenseGroup.TabIndex = 1;
                        tenseGroup.TabStop = false;
                        tenseGroup.Text = Utils.firstLetterToUpper(table.Key);
                        tenseGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                        this.conjugatedTablesWrapper.Controls.Add(tenseGroup);


                        // 
                        // listConjugatedVerb
                        // 
                        TableLayoutPanel listConjugatedVerb = new TableLayoutPanel();
                        listConjugatedVerb.AutoSize = true;
                        listConjugatedVerb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                        listConjugatedVerb.ColumnCount = 2;
                        listConjugatedVerb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        listConjugatedVerb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        listConjugatedVerb.Location = new System.Drawing.Point(6, 19);
                        listConjugatedVerb.Padding = new Padding(0);
                        listConjugatedVerb.Margin = new Padding(0);
                        listConjugatedVerb.RowCount = table.Value.Count;
                        listConjugatedVerb.TabIndex = 0;
                        tenseGroup.Controls.Add(listConjugatedVerb);


                        RowStyle rs = null;
                        int i = 0;
                        foreach (var person in table.Value)
                        {
                            // 
                            // label person
                            // 
                            Label p = new Label();
                            p.AutoSize = true;
                            p.Margin = new Padding(3, 3, 3, 0);
                            p.TabIndex = 0;
                            p.Text = person.Key.personal_pronoun;
                            listConjugatedVerb.Controls.Add(p, 0, i); // ajout du control

                            // 
                            // textBox conjugated verb
                            // 
                            TextBox cv = new TextBox();
                            cv.AutoSize = true;
                            cv.Margin = new Padding(0);
                            cv.TabIndex = 1;
                            cv.Text = person.Value.word;
                            listConjugatedVerb.Controls.Add(cv, 1, i); // ajout du control


                            // ajout style pour la ligne
                            rs = new System.Windows.Forms.RowStyle();
                            rs.Height = 22;
                            rs.SizeType = SizeType.Absolute;
                            listConjugatedVerb.RowStyles.Add(rs);


                            i++;
                        }

                        if (rs != null) // pour le style de la dernière ligne
                            rs.Height = 20;

                        //nextY += tenseGroup.Height;
                    }
                }
                else
                {
                    base.word = null;
                }
            }
        }
    }
}
