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
    public partial class DradisForm : Form
    {
        protected MainForm parent { get; private set; }

        public DradisForm(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;

            var values = Enum.GetValues(typeof(DeckManager.Components.Enums.ComponentType));
            foreach (DeckManager.Components.Enums.ComponentType type in values)
            { 
                if (type == DeckManager.Components.Enums.ComponentType.Unknown) 
                    continue;
                this.LaunchComponentComboBox.Items.Add(type);
            }
            values = Enum.GetValues(typeof(DeckManager.Boards.Dradis.DradisNodeName));
            foreach (DeckManager.Boards.Dradis.DradisNodeName sector in values)
            {
                if (sector == DeckManager.Boards.Dradis.DradisNodeName.Unknown) 
                    continue;
                this.LaunchLocationComboBox.Items.Add(sector);
            }
        }

        private void MoveComponent(ListBox source, ListBox dest, DeckManager.Components.BaseComponent item)
        {
            source.BeginUpdate();
            dest.BeginUpdate();

            source.Items.Remove(item);
            dest.Items.Add(item);

            source.EndUpdate();
            dest.EndUpdate();
            // todo add rollback on error checking?
        }

        private void AtoBButton_Click(object sender, EventArgs e)
        {
            DeckManager.Components.BaseComponent item = (DeckManager.Components.BaseComponent)alphaListBox.SelectedItem;
            MoveComponent(alphaListBox, bravoListBox, item);
        }

        private void BtoAButton_Click(object sender, EventArgs e)
        {
            DeckManager.Components.BaseComponent item = (DeckManager.Components.BaseComponent)alphaListBox.SelectedItem;
            MoveComponent(bravoListBox, alphaListBox, item);
        }

        private void BtoCButton_Click(object sender, EventArgs e)
        {
            DeckManager.Components.BaseComponent item = (DeckManager.Components.BaseComponent)alphaListBox.SelectedItem;
            MoveComponent(bravoListBox, charlieListBox, item);
        }

        private void CtoBButton_Click(object sender, EventArgs e)
        {
            DeckManager.Components.BaseComponent item = (DeckManager.Components.BaseComponent)alphaListBox.SelectedItem;
            MoveComponent(charlieListBox, bravoListBox, item);
        }

        private void CtoDButton_Click(object sender, EventArgs e)
        {
            DeckManager.Components.BaseComponent item = (DeckManager.Components.BaseComponent)alphaListBox.SelectedItem;
            MoveComponent(charlieListBox, deltaListBox, item);
        }

        private void DtoCButton_Click(object sender, EventArgs e)
        {
            DeckManager.Components.BaseComponent item = (DeckManager.Components.BaseComponent)alphaListBox.SelectedItem;
            MoveComponent(deltaListBox, charlieListBox, item);
        }

        private void DtoEButton_Click(object sender, EventArgs e)
        {
            DeckManager.Components.BaseComponent item = (DeckManager.Components.BaseComponent)alphaListBox.SelectedItem;
            MoveComponent(deltaListBox, echoListBox, item);
        }

        private void EtoDButton_Click(object sender, EventArgs e)
        {
            DeckManager.Components.BaseComponent item = (DeckManager.Components.BaseComponent)alphaListBox.SelectedItem;
            MoveComponent(echoListBox, deltaListBox, item);
        }

        private void EtoFButton_Click(object sender, EventArgs e)
        {
            DeckManager.Components.BaseComponent item = (DeckManager.Components.BaseComponent)alphaListBox.SelectedItem;
            MoveComponent(echoListBox, foxtrotListBox, item);
        }

        private void FtoEButton_Click(object sender, EventArgs e)
        {
            DeckManager.Components.BaseComponent item = (DeckManager.Components.BaseComponent)alphaListBox.SelectedItem;
            MoveComponent(foxtrotListBox, echoListBox, item);
        }

        private void FtoAButton_Click(object sender, EventArgs e)
        {
            DeckManager.Components.BaseComponent item = (DeckManager.Components.BaseComponent)alphaListBox.SelectedItem;
            MoveComponent(foxtrotListBox, alphaListBox, item);
        }

        private void LaunchComponentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // these won't work yet - no way to gamemanager does not have draw/destroy/discard component logic yet
            var component = LaunchComponentComboBox.SelectedItem.GetType().ToString();
            var comptype = (DeckManager.Components.Enums.ComponentType)LaunchComponentComboBox.SelectedItem;
            switch (comptype)
            {
                case DeckManager.Components.Enums.ComponentType.Civilian:
                    //var ship = Program.GManager.DrawCivilianShip();
                    break;
                case DeckManager.Components.Enums.ComponentType.Basestar:
                    break;
                case DeckManager.Components.Enums.ComponentType.HeavyRaider:
                    break;
                case DeckManager.Components.Enums.ComponentType.Raider:
                    break;
                case DeckManager.Components.Enums.ComponentType.Viper:
                    break;
            }
        }

        private void LaunchLocationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DeckManager.Components.BaseComponent selected = (DeckManager.Components.BaseComponent)LaunchComponentComboBox.SelectedItem;
            //DeckManager.Boards.Dradis.DradisNodeName sector = (DeckManager.Boards.Dradis.DradisNodeName)LaunchLocationComboBox.SelectedItem;
            //switch (sector)
            //{
            //    case DeckManager.Boards.Dradis.DradisNodeName.Alpha:
            //        alphaListBox.Items.Add(selected);
            //        break;
            //    case DeckManager.Boards.Dradis.DradisNodeName.Bravo:
            //        bravoListBox.Items.Add(selected); ;
            //        break;
            //    case DeckManager.Boards.Dradis.DradisNodeName.Charlie:
            //        charlieListBox.Items.Add(selected);
            //        break;
            //    case DeckManager.Boards.Dradis.DradisNodeName.Delta:
            //        deltaListBox.Items.Add(selected);
            //        break;
            //    case DeckManager.Boards.Dradis.DradisNodeName.Echo:
            //        echoListBox.Items.Add(selected);
            //        break;
            //    case DeckManager.Boards.Dradis.DradisNodeName.Foxtrot:
            //        foxtrotListBox.Items.Add(selected);
            //        break;
            //}
            LaunchComponentComboBox.SelectedIndex = -1;
            LaunchLocationComboBox.SelectedIndex = -1;
        }

        private void DrawDamageTokenButton_Click(object sender, EventArgs e)
        {
            // todo no damage token representation yet
        }

        private void DiscardDamageTokenButton_Click(object sender, EventArgs e)
        {
            // put damage tokens back in pile
        }

        private void DamageGalacticaButton_Click(object sender, EventArgs e)
        {
            // apply effects

            // mark token spent

            // remove from listbox
        }

        private void DestroyComponentsButton_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Returns a list of all selected components in all sectors of space around Galactica
        /// </summary>
        /// <returns>List of selected components</returns>
        private List<DeckManager.Components.BaseComponent> GetSelectedComponents()
        {
            throw new NotImplementedException();
        }


    }
}
