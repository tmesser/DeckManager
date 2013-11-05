using DeckManager.Cards;
using DeckManagerOutput.CustomControls;
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
    public partial class CrisisManagementForm : Form
    {
        public CrisisManagementForm(IEnumerable<CrisisCard> crises)
        {
            foreach (var crisis in crises)
            {
                contentPanel.Controls.Add(new CrisisManagementControl(crisis));
            }
            InitializeComponent();
        }
    }
}
