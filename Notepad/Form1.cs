using System;
using System.Windows.Forms;

using System.IO;

namespace Notepad
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes to Untitled?", "Notepad",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                TextBox.Clear();
            }
            
            if (result == DialogResult.Yes)
            {
                //Save Dialoug Box
               SaveFileDialog savefileDialog1 = new SaveFileDialog();
               savefileDialog1.ShowDialog();
               using (Stream s = File.Open(savefileDialog1.FileName, FileMode.CreateNew))
               using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(TextBox.Text);
                }
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDialog1 = new OpenFileDialog();
            openfileDialog1.ShowDialog();
            //need to add error control
            StreamReader read = new StreamReader(File.OpenRead(openfileDialog1.FileName));
            TextBox.Text = read.ReadToEnd();
            read.Dispose();
        }

        private void Notepad_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 0.0.0.1 (Build 1) © 2015 Thomas Chaplin. All rights reserved. Notepad is protected by trademark and other pending or existing interllectual property rights in the United Kingdom and other countries/regions. This product is licensed under the EULA to: Thomas Chaplin ","Version Number");
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Text = DateTime.Now.ToString();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Undo();
            // need to look at doing TextBox.CanUndo(); with IF statement
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            var result = MessageBox.Show("Do you want to save changes to Untitled?", "Notepad",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                Application.Exit();
            }

            if (result == DialogResult.Yes)
            {
                //Save Dialoug Box
                SaveFileDialog savefileDialog1 = new SaveFileDialog();
                savefileDialog1.ShowDialog();
                using (Stream s = File.Open(savefileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(TextBox.Text);
                }
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Redo();
            // need to look at doing TextBox.CanRedo(); with IF statement
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //public sealed class PrintDialoug : CommonDialog
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TextBox.Find();
        }
    }
}
