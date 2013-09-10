using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeckManagerOutput
{
    public partial class DeckCreator : Form
    {
        public DeckCreator()
        {
            InitializeComponent();
            // how to handle multiple card types? panel for each type?
        }

        private void newDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddToDeckButton_Click(object sender, EventArgs e)
        {
            // create a new card instance and add it to the listbox
        }

        private void RemoveFromDeckButton_Click(object sender, EventArgs e)
        {
            // remove the selected cards from the listbox
        }

        private void ClearFieldsButton_Click(object sender, EventArgs e)
        {
            // clear all fields 
        }

        private void DeckListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DeckListBox_MouseDoubleClick(object sender, EventArgs e)
        {
            CardFieldsPanel.Visible = false;
        }
    }
}
