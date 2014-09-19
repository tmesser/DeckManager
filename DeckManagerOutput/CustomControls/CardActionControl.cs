using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeckManagerOutput.CustomControls
{
    public partial class CardActionControl : UserControl
    {
        
        public CardActionControl()
        {
            InitializeComponent();
            var dataList = Enum.GetValues(typeof(CardAction)).Cast<CardAction>().Skip(1).ToList();
            cardActionComboBox.DataSource = dataList;
        }

        public CardAction GetSelectedAction()
        {
            if (actionCheckbox.Checked)
                return (CardAction)cardActionComboBox.SelectedValue;
            return CardAction.None;
        }
    }
}
