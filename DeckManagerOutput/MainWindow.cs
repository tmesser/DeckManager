using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeckManager;
using DeckManager.States;
using DeckManagerOutput;

namespace DeckManagerOutput
{
    public partial class MainForm : Form
    {
        private readonly MainMenu _mainMenu;
        private DradisForm dradis;
        

        public MainForm()
        {
            InitializeComponent();
            _mainMenu = new MainMenu();
            _mainMenu.MenuItems.Add(new MenuItem("Game"));
            Menu = _mainMenu;

            dradis = new DradisForm(this);

            // todo need some way to turn off buttons not in use (treachery, mutiny, etc.)
        }
        #region Game Management events
        private void AddPlayerButtonClick(object sender, EventArgs e)
        {
            ListBox characterList = new ListBox();
            // populate list of characters
            DeckManager.Characters.Character character = new DeckManager.Characters.Character();
            character.CharacterName = "Testman";

            character.DefaultDrawColors = new List<List<DeckManager.Cards.Enums.SkillCardColor>>();
            List<DeckManager.Cards.Enums.SkillCardColor> colores = new List<DeckManager.Cards.Enums.SkillCardColor>();
            colores.Add(DeckManager.Cards.Enums.SkillCardColor.Engineering);

            colores.Add(DeckManager.Cards.Enums.SkillCardColor.Politics);
            colores.Add(DeckManager.Cards.Enums.SkillCardColor.Leadership);
            character.DefaultDrawColors.Add(colores);
            

            characterList.Items.Add(character);
            NewPlayerForm newPlayerForm = new NewPlayerForm(characterList);

            if (newPlayerForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Player newPlayer = newPlayerForm.newPlayer;
                if (characterListBox.Enabled == false)
                {
                    characterListBox.Enabled = true;
                    characterListBox.Items.Clear();
                }
                characterListBox.Items.Add(newPlayer);
            }
        }

        private void RemovePlayerButton_Click(object sender, EventArgs e)
        {
            // remove the selected player from the game
        }

        private void BeginGameButtonClick(object sender, EventArgs e)
        {
            addPlayerButton.Enabled = false;
            RemovePlayerButton.Enabled = false;
            beginGameButton.Enabled = false;

            var players = characterListBox.Items.Cast<Player>().ToList();
            
            GameState gs =  Program.GManager.NewGame(players,0,false);
            enableControls();
        }
        /// <summary>
        /// Controls should be disabled before the game begins. Calling this method enables everything.
        /// </summary>
        private void enableControls()
        { }

        private void CopyGameButtonClick(object sender, EventArgs e)
        {
            // this button click copies an entire post update to the clipboard
            // e.g. http://forums.somethingawful.com/showthread.php?threadid=3563154&userid=0&perpage=40&pagenumber=2#post418151171

        }

        private void DradisButton_Click(object sender, EventArgs e)
        {
            dradis.Show();
        }
        #region resource events
        private void FuelUpDownValueChanged(object sender, EventArgs e)
        {
            Program.GManager.CurrentGameState.Fuel = (int)FuelUpDown.Value;
        }

        private void FoodUpDownValueChanged(object sender, EventArgs e)
        {
            Program.GManager.CurrentGameState.Food = (int)FoodUpDown.Value;
        }

        private void MoraleUpDownValueChanged(object sender, EventArgs e)
        {
            Program.GManager.CurrentGameState.Morale = (int)MoraleUpDown.Value;
        }

        private void PopulationUpDownValueChanged(object sender, EventArgs e)
        {
            Program.GManager.CurrentGameState.Population = (int)PopulationUpDown.Value;
        }
        #endregion
        #endregion

        #region skill deck events

        private void PolDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.PoliticsDeck.Draw();
            drawnCardListBox.Items.Add(card);

            drawnCardListBox.EndUpdate();
        }

        private void LeaDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.LeadershipDeck.Draw();
            drawnCardListBox.Items.Add(card);
            drawnCardListBox.EndUpdate();   
        }

        private void TacDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.TacticsDeck.Draw();
            drawnCardListBox.Items.Add(card);
            drawnCardListBox.EndUpdate();   
        }

        private void EngDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.EngineeringDeck.Draw();
            drawnCardListBox.Items.Add(card);
            drawnCardListBox.EndUpdate();   
        }

        private void PilDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.PilotingDeck.Draw();
            drawnCardListBox.Items.Add(card);
            drawnCardListBox.EndUpdate();   
        }

        private void TreDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.TreacheryDeck.Draw();
            drawnCardListBox.Items.Add(card);
            drawnCardListBox.EndUpdate();        
        }

        private void DrawQuorumButtonClick(object sender, EventArgs e)
        {
            var quorum = Program.GManager.CurrentGameState.QuorumDeck.Draw();
            drawnCardListBox.Items.Add(quorum);
        }

        private void DrawMutinyCardButton_Click(object sender, EventArgs e)
        {
            // not in GManager yet
        }

        private void DestinyDeckButton_Click(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.DestinyDeck.Draw();
            drawnCardListBox.Items.Add(card);
            drawnCardListBox.EndUpdate();    
        }

        private void ReturnToDeckButtonClick(object sender, EventArgs e)
        {
            if (drawnCardListBox.SelectedIndex == -1)
                return;

            Array cards = new DeckManager.Cards.BaseCard[drawnCardListBox.SelectedItems.Count];
            drawnCardListBox.SelectedItems.CopyTo(cards, 0);

            foreach (DeckManager.Cards.BaseCard card in cards)
            {
                Program.GManager.DiscardCard(card);
                drawnCardListBox.Items.Remove(card);
            }
        }

        /// <summary>
        /// Moves cards from the drawn card listbox to the skill check list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToSkillCheckButton_Click(object sender, EventArgs e)
        {
            if (drawnCardListBox.SelectedIndex == -1)
                return;
            // todo make sure crisis is active

            var items = drawnCardListBox.SelectedItems;
            List<DeckManager.Cards.SkillCard> cards = new List<DeckManager.Cards.SkillCard>();
            foreach (object card in items)
            {
                var cardref = card as DeckManager.Cards.SkillCard;
                if (cardref == null)    // selected card is not a skill card. this is an error case.
                    return;
                else
                    cards.Add(cardref);
            }
            drawnCardListBox.BeginUpdate();
            crisisSkillCheckListBox.BeginUpdate();
            foreach (DeckManager.Cards.SkillCard card in cards)
            {
                crisisSkillCheckListBox.Items.Add(card);
                drawnCardListBox.Items.Remove(card);
            }
            drawnCardListBox.EndUpdate();
            crisisSkillCheckListBox.EndUpdate();
        }

        #endregion

        #region crisis events
        private void CrisisTextBoxMeasureItem(object sender, MeasureItemEventArgs e)
        {
            //e.ItemHeight = 50;
            string item = crisisTextListBox.Items[e.Index].ToString();
            int count = item.Count(f=>f=='\n');
            count++;
            e.ItemHeight *= count;
        }

        private void CrisisTextBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Rectangle itemBounds = e.Bounds;

            e.Graphics.DrawString(crisisTextListBox.Items[e.Index].ToString(),
                e.Font,
                Brushes.Black,
                itemBounds,
                StringFormat.GenericDefault);
            e.DrawFocusRectangle();

        }

        private void DrawCrisisButtonClick(object sender, EventArgs e)
        {
            crisisTextListBox.BeginUpdate();

            // DeckManager.Cards.CrisisCard crisis = Program.gManager.CurrentGameState.CrisisDeck.Draw();
            // TODO: This sort of stuff should really be done in the TESTS project.  See my example in there.
            var crisis = new DeckManager.Cards.CrisisCard
                {
                    Activation = DeckManager.Cards.Enums.CylonActivations.Raiders,
                    Heading = "Test Crisis",
                    JumpPrep = true,
                    AdditionalText = "A description of the crisis",
                    PositiveColors =
                        new List<DeckManager.Cards.Enums.SkillCardColor>
                            {
                                DeckManager.Cards.Enums.SkillCardColor.Engineering,
                                DeckManager.Cards.Enums.SkillCardColor.Politics
                            }
                };

            //DeckManager.Cards.CrisisCard crisis = Program.GManager.CurrentGameState.CrisisDeck.Draw();          
            crisisTextListBox.Items.Add(crisis);
            crisisTextListBox.EndUpdate();
        }

        private void CrisisCopyTextButtonClick(object sender, EventArgs e)
        {
            Clipboard.SetText(crisisSkillCheckListBox.SelectedItem.ToString());
        }

        private void AddDestinyCardsButtonClick(object sender, EventArgs e)
        {
            var dest1 = Program.GManager.CurrentGameState.DestinyDeck.Draw();
            var dest2 = Program.GManager.CurrentGameState.DestinyDeck.Draw();

            crisisSkillCheckListBox.BeginUpdate();
            crisisSkillCheckListBox.Items.Add(dest1);            
            crisisSkillCheckListBox.Items.Add(dest2);
            crisisSkillCheckListBox.EndUpdate();
        }

        private void EvalSkillCheckButtonClick(object sender, EventArgs e)
        {
            
        }

        private void copySkillCheckResultsButton_Click(object sender, EventArgs e)
        {

        }
        private void DrawMissionButtonClick(object sender, EventArgs e)
        {
            crisisTextListBox.BeginUpdate();
            DeckManager.Cards.MissionCard mis = Program.GManager.CurrentGameState.MissionDeck.Draw();
            crisisTextListBox.Items.Add(mis);
            crisisTextListBox.EndUpdate();
        }

        private void clearCrisisButton_Click(object sender, EventArgs e)
        {
            // discard all crisis/mission cards drawn
            var cards = crisisTextListBox.Items.Cast<DeckManager.Cards.BaseCard>().AsEnumerable();
            Program.GManager.DiscardCards(cards);
            crisisTextListBox.BeginUpdate();
            crisisTextListBox.Items.Clear();
            crisisTextListBox.EndUpdate();

            // discard all skill cards in skill check pile
            cards = crisisSkillCheckListBox.Items.Cast<DeckManager.Cards.SkillCard>().AsEnumerable();
            Program.GManager.DiscardCards(cards);
            crisisSkillCheckListBox.BeginUpdate();
            crisisSkillCheckListBox.Items.Clear();
            crisisSkillCheckListBox.EndUpdate();

            HideSkillCheckControls();

            // increment turn in gmanager?
        }

        private void keepCrisisButton_Click(object sender, EventArgs e)
        {
            var card = (DeckManager.Cards.BaseCard)crisisTextListBox.SelectedItem;
            Program.GManager.TopCard(card);

            // todo change selected index or hide controls - nothing is selected after this event
        }

        private void buryCrisisButton_Click(object sender, EventArgs e)
        {
            var card = (DeckManager.Cards.BaseCard)crisisTextListBox.SelectedItem;
            Program.GManager.BuryCard(card);

            // todo change selected index or hide controls - nothing is selected after this event
        }

        private void crisisTextListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // selected crisis changed
            var crisis = (DeckManager.Cards.CrisisCard)crisisTextListBox.SelectedItem;
            if (crisis.HasSkillCheck())
            {
                SkillCheckDescriptionRichTextBox.Text = crisis.GetSkillCheckText();
                ShowSkillCheckControls();
            }
            else
            {
                HideSkillCheckControls();
            }
        }

        /// <summary>
        /// Show all controls related to skill checks.
        /// </summary>
        private void ShowSkillCheckControls()
        { 
                SkillCheckPanel.Visible = true;
                AddToSkillCheckButton.Visible = true;
                playIntoCrisisButton.Visible = true;        
        }
        /// <summary>
        /// Hides all controls related to skill checks. These will be re-shown when a crisis containing a skill check is selected
        /// </summary>
        private void HideSkillCheckControls()
        {
            SkillCheckDescriptionRichTextBox.Text = string.Empty;
            SkillCheckPanel.Visible = false;
            AddToSkillCheckButton.Visible = false;
            playIntoCrisisButton.Visible = false;
        }

        #endregion

        #region player hand events

        private void CharacterListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerHandControls();
        }

        private void GiveCardToCurrentCharacterButtonClick(object sender, EventArgs e)
        {
            // if no cards selected, give all
            object[] cards = new DeckManager.Cards.BaseCard[drawnCardListBox.Items.Count];
            if (drawnCardListBox.SelectedIndex == -1)
                drawnCardListBox.Items.CopyTo(cards, 0);
            else
                drawnCardListBox.SelectedItems.CopyTo(cards, 0);
            var currentPlayer = (Player)characterListBox.SelectedItem;

            // give selected cards to currently selected player (skill or quorum)
            foreach (DeckManager.Cards.BaseCard card in cards)
            {
                switch (card.CardType)
                {
                    case DeckManager.Cards.Enums.CardType.Skill:
                        currentPlayer.Cards.Add((DeckManager.Cards.SkillCard)card);
                        //characterSkillHandListBox.Items.Add(card);
                        break;
                    case DeckManager.Cards.Enums.CardType.Quorum:
                        currentPlayer.QuorumHand.Add((DeckManager.Cards.QuorumCard)card);
                        break;
                }
                drawnCardListBox.Items.Remove(card);
            }
            UpdatePlayerHandControls();
        }

        private void PlayIntoCrisisButtonClick(object sender, EventArgs e)
        {
            if (characterSkillHandListBox.SelectedIndices.Count >= 0)
            {
                var cards = characterSkillHandListBox.SelectedItems.Cast<DeckManager.Cards.SkillCard>().ToArray();
                crisisSkillCheckListBox.Items.AddRange(cards);
                ((Player)characterListBox.SelectedItem).Discard(cards);
                UpdatePlayerHandControls();
            }
        }
        /// <summary>
        /// Updates the skill hand listbox and quorum hand listbox to contain the currently selected player's hands.
        /// if the currently selected player does not possess the quorum hand, those controls are hidden.
        /// </summary>
        private void UpdatePlayerHandControls()
        {
            var player = (Player)characterListBox.SelectedItem;
            characterQuorumHandListBox.BeginUpdate();
            characterSkillHandListBox.BeginUpdate();
            characterQuorumHandListBox.Items.Clear();
            characterSkillHandListBox.Items.Clear();

            characterSkillHandListBox.Items.AddRange(player.Cards.ToArray());
            if (player.QuorumHand != null)
            {
                characterQuorumHandListBox.Show();
                characterQuorumHandCountTextBox.Show();
                DiscardQuorumCardButton.Show();
                CopyQuorumToClipboardButton.Show();
                characterQuorumHandListBox.Items.AddRange(player.QuorumHand.ToArray());
                characterQuorumHandCountTextBox.Text = player.QuorumHand.Count.ToString();
            }
            else
            {
                DiscardQuorumCardButton.Hide();
                CopyQuorumToClipboardButton.Hide();
                characterQuorumHandListBox.Hide();
                characterQuorumHandCountTextBox.Hide();
            }
            characterSkillHandListBox.EndUpdate();
            characterQuorumHandListBox.EndUpdate();
        }

        private void DiscardSkillCardButtonClick(object sender, EventArgs e)
        {
            Array cards = new DeckManager.Cards.SkillCard[characterSkillHandListBox.SelectedItems.Count];
            characterSkillHandListBox.SelectedItems.CopyTo(cards, 0);

            foreach (DeckManager.Cards.SkillCard card in cards)
            {
                Program.GManager.DiscardCard(card);
                characterSkillHandListBox.Items.Remove(card);
            }
            UpdatePlayerHandControls();
        }

        private void DiscardQuorumCardButtonClick(object sender, EventArgs e)
        {
            if (characterQuorumHandListBox.SelectedIndex == -1)
                return; // if nothing selected, do nothing

            Array cards = new DeckManager.Cards.QuorumCard[characterQuorumHandListBox.SelectedItems.Count];
            characterSkillHandListBox.SelectedItems.CopyTo(cards, 0);
            var currentCharacter = (Player)characterListBox.SelectedItem;

            foreach (DeckManager.Cards.QuorumCard card in cards)
            {
                Program.GManager.DiscardCard(card);
                currentCharacter.Discard(card);
                //characterQuorumHandListBox.Items.Remove(card);
            }
            UpdatePlayerHandControls();
        }

        private void RemoveFromHandButtonClick(object sender, EventArgs e)
        {
            // move character's currently selected card into the drawn card window. can use this to transfer cards between players
            var currentPlayer = (Player)this.characterListBox.SelectedItem;
            var cards = this.characterSkillHandListBox.SelectedItems.Cast<DeckManager.Cards.SkillCard>().ToArray();
            
            currentPlayer.Discard(cards);
            
            drawnCardListBox.BeginUpdate();
            drawnCardListBox.Items.AddRange(cards);
            drawnCardListBox.EndUpdate();

            UpdatePlayerHandControls();            
        }

        private void CopyQuorumToClipboardButton_Click(object sender, EventArgs e)
        {
            if (characterQuorumHandListBox.SelectedIndex >= 0)
                Clipboard.SetText(((DeckManager.Cards.QuorumCard)characterQuorumHandListBox.SelectedItem).ToBBCode());
        }
        #endregion
       
        #region Destinations and jump prep
        
        private void DestinationCountUpDownValueChanged(object sender, EventArgs e)
        {
            // number of destination cards to draw. probably don't need an event for this changing.
        }


        private void DrawDestinationsButtonClick(object sender, EventArgs e)
        {
            var count = (int)destinationCountUpDown.Value;
            destinationsListBox.BeginUpdate();
            destinationsListBox.Items.AddRange(Program.GManager.CurrentGameState.DestinationDeck.DrawMany(count).ToArray());
            destinationsListBox.EndUpdate();
        }        

        private void CopyDestinationsButtonClick(object sender, EventArgs e)
        {
            // copies drawn destination cards to clipboard, used to send PM to destination chooser
            var dests = destinationsListBox.Items.Cast<DeckManager.Cards.DestinationCard>().ToList();
            string bbcode = string.Join("\r\n", dests.Select(x => x.ToBBCode()));
            Clipboard.SetText(bbcode);
        }

        private void JumpToDestinationButton_Click(object sender, EventArgs e)
        {
            var dest = (DeckManager.Cards.DestinationCard)this.destinationsListBox.SelectedItem;
            if (dest != null)
            {
                selectedDestinationsListBox.Items.Add(dest);
                // maybe add a GManager method to select dest and apply text?
                Program.GManager.CurrentGameState.Distance += dest.Distance;
                jumpPrepStart.Checked = true;
            }
        }
        #endregion


        
    }
}
