using System.Collections.Generic;
using DeckManager.Cards;
using DeckManager.Cards.Enums;

namespace DeckManager.States
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int TurnPosition { get; set; }
        public string CharacterName { get; set; }
        public List<SkillCard> Cards { get; set; }
        public List<LoyaltyCard> LoyaltyCards { get; set; }
        public List<List<SkillCardColor>> SkillCardDraws { get; set; }
        public int MiracleTokens { get; set; }
        public int DefaultDrawIndex { get; set; }
    }
}
