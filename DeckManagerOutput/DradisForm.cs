using System;
using System.Collections;
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


        #region Sector movement

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

        #endregion

        #region components and placement

        private void LaunchComponentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // might not need this event
        }

        private void LaunchLocationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeckManager.Components.Enums.ComponentType token = (DeckManager.Components.Enums.ComponentType)LaunchComponentComboBox.SelectedItem;
            DeckManager.Boards.Dradis.DradisNodeName sector = (DeckManager.Boards.Dradis.DradisNodeName)LaunchLocationComboBox.SelectedItem;
            if (sector != null && token != null)
            {

                switch (sector)
                {
                    case DeckManager.Boards.Dradis.DradisNodeName.Alpha:
                        PlaceComponent(this.alphaListBox, token);
                        break;
                    case DeckManager.Boards.Dradis.DradisNodeName.Bravo:
                        PlaceComponent(this.bravoListBox, token);
                        break;
                    case DeckManager.Boards.Dradis.DradisNodeName.Charlie:
                        PlaceComponent(this.charlieListBox, token);
                        break;
                    case DeckManager.Boards.Dradis.DradisNodeName.Delta:
                        PlaceComponent(this.deltaListBox, token);
                        break;
                    case DeckManager.Boards.Dradis.DradisNodeName.Echo:
                        PlaceComponent(this.echoListBox, token);
                        break;
                    case DeckManager.Boards.Dradis.DradisNodeName.Foxtrot:
                        PlaceComponent(this.foxtrotListBox, token);
                        break;
                }
                LaunchComponentComboBox.SelectedIndex = -1;
                LaunchLocationComboBox.SelectedIndex = -1;
            }
            // todo error checking
        }

        private void PlaceComponent(ListBox sector, DeckManager.Components.Enums.ComponentType token)
        { 
            // do component placement.            
            switch (token)
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
            // todo error handling - no components left?
        }

        private void DestroyComponentsButton_Click(object sender, EventArgs e)
        {
            // tell game manager to destory the component
            var ships = GetSelectedComponents();
            Program.GManager.DestroyComponents(ships);
            RemoveComponentsFromSpace(ships);

            // need to trigger update in parent form after resources etc. are updated.
        }

        private void RecallComponentsButton_Click(object sender, EventArgs e)
        {
            var ships = GetSelectedComponents();
            Program.GManager.DiscardComponents(ships);
            RemoveComponentsFromSpace(ships);
        }

        /// <summary>
        /// Returns a list of all selected components in all sectors of space around Galactica
        /// </summary>
        /// <returns>List of selected components</returns>
        private List<DeckManager.Components.BaseComponent> GetSelectedComponents()
        {
            var ret = alphaListBox.SelectedItems.Cast<DeckManager.Components.BaseComponent>().ToList();
            ret.AddRange(bravoListBox.SelectedItems.Cast<DeckManager.Components.BaseComponent>().ToList());
            ret.AddRange(charlieListBox.SelectedItems.Cast<DeckManager.Components.BaseComponent>().ToList());
            ret.AddRange(deltaListBox.SelectedItems.Cast<DeckManager.Components.BaseComponent>().ToList());
            ret.AddRange(echoListBox.SelectedItems.Cast<DeckManager.Components.BaseComponent>().ToList());
            ret.AddRange(foxtrotListBox.SelectedItems.Cast<DeckManager.Components.BaseComponent>().ToList());
            return ret;
        }

        /// <summary>
        /// Removes the list of ships from the sectors of space around Galactica. Does not affect the GameState.
        /// </summary>
        /// <param name="ships"></param>
        private void RemoveComponentsFromSpace(IEnumerable<DeckManager.Components.BaseComponent> ships)
        {
            foreach (DeckManager.Components.BaseComponent ship in ships)
            {
                if (alphaListBox.Items.Contains(ship))
                    alphaListBox.Items.Remove(ship);
                else if (bravoListBox.Items.Contains(ship))
                    bravoListBox.Items.Remove(ship);
                else if (charlieListBox.Items.Contains(ship))
                    charlieListBox.Items.Remove(ship);
                else if (deltaListBox.Items.Contains(ship))
                    deltaListBox.Items.Remove(ship);
                else if (echoListBox.Items.Contains(ship))
                    echoListBox.Items.Remove(ship);
                else if (foxtrotListBox.Items.Contains(ship))
                    foxtrotListBox.Items.Remove(ship);
            }
        }
        #endregion

        #region Damage tokens

        private void DrawDamageTokenButton_Click(object sender, EventArgs e)
        {
            // todo no damage token representation yet
        }

        private void DiscardDamageTokenButton_Click(object sender, EventArgs e)
        {
            // put damage tokens back in pile
            //var token = (DeckManager.)DrawnDamageTokensListBox.SelectedItem;
            //Program.GManager.DiscardComponent(token);
        }

        private void DamageGalacticaButton_Click(object sender, EventArgs e)
        {
            // apply effects

            // mark token spent

            // remove from listbox
        }

        #endregion


    }
}
