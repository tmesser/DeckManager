using System.Collections.Generic;
using System.Linq;
using DeckManager.Cards;

namespace DeckManager.ManagerLogic
{
    public class SkillCheck
    {
        public CrisisCard CrisisCard { get; set; }
        public List<SkillCard> PlayedCards { get; private set; }
        //TODO: Let's talk about how Consequences should be handled here, I'm not sure what value this object is adding right now.
        public List<Consequence> Consequences { get; set; }
        public string Name { get; set; }

        public SkillCheck()
        {
            PlayedCards = new List<SkillCard>();
        }

        /// <summary>
        /// Empties the SkillCheck's deck of skill cards and returns them to be discarded into their respective decks
        /// </summary>
        /// <returns></returns>
        public List<SkillCard> RetrieveSkillCards()
        {
            var copy = new List<SkillCard>(PlayedCards);
            PlayedCards.Clear();
            return copy;
        }

        /// <summary>
        /// Evaluates the skill check after all cards have been played.
        /// </summary>
        /// <returns>List of all consequences that occur as a result of the skill check's outcome.</returns>
        public List<Consequence> EvalSkillCheck()
        {
            var strength = 0;
            var results = new List<Consequence>();
            var scaHit = false;
            foreach (var card in PlayedCards)
            {
                if (card.CardPower > 0)
                {
                    if (CrisisCard.PositiveColors.Contains(card.CardColor))
                        strength += card.CardPower;
                    else
                        strength -= card.CardPower;
                }
                else if (!scaHit && Consequences.Exists(x => x.Threshold == -1))
                {
                    //TODO: 0-strength card consequences should probably be attached to the card, not the consequence.
                    scaHit = true;
                    results.Add(Consequences.Find(x => x.Threshold == -1));    // SCA consequence only happens once
                }
            }

            // TODO: OrderBy might arrange the skill check backwards.  This would be really easy to test if I had NuGet working and could install NUnit.  Check this later.
            var checkResult = CrisisCard.PassLevels.OrderBy(x => x.Item1).First(result => strength > result.Item1);
            results.Add(new Consequence(checkResult.Item1, checkResult.Item2));

            return results;
        }

    }
}
