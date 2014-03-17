﻿using System;
using System.Windows.Forms;
using DeckManager.Cards.Enums;

namespace DeckManagerOutput.CustomControls
{
    // This is super bad design since I have another control that does exactly this, but I'm months overdue on this project and I just want it done at this point.
    public partial class DrawSpecialComboControl : UserControl
    {
        public int NumCardsRequested
        {
            get { return DrawCardsCheckBox.Enabled ? (int) DrawAmountComboBox.SelectedValue : 0; }
        }

        public CardType CardTypeRequested 
        {
            get { return DrawCardsCheckBox.Enabled ? (CardType)Enum.Parse(typeof(CardType), (string)DrawTypeComboBox.SelectedValue) : 0; }
        }

        public DrawSpecialComboControl()
        {
            InitializeComponent();
        }

        private void DrawCardsCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            DrawAmountComboBox.Enabled = DrawCardsCheckBox.Checked;
            DrawTypeComboBox.Enabled = DrawCardsCheckBox.Checked;
        }
    }
}
