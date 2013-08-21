using System.Collections.Generic;
using System.Linq;
using DeckManager.Cards;
using DeckManager.Cards.Enums;
using DeckManager.Characters.Enums;

namespace DeckManager.States
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int TurnPosition { get; set; }
        public Characters.Character Character { get; set; }
        public List<SkillCard> Cards { get; set; }
        public List<LoyaltyCard> LoyaltyCards { get; set; }
        public List<List<SkillCardColor>> CustomDraws { get; set; }
        public List<Titles> Titles { get; set; }
        public int MiracleTokens { get; set; }
        public int DefaultDrawIndex { get; set; }

        public IEnumerable<IEnumerable<SkillCardColor>> SkillCardDraws
        {
            get { return Character.DefaultDrawColors.Union(CustomDraws); }
        }
    }
}
