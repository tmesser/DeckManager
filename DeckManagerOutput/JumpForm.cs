using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DeckManager.Cards;

namespace DeckManagerOutput
{
    public partial class JumpForm : Form
    {
        private readonly DestinationCard _destination1;
        private readonly DestinationCard _destination2;
        private readonly DestinationCard _destination3;

        public DestinationCard SelectedCard;
        public int SelectedCardIndex;
        public bool ThirdCardDrawn = false;

        public JumpForm(IEnumerable<DestinationCard> destinationCards)
        {
            var destinationList = destinationCards.ToList();
            if (destinationList.Count() != 3)
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
            _destination1 = destinationList[0];
            _destination2 = destinationList[1];
            _destination3 = destinationList[2];

            InitializeComponent();

            DestinationTextBox1.Text = _destination1.ToString();
            DestinationTextBox2.Text = _destination2.ToString();
        }

        private void DestinationSelectButton1Click(object sender, EventArgs e)
        {
            SelectedCard = _destination1;
            SelectedCardIndex = 0;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DestinationSelectButton2Click(object sender, EventArgs e)
        {
            SelectedCard = _destination2;
            SelectedCardIndex = 1;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DestinationSelectButton3Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DestinationTextBox3.Text))
            {
                DestinationTextBox3.Text = _destination3.ToString();
                DestinationSelectButton3.Text = "Go!";
                ThirdCardDrawn = true;
                return;
            }
            SelectedCard = _destination3;
            SelectedCardIndex = 2;
            DialogResult = DialogResult.OK;
            Close();
        }


    }
}
