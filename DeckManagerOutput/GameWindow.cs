using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeckManager.Boards.Dradis.Enums;
using DeckManager.Boards.Enums;
using DeckManager.Components;
using DeckManager.Components.Enums;
using DeckManager.Extensions;
using DeckManager.States;
using DeckManagerOutput.CustomControls;
using DeckManagerOutput.Properties;
using DeckManager.Cards;

namespace DeckManagerOutput
{
    public partial class GameWindow : Form
    {
        private CrisisCard CurrentCrisis { get; set; }

        public GameWindow()
        {
            InitializeComponent();
        }

        private void NewGameStripMenuItemClick(object sender, EventArgs e)
        {
            var characters = Program.GManager.CharacterList;
            var rosterForm = new PlayerRosterForm(characters);
            rosterForm.ShowDialog();
            if (rosterForm.DialogResult != DialogResult.OK)
                return;
            
            var optionalRulesForm = new OptionalRulesForm();
            optionalRulesForm.ShowDialog();
            if (optionalRulesForm.DialogResult != DialogResult.OK)
                return;

            var firstPlayerDrawIndex = 0;

            var currentPlayer = rosterForm.Players.First();
            if (currentPlayer.Character.DefaultDrawColors.Count > 0)
            {
                var drawForm = new SelectDrawForm(currentPlayer.Character.DefaultDrawColors);
                drawForm.ShowDialog();

                if (drawForm.DialogResult == DialogResult.OK && drawForm.SelectedSkillCardDrawIndex.HasValue)
                    firstPlayerDrawIndex = drawForm.SelectedSkillCardDrawIndex.Value;
            }
            Program.GManager.NewGame(rosterForm.Players, optionalRulesForm.ExtraLoyaltyCards, optionalRulesForm.UsingSympathizer, firstPlayerDrawIndex);

            PlayerReadonlyListBox.BeginUpdate();
            PlayerReadonlyListBox.DataSource = Program.GManager.CurrentGameState.Players;
            PlayerReadonlyListBox.SelectedIndex = 0;
            PlayerReadonlyListBox.EndUpdate();
            
            FoodUpDown.Value = Program.GManager.CurrentGameState.Food;
            FuelUpDown.Value = Program.GManager.CurrentGameState.Fuel;
            MoraleUpDown.Value = Program.GManager.CurrentGameState.Morale;
            PopUpDown.Value = Program.GManager.CurrentGameState.Population;

            managePlayerToolStripMenuItem.DropDownItems.Clear();
            ShowHandMenuItem.DropDownItems.Clear();
            foreach (var player in Program.GManager.CurrentGameState.Players)
            {
                var newMenuItem = new ToolStripMenuItem(player.PlayerName, null, ManagePlayerMenuItemClick);
                var showHandItem = new ToolStripMenuItem(player.PlayerName, null, ShowHandMenuItemClick);
                managePlayerToolStripMenuItem.DropDownItems.Add(newMenuItem);
                ShowHandMenuItem.DropDownItems.Add(showHandItem);
            }

            RefreshGameDataBoxes();

            JumpPrepChanged(sender, e);
        }

        private void DeckInformationMenuItemClick(object sender, EventArgs e)
        {
            var form = new DeckInfo();
            form.ShowDialog();
        }

        private void ShowHandMenuItemClick(object sender, EventArgs e)
        {
            var itemClicked = (ToolStripMenuItem)sender;
            var playerHand = Program.GManager.GetPlayerHand(itemClicked.Text);
            var handString = new StringBuilder();
            foreach (var card in playerHand)
            {
                handString.Append(card);
                handString.Append(Environment.NewLine);
            }
            var form = new HelpForm(handString.ToString(), Resources.GameWindow_ShowHandMenuItemClick_HelpForm_Title);
            form.ShowDialog();
        }

        private void JumpPrepChanged(object sender, EventArgs e)
        {
            if (Red1RadioButton.Checked || Red2RadioButton.Checked || Red3RadioButton.Checked)
            {
                JumpPrepGroupBox.ForeColor = Color.Red;
                JumpPrepGroupBox.Text = Resources.GameWindow_JumpPrepChanged_NoJumping;
                JumpButton.Enabled = false;
            }
            else if (Risk3RadioButton.Checked)
            {
                JumpPrepGroupBox.ForeColor = Color.Goldenrod;
                JumpPrepGroupBox.Text = Resources.GameWindow_JumpPrepChanged_Risk3;
                JumpButton.Enabled = true;
            }
            else if (Risk1RadioButton.Checked)
            {
                JumpPrepGroupBox.ForeColor = Color.Goldenrod;
                JumpPrepGroupBox.Text = Resources.GameWindow_JumpPrepChanged_Risk1;
                JumpButton.Enabled = true;
            }
            else if (JumpNowRadioButton.Checked)
            {
                JumpPrepGroupBox.ForeColor = Color.Green;
                JumpPrepGroupBox.Text = Resources.GameWindow_JumpPrepChanged_JumpNow;
                JumpButton.Enabled = true;
            }
        }

        private void IncreaseJumpPrepToolStripMenuItemClick(object sender, EventArgs e)
        {
            Program.GManager.CurrentGameState.JumpPrep += 1;
            Program.GManager.AddToTurnLog(GetJumpPrepString(true));

            Red1RadioButton.Checked = false;
            Red2RadioButton.Checked = false;
            Red3RadioButton.Checked = false;
            Risk3RadioButton.Checked = false;
            Risk1RadioButton.Checked = false;
            JumpNowRadioButton.Checked = false;

            switch (Program.GManager.CurrentGameState.JumpPrep)
            {
                case 0:
                    Red1RadioButton.Checked = true;
                    break;
                case 1:
                    Red2RadioButton.Checked = true;
                    break;
                case 2:
                    Red3RadioButton.Checked = true;
                    break;
                case 3:
                    Risk3RadioButton.Checked = true;
                    break;
                case 4:
                    Risk1RadioButton.Checked = true;
                    break;
                case 5:
                    JumpNowRadioButton.Checked = true;
                    break;
            }
        }

        private void DecreaseJumpPrepToolStripMenuItemClick(object sender, EventArgs e)
        {
            Program.GManager.CurrentGameState.JumpPrep -= 1;
            Program.GManager.AddToTurnLog(GetJumpPrepString(true));

            Red1RadioButton.Checked = false;
            Red2RadioButton.Checked = false;
            Red3RadioButton.Checked = false;
            Risk3RadioButton.Checked = false;
            Risk1RadioButton.Checked = false;
            JumpNowRadioButton.Checked = false;

            switch (Program.GManager.CurrentGameState.JumpPrep)
            {
                case 0:
                    Red1RadioButton.Checked = true;
                    break;
                case 1:
                    Red2RadioButton.Checked = true;
                    break;
                case 2:
                    Red3RadioButton.Checked = true;
                    break;
                case 3:
                    Risk3RadioButton.Checked = true;
                    break;
                case 4:
                    Risk1RadioButton.Checked = true;
                    break;
                case 5:
                    JumpNowRadioButton.Checked = true;
                    break;
            }
        }

        private static string GetJumpPrepString(bool increase)
        {
            var status = string.Empty;
            switch (Program.GManager.CurrentGameState.JumpPrep)
            {
                case 0:
                    status = Resources.JumpPrep_Red1;
                    break;
                case 1:
                    status = Resources.JumpPrep_Red2;
                    break;
                case 2:
                    status = Resources.JumpPrep_Red3;
                    break;
                case 3:
                    status = Resources.JumpPrep_Risk3;
                    break;
                case 4:
                    status = Resources.JumpPrep_Risk1;
                    break;
                case 5:
                    status = Resources.JumpPrep_AutoJump;
                    break;
            }
            return string.Format(Resources.JumpPrep_Base, ((increase) ? Resources.JumpPrep_Increase : Resources.JumpPrep_Decrease), status);
        }

        private void AlphaToBravoButtonClick(object sender, EventArgs e)
        {
            var selectedItems = AlphaDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Alpha, DradisNodeName.Bravo, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Alpha, DradisNodeName.Bravo, selectedItems);
            RefreshGameDataBoxes();
        }

        private void BravoToAlphaButtonClick(object sender, EventArgs e)
        {
            var selectedItems = BravoDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Bravo, DradisNodeName.Alpha, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Bravo, DradisNodeName.Alpha, selectedItems);
            RefreshGameDataBoxes();
        }

        private void UpdateTurnLogWithMovement(DradisNodeName source, DradisNodeName destination, IEnumerable<BaseComponent> selectedItems)
        {
            var selectedList = selectedItems.ToList();
            if (!selectedList.Any())
                return;
            var raiders = 0;
            var heavies = 0;
            var vipers = 0;
            var civs = 0;

            foreach (var component in selectedList)
            {
                if (component.ComponentType == ComponentType.Raider)
                    raiders++;
                if (component.ComponentType == ComponentType.HeavyRaider)
                    heavies++;
                if (component.ComponentType == ComponentType.Viper)
                    vipers++;
                if (component.ComponentType == ComponentType.Civilian)
                    civs++;
            }

            var movementUpdateString = string.Empty;
            if (raiders > 0)
                movementUpdateString += string.Format("{0} {1}, ", raiders, (raiders == 1) ? ComponentType.Raider.ToString() : ComponentType.Raider.GetStringValue());
            if (heavies > 0)
                movementUpdateString += string.Format("{0} {1}, ", heavies, (heavies == 1) ? ComponentType.HeavyRaider.ToString() : ComponentType.HeavyRaider.GetStringValue());
            if (vipers > 0)
                movementUpdateString += string.Format("{0} {1}, ", vipers, (vipers == 1) ? ComponentType.Viper.ToString() :  ComponentType.Viper.GetStringValue());
            if (civs > 0)
                movementUpdateString += string.Format("{0} {1}, ", civs, (civs == 1) ? ComponentType.Civilian.ToString() : ComponentType.Civilian.GetStringValue());

            movementUpdateString = movementUpdateString.Trim(',', ' ');
            
            Program.GManager.AddToTurnLog(string.Format(Resources.ComponentMovement, movementUpdateString, source, destination));
        }

        private void RefreshGameDataBoxes()
        {
            RaptorReserveLabel.Text = Program.GManager.CurrentRaptors().ToString(CultureInfo.InvariantCulture);

            var selectedIndex = PlayerReadonlyListBox.SelectedIndex;
            PlayerReadonlyListBox.BeginUpdate();
            PlayerReadonlyListBox.DataSource = null;
            PlayerReadonlyListBox.DataSource = Program.GManager.CurrentGameState.Players;
            PlayerReadonlyListBox.SelectedIndex = selectedIndex;
            PlayerReadonlyListBox.EndUpdate();

            AlphaDradisListBox.DataSource = null;
            BravoDradisListBox.DataSource = null;
            CharlieDradisListBox.DataSource = null;
            DeltaDradisListBox.DataSource = null;
            EchoDradisListBox.DataSource = null;
            FoxtrotDradisListBox.DataSource = null;

            AlphaDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.GetComponents(DradisNodeName.Alpha);
            BravoDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.GetComponents(DradisNodeName.Bravo);
            CharlieDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.GetComponents(DradisNodeName.Charlie);
            DeltaDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.GetComponents(DradisNodeName.Delta);
            EchoDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.GetComponents(DradisNodeName.Echo);
            FoxtrotDradisListBox.DataSource = Program.GManager.CurrentGameState.Dradis.GetComponents(DradisNodeName.Foxtrot);

            AlphaDradisListBox.SelectedIndex = -1;
            BravoDradisListBox.SelectedIndex = -1;
            CharlieDradisListBox.SelectedIndex = -1;
            DeltaDradisListBox.SelectedIndex = -1;
            EchoDradisListBox.SelectedIndex = -1;
            FoxtrotDradisListBox.SelectedIndex = -1;

            GalacticaBoardListBox.DataSource = null;
            ColonialOneListBox.DataSource = null;
            CylonBoardListBox.DataSource = null;

            GalacticaBoardListBox.DataSource = Program.GManager.CurrentGameState.Boards.First(x => x.Name == BoardName.Galactica).Locations;
            ColonialOneListBox.DataSource = Program.GManager.CurrentGameState.Boards.First(x => x.Name == BoardName.ColonialOne).Locations;
            CylonBoardListBox.DataSource = Program.GManager.CurrentGameState.Boards.First(x => x.Name == BoardName.Cylon).Locations;

            GalacticaBoardListBox.SelectedIndex = -1;
            ColonialOneListBox.SelectedIndex = -1;
            CylonBoardListBox.SelectedIndex = -1;
        }

        private void BravoToCharlieButtonClick(object sender, EventArgs e)
        {
            var selectedItems = BravoDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Bravo, DradisNodeName.Charlie, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Bravo, DradisNodeName.Charlie, selectedItems);
            RefreshGameDataBoxes();
        }

        private void CharlieToBravoButtonClick(object sender, EventArgs e)
        {
            var selectedItems = CharlieDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Charlie, DradisNodeName.Bravo, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Charlie, DradisNodeName.Bravo, selectedItems);
            RefreshGameDataBoxes();
        }

        private void CharlieToDeltaButtonClick(object sender, EventArgs e)
        {
            var selectedItems = CharlieDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Charlie, DradisNodeName.Delta, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Charlie, DradisNodeName.Delta, selectedItems);
            RefreshGameDataBoxes();
        }

        private void DeltaToCharlieButtonClick(object sender, EventArgs e)
        {
            var selectedItems = DeltaDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Delta, DradisNodeName.Charlie, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Delta, DradisNodeName.Charlie, selectedItems);
            RefreshGameDataBoxes();
        }

        private void DeltaToEchoButtonClick(object sender, EventArgs e)
        {
            var selectedItems = DeltaDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Delta, DradisNodeName.Echo, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Delta, DradisNodeName.Echo, selectedItems);
            RefreshGameDataBoxes();
        }

        private void EchoToDeltaButtonClick(object sender, EventArgs e)
        {
            var selectedItems = EchoDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Echo, DradisNodeName.Delta, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Echo, DradisNodeName.Delta, selectedItems);
            RefreshGameDataBoxes();
        }

        private void EchoToFoxtrotButtonClick(object sender, EventArgs e)
        {
            var selectedItems = EchoDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Echo, DradisNodeName.Foxtrot, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Echo, DradisNodeName.Foxtrot, selectedItems);
            RefreshGameDataBoxes();
        }

        private void FoxtrotToEchoButtonClick(object sender, EventArgs e)
        {
            var selectedItems = FoxtrotDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Foxtrot, DradisNodeName.Echo, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Foxtrot, DradisNodeName.Echo, selectedItems);
            RefreshGameDataBoxes();
        }

        private void FoxtrotToAlphaButtonClick(object sender, EventArgs e)
        {
            var selectedItems = FoxtrotDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Foxtrot, DradisNodeName.Alpha, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Foxtrot, DradisNodeName.Alpha, selectedItems);
            RefreshGameDataBoxes();
        }

        private void AlphaToFoxtrotButtonClick(object sender, EventArgs e)
        {
            var selectedItems = AlphaDradisListBox.SelectedItems.Cast<BaseComponent>().ToList();
            Program.GManager.CurrentGameState.Dradis.MoveComponents(DradisNodeName.Alpha, DradisNodeName.Foxtrot, selectedItems);
            UpdateTurnLogWithMovement(DradisNodeName.Alpha, DradisNodeName.Foxtrot, selectedItems);
            RefreshGameDataBoxes();
        }

        private void AddCenturionToBoardingTrackToolStripMenuItemClick(object sender, EventArgs e)
        {
            Program.GManager.CurrentGameState.CylonBoarding[0] += 1;
            Program.GManager.AddToTurnLog(Resources.CenturionBoardsGalactica);
            RefreshCenturionBoardingTrack();
        }

        private void AdvanceCenturionsToolStripMenuItemClick(object sender, EventArgs e)
        {
            // This is crude-looking, but with a structure of definite length 5 and indexing operations it is just confusing to do anything else.
            var boardingTemp1 = Program.GManager.CurrentGameState.CylonBoarding[0];
            var boardingTemp2 = Program.GManager.CurrentGameState.CylonBoarding[1];
            var boardingTemp3 = Program.GManager.CurrentGameState.CylonBoarding[2];
            var boardingTemp4 = Program.GManager.CurrentGameState.CylonBoarding[3];
            Program.GManager.CurrentGameState.CylonBoarding[0] = 0;
            Program.GManager.CurrentGameState.CylonBoarding[1] = boardingTemp1;
            Program.GManager.CurrentGameState.CylonBoarding[2] = boardingTemp2;
            Program.GManager.CurrentGameState.CylonBoarding[3] = boardingTemp3;
            Program.GManager.CurrentGameState.CylonBoarding[4] = boardingTemp4;
            Program.GManager.AddToTurnLog(Resources.CenturionsAdvance);
            RefreshCenturionBoardingTrack();
        }
        
        private void DestroyFurthestCenturionToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (Program.GManager.CurrentGameState.CylonBoarding[3] > 0)
            {
                Program.GManager.CurrentGameState.CylonBoarding[3] -= 1;
                Program.GManager.AddToTurnLog(Resources.CenturionDestroyed);
                RefreshCenturionBoardingTrack();
                return;
            }

            if (Program.GManager.CurrentGameState.CylonBoarding[2] > 0)
            {
                Program.GManager.CurrentGameState.CylonBoarding[2] -= 1;
                Program.GManager.AddToTurnLog(Resources.CenturionDestroyed);
                RefreshCenturionBoardingTrack();
                return;
            }

            if (Program.GManager.CurrentGameState.CylonBoarding[1] > 0)
            {
                Program.GManager.CurrentGameState.CylonBoarding[1] -= 1;
                Program.GManager.AddToTurnLog(Resources.CenturionDestroyed);
                RefreshCenturionBoardingTrack();
                return;
            }

            if (Program.GManager.CurrentGameState.CylonBoarding[0] > 0)
            {
                Program.GManager.CurrentGameState.CylonBoarding[0] -= 1;
                Program.GManager.AddToTurnLog(Resources.CenturionDestroyed);
                RefreshCenturionBoardingTrack();
            }
        }

        private void RefreshCenturionBoardingTrack()
        {
            CentBoardingTextBox1.Text = Program.GManager.CurrentGameState.CylonBoarding[0].ToString(CultureInfo.InvariantCulture);
            CentBoardingTextBox2.Text = Program.GManager.CurrentGameState.CylonBoarding[1].ToString(CultureInfo.InvariantCulture);
            CentBoardingTextBox3.Text = Program.GManager.CurrentGameState.CylonBoarding[2].ToString(CultureInfo.InvariantCulture);
            CentBoardingTextBox4.Text = Program.GManager.CurrentGameState.CylonBoarding[3].ToString(CultureInfo.InvariantCulture);
            CentBoardingTextBox5.Text = Program.GManager.CurrentGameState.CylonBoarding[4].ToString(CultureInfo.InvariantCulture);
        }

        private void FuelUpDownValueChanged(object sender, EventArgs e)
        {
            Program.GManager.AddToTurnLog(string.Format(Resources.ResourceChanged, Resources.Resource_Fuel, FuelUpDown.Value));
            Program.GManager.CurrentGameState.Fuel = (int)FuelUpDown.Value;
        }

        private void FoodUpDownValueChanged(object sender, EventArgs e)
        {
            Program.GManager.AddToTurnLog(string.Format(Resources.ResourceChanged, Resources.Resource_Food, FoodUpDown.Value));
            Program.GManager.CurrentGameState.Food = (int)FoodUpDown.Value;
        }

        private void MoraleUpDownValueChanged(object sender, EventArgs e)
        {
            Program.GManager.AddToTurnLog(string.Format(Resources.ResourceChanged, Resources.Resource_Morale, MoraleUpDown.Value));
            Program.GManager.CurrentGameState.Morale = (int)MoraleUpDown.Value;
        }

        private void PopUpDownValueChanged(object sender, EventArgs e)
        {
            Program.GManager.AddToTurnLog(string.Format(Resources.ResourceChanged, Resources.Resource_Population, PopUpDown.Value));
            Program.GManager.CurrentGameState.Population = (int)PopUpDown.Value;
        }

        private void DistanceUpDownValueChanged(object sender, EventArgs e)
        {
            Program.GManager.AddToTurnLog(string.Format(Resources.ResourceChanged, Resources.Resource_Distance, DistanceUpDown.Value));
            Program.GManager.CurrentGameState.Distance = (int)DistanceUpDown.Value;
        }

        private void DrawCrisisToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentCrisis = Program.GManager.CurrentGameState.CrisisDeck.Draw();
            crisisText.Text = CurrentCrisis.Heading + Environment.NewLine + CurrentCrisis.AdditionalText;
        }

        private void BuryTopToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (CurrentCrisis != null)
            {
                Program.GManager.CurrentGameState.CrisisDeck.Bury(CurrentCrisis);
                CurrentCrisis = null;
                crisisText.Text = string.Empty;
            }
            else
                MessageBox.Show(Resources.GameWindow_buryTopToolStripMenuItem_SelectCrisisBeforeBury);
        }

        private void DrawMultipleToolStripMenuItemClick(object sender, EventArgs e)
        {
            var inputForm = new InputForm("Input the number of Crises to draw", "Draw Crises");
            inputForm.ShowDialog();
            if(inputForm.DialogResult == DialogResult.OK)
            {
                var numCrises = inputForm.UserInput.ParseAs<int>();
                if (numCrises == 0)
                {
                    MessageBox.Show(Resources.GameWindow_drawMultipleToolStripMenuItem_InputMoreThanZero);
                    return;
                }
                var crisisCards = Program.GManager.CurrentGameState.CrisisDeck.DrawMany(numCrises).ToList();
                var crisisManagementForm = new CrisisManagementForm(crisisCards);
                crisisManagementForm.ShowDialog();
                if (crisisManagementForm.DialogResult == DialogResult.OK)
                {
                    foreach (var decision in crisisManagementForm.Decisions.OrderByDescending(x => x.Order))
                    {
                        switch(decision.Action)
                        {
                            case CrisisAction.Replace:
                                Program.GManager.CurrentGameState.CrisisDeck.Top(decision.Crisis);
                                break;
                            case CrisisAction.Draw:
                                CurrentCrisis = decision.Crisis;
                                crisisText.Text = CurrentCrisis.Heading + Environment.NewLine + CurrentCrisis.AdditionalText;
                                break;
                            case CrisisAction.Bury:
                                Program.GManager.CurrentGameState.CrisisDeck.Bury(CurrentCrisis);
                                CurrentCrisis = null;
                                crisisText.Text = string.Empty;
                                break;
                        }
                    }
                }
                else
                {
                    crisisCards.Reverse();
                    foreach (var crisisCard in crisisCards)
                    {
                        Program.GManager.CurrentGameState.CrisisDeck.Top(crisisCard);
                    }
                }
            }
        }

        private void SaveGameStripMenuItemClick(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = Resources.GameWindow_SavedGamesFilter
            };
            if(saveDialog.ShowDialog() == DialogResult.OK)
            {
                Program.GManager.SaveGame(saveDialog.FileName);
            }            
        }

        private void LoadGameStripMenuItemClick(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog {Filter = Resources.GameWindow_SavedGamesFilter};
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Program.GManager.LoadGame(openDialog.FileName);   

                PlayerReadonlyListBox.BeginUpdate();
                PlayerReadonlyListBox.DataSource = Program.GManager.CurrentGameState.Players;
                PlayerReadonlyListBox.SelectedIndex = 0;
                PlayerReadonlyListBox.EndUpdate();

                FoodUpDown.Value = Program.GManager.CurrentGameState.Food;
                FuelUpDown.Value = Program.GManager.CurrentGameState.Fuel;
                MoraleUpDown.Value = Program.GManager.CurrentGameState.Morale;
                PopUpDown.Value = Program.GManager.CurrentGameState.Population;
                DistanceUpDown.Value = Program.GManager.CurrentGameState.Distance;

                RefreshGameDataBoxes();

                managePlayerToolStripMenuItem.DropDownItems.Clear();
                ShowHandMenuItem.DropDownItems.Clear();
                foreach (var player in Program.GManager.CurrentGameState.Players)
                {
                    var newMenuItem = new ToolStripMenuItem(player.PlayerName, null, ManagePlayerMenuItemClick);
                    var showHandItem = new ToolStripMenuItem(player.PlayerName, null, ShowHandMenuItemClick);
                    managePlayerToolStripMenuItem.DropDownItems.Add(newMenuItem);
                    ShowHandMenuItem.DropDownItems.Add(showHandItem);
                }

                JumpPrepChanged(sender, e);
            }
        }

        private void PlayCrisisButtonClick(object sender, EventArgs e)
        {
            if (CurrentCrisis == null || CurrentCrisis.PassLevels.Any() == false) 
                return;

            var destinyDraw = Program.GManager.DrawDestiny(2).ToList();

            var form = new PlayCrisisForm(Program.GManager.CurrentGameState.Players, CurrentCrisis, destinyDraw, Program.GManager.SkillCheckRules);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                Program.GManager.TopCards(destinyDraw, true);
                return;
            }

            if (form.PlayerTakingCards == null)
            {
                foreach (var contribution in form.CrisisContributions)
                    Program.GManager.DiscardCard(contribution.Item1, Program.GManager.FindPlayerByName(contribution.Item2));
            }
            else 
            {
                foreach (var contribution in form.CrisisContributions)
                    Program.GManager.GiveCardToPlayer(form.PlayerTakingCards, contribution.Item1, Program.GManager.FindPlayerByName(contribution.Item2));
            }           

            Program.GManager.DiscardCard(CurrentCrisis);
            
            var helpForm = new HelpForm(form.Result, "Crisis Result");
            helpForm.Show();
            PlayerReadonlyListBox.BeginUpdate();
            PlayerReadonlyListBox.DataSource = null;
            PlayerReadonlyListBox.DataSource = Program.GManager.CurrentGameState.Players;
            PlayerReadonlyListBox.SelectedIndex = 0;
            PlayerReadonlyListBox.EndUpdate();
        }

        private void RemoveSelectedToolStripMenuItemClick(object sender, EventArgs e)
        {
            foreach (var component in AlphaDradisListBox.SelectedItems.OfType<BaseComponent>())
            {
                Program.GManager.CurrentGameState.Dradis.RemoveComponent(component);
            }
            foreach (var component in BravoDradisListBox.SelectedItems.OfType<BaseComponent>())
            {
                Program.GManager.CurrentGameState.Dradis.RemoveComponent(component);
            }
            foreach (var component in CharlieDradisListBox.SelectedItems.OfType<BaseComponent>())
            {
                Program.GManager.CurrentGameState.Dradis.RemoveComponent(component);
            }
            foreach (var component in DeltaDradisListBox.SelectedItems.OfType<BaseComponent>())
            {
                Program.GManager.CurrentGameState.Dradis.RemoveComponent(component);
            }
            foreach (var component in EchoDradisListBox.SelectedItems.OfType<BaseComponent>())
            {
                Program.GManager.CurrentGameState.Dradis.RemoveComponent(component);
            }
            foreach (var component in FoxtrotDradisListBox.SelectedItems.OfType<BaseComponent>())
            {
                Program.GManager.CurrentGameState.Dradis.RemoveComponent(component);
            }
            RefreshGameDataBoxes();
        }

        private void AddToolStripMenuItemClick(object sender, EventArgs e)
        {
            var componentForm = new AddComponentForm();
            componentForm.ShowDialog();
            if (componentForm.DialogResult != DialogResult.OK) 
                return;
            foreach (var request in componentForm.RequestedComponents)
            {
                Program.GManager.PlaceComponent(request.Item1, request.Item2);
            }

            RefreshGameDataBoxes();
        }

        private void ManagePlayerMenuItemClick(object sender, EventArgs e)
        {
            var itemClicked = (ToolStripMenuItem) sender;
            var selectedPlayer = Program.GManager.CurrentGameState.Players.FirstOrDefault(x => x.PlayerName == itemClicked.Text);
            if (selectedPlayer == default(Player))
            {
                MessageBox.Show(Resources.ManagePlayer_ClickedPlayerNotFound);
                return;
            }
            var locations = new List<string>();
            foreach (var board in Program.GManager.CurrentGameState.Boards)
            {
                locations.Add(string.Format("---{0}---", board.Name));
                locations.AddRange(board.Locations.Select(x => x.Name));
            }

            var playerLocation = Program.GManager.GetPlayerLocation(selectedPlayer);
            var playerLocationString = playerLocation == null ? string.Empty : playerLocation.Name;

            var availableViper = Program.GManager.CurrentGameState.Vipers.FindIndex(x => x.Status == ComponentStatus.InReserve);
            var applicableDradisNode = Program.GManager.CurrentGameState.Dradis.Nodes.FirstOrDefault(x => x.Name == playerLocationString);
            if (availableViper != -1 || applicableDradisNode != default(DeckManager.Boards.BaseNode))
            {
                locations.Add(string.Format("---{0}---", "Dradis"));
                locations.AddRange(Program.GManager.CurrentGameState.Dradis.Nodes.Select(x => x.Name));
            }


            var form = new PlayerManagementForm(selectedPlayer, locations, playerLocationString);

            form.ShowDialog();
            if (form.DialogResult != DialogResult.OK)
                return;

            Program.GManager.SetPlayerLocation(form.RequestedLocation, selectedPlayer.PlayerName);
            Program.GManager.DiscardCards(form.CardsToDiscard, selectedPlayer);
            selectedPlayer.OncePerGamePower = form.OpgStatus;

            if (form.RequestedSkillCards.Item2 > 0) // Skill cards requested
                Program.GManager.DrawSkillCards(form.RequestedSkillCards.Item1, form.RequestedSkillCards.Item2, selectedPlayer);

            if (form.RequestedSpecialCards.Item2 > 0) // Special cards requested
                Program.GManager.DrawCards(form.RequestedSpecialCards.Item1, form.RequestedSpecialCards.Item2, selectedPlayer);

            RefreshGameDataBoxes();
        }
        
        private void PassTurnButtonClick(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Resources.GameWindow_PassTurnButtonClick_PassTurnInfo, Resources.GameWindow_PassTurnButtonClick_PassTurnTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if(PlayerReadonlyListBox.SelectedIndex == (PlayerReadonlyListBox.Items.Count - 1))
                    PlayerReadonlyListBox.SelectedIndex = 0;
                else
                    PlayerReadonlyListBox.SelectedIndex += 1;
                    

                Program.GManager.AddToTurnLog(String.Format("The turn passes to {0}!", PlayerReadonlyListBox.SelectedItem));

                System.IO.Directory.CreateDirectory("save\\");

                Program.GManager.SaveGame(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "save\\" + DateTime.Now.ToString(@"M-d-yyyy-hh_mm_ss-tt") + ".bsg"));

                var turnRecord = new HelpForm(Program.GManager.GetTurnLog(), "Turn log");
                turnRecord.Show();
                Program.GManager.EndTurn();

                var currentPlayer = (Player)PlayerReadonlyListBox.SelectedItem;
                if (currentPlayer.Character.DefaultDrawColors.Count > 0)
                {
                    var drawForm = new SelectDrawForm(currentPlayer.Character.DefaultDrawColors);
                    drawForm.ShowDialog();

                    if(drawForm.DialogResult == DialogResult.OK && drawForm.SelectedSkillCardDrawIndex.HasValue)
                        Program.GManager.DoPlayerDraw(currentPlayer, drawForm.SelectedSkillCardDrawIndex.Value);

                    RefreshGameDataBoxes();
                }
            }
        }

        private void JumpButtonClick(object sender, EventArgs e)
        {
            var destinationCards = Program.GManager.CurrentGameState.DestinationDeck.DrawMany(3).ToList();
            var jumpForm = new JumpForm(destinationCards);
            jumpForm.ShowDialog();
            if (jumpForm.DialogResult == DialogResult.OK)
            {
                var tabPage = new TabPage(jumpForm.SelectedCard.Heading);
                var textBox = new TextBox 
                {
                    BackColor = SystemColors.Control, 
                    BorderStyle = BorderStyle.FixedSingle, 
                    Dock = DockStyle.Fill, 
                    Multiline = true, 
                    ScrollBars = ScrollBars.Vertical,
                    Text = jumpForm.SelectedCard.AdditionalText
                };
                tabPage.Controls.Add(textBox);
                if (DestinationTabControl.Controls[0].Name == "DefaultTab")
                    DestinationTabControl.Controls.RemoveAt(0);
                DestinationTabControl.TabPages.Add(tabPage);
                Program.GManager.AddToTurnLog("The fleet jumps!  Destination: " + jumpForm.SelectedCard);
                Program.GManager.CurrentGameState.JumpPrep = 0;
                Program.GManager.WipeDradis();
                RefreshGameDataBoxes();
                Red1RadioButton.Checked = true;
                JumpPrepChanged(sender, e);
                if (jumpForm.ThirdCardDrawn)
                    Program.GManager.BuryCards(destinationCards);
                else
                {
                    Program.GManager.BuryCards(destinationCards.Take(2));
                    Program.GManager.TopCard(destinationCards.Last());
                }
            }
            else
            {
                destinationCards.Reverse();
                Program.GManager.TopCards(destinationCards);
            }
        }

        private void RollDiceButtonClick(object sender, EventArgs e)
        {
            var rand = new Random();
            var result = rand.Next(1, 9);

            Program.GManager.AddToTurnLog("Rolling D8!  Result: " + result);

            DiceRollTextBox.Text = result.ToString(CultureInfo.InvariantCulture);
        }

        private void ShowTurnLogToolStripMenuItemClick(object sender, EventArgs e)
        {
            var helpForm = new HelpForm(Program.GManager.CurrentGameState.TurnLog, "Turn Log");
            helpForm.Show();
        }

        private void DestroyRaptorToolStripMenuItemClick(object sender, EventArgs e)
        {
            Program.GManager.DestroyRaptor();
            RefreshGameDataBoxes();
        }

        private void ProduceRaptorToolStripMenuItemClick(object sender, EventArgs e)
        {
            Program.GManager.ProduceRaptor();
            RefreshGameDataBoxes();
        }
    }
}
