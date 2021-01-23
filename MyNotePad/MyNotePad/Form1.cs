using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MyNotePad app was created by Yev in C#. \nCheck out my https://github.com/almightYev/C-Practice. \n");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                MainPage.SelectionFont = fd.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                MainPage.SelectionColor = cd.Color;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPage.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainPage.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                MainPage.Text += Clipboard.GetText(TextDataFormat.Text).ToString();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPage.SelectedText = "";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPage.Undo();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openf = new OpenFileDialog();
            openf.Title = "Open a new file";
            openf.Filter = ".txt(NotePad Files) | *.text";
            if(openf.ShowDialog() == DialogResult.OK)
            {
                Form1 openForm = new Form1();
                StreamReader reader = new StreamReader(openf.FileName);
                openForm.MainPage.Text = reader.ReadToEnd();
                openForm.Show();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MainPage.Text != null)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Tag = "Save your file";
                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(saveFile.FileName + ".txt");
                    writer.WriteLine(MainPage.Text);
                    MessageBox.Show("Saved");
                }
            }
            else
            {
                MessageBox.Show("File is empty");
            }
        }

        private void MainPage_TextChanged(object sender, EventArgs e)
        {
            Letterslbl.Text = "Letters: " + MainPage.Text.Length.ToString();

            string[] wordsCount = MainPage.Text.Trim().Split(' ');
            Wordslbl.Text = "Words: " + wordsCount.Length.ToString();
        }
    }
}
