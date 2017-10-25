using J3QQ4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bonkers
{
    public partial class Form1 : Form
    {
        private Boolean fristClick = true;

        private List<Button> listaAktywnychPrzyciskow = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Input_TextChanged_1(object sender, EventArgs e)
        {
            string text = Input.Text;

            Char[] array = text.ToCharArray();
            for (int i = 0; i < listaAktywnychPrzyciskow.Count; i++)
            {
                Button przycisk = listaAktywnychPrzyciskow[i];

                if (przycisk.BackColor == SystemColors.ActiveBorder)
                {
                    Char[] literkaLowerCase = przycisk.Text.ToLower().ToCharArray();
                    Char[] literkaUpperCase = przycisk.Text.ToCharArray();

                    foreach (Char c in array)
                    {
                        if (c == literkaLowerCase[0] || c == literkaUpperCase[0])
                        {
                            text = text.Replace(literkaLowerCase[0].ToString(), Emoji.B).Replace(literkaUpperCase[0].ToString(), Emoji.B);
                        }
                    }
                }

                Output.Text = text;
                this.Output.Select(0, 15566);
                this.Output.SelectionColor = Color.Black;
                this.CheckKeyword(Emoji.B, Color.Red, 0);
            }
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.Output.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.Output.SelectionStart;

                while ((index = this.Output.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.Output.Select((index + startIndex), word.Length);
                    this.Output.SelectionColor = color;
                }
            }
        }

        private void Input_DoubleClick_1(object sender, EventArgs e)
        {
            Input.Text = "";
        }

        private void Output_TextChanged(object sender, EventArgs e)
        {
        }

        private void Input_Click(object sender, EventArgs e)
        {
            if (fristClick)
            {
                Input.Text = "";
                fristClick = false;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var przycisk = sender as Button;

            if (przycisk.BackColor == SystemColors.Control)
            {
                przycisk.BackColor = SystemColors.ActiveBorder;
                listaAktywnychPrzyciskow.Add(przycisk);
            }
            else
            {
                przycisk.BackColor = SystemColors.Control;
                listaAktywnychPrzyciskow.Remove(przycisk);
            }
        }
    }
}