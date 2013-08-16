using System.Collections.Generic;
using DeckManager.Cards;

namespace DeckManager.States
{
    public class Player
    {
        public string PlayerName { get; set; }
        public string CharacterName { get; set; }
        public List<SkillCard> Cards { get; set; }
        public List<LoyaltyCard> LoyaltyCards { get; set; }
        public int MiracleTokens { get; set; }
    }
}
