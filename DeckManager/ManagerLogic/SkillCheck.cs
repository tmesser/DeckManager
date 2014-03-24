using System;
using System.Collections.Generic;
using System.Linq;
using DeckManager.Cards;
using log4net;

namespace DeckManager.ManagerLogic
{
    public class SkillCheck
    {
        /// <summary>
        /// Evaluates the skill check after all cards have been played.
        /// </summary>
        /// <returns>List of all consequences that occur as a result of the skill check's outcome.</returns>
        public static List<Consequence> EvalSkillCheck(IEnumerable<SkillCard> playedCards, CrisisCard crisisCard )
        {
            var logger = LogManager.GetLogger(typeof(SkillCheck));
            var results = new List<Consequence>();
            try
            {
                var strength = 0;

                //var scaHit = false;
                foreach (var card in playedCards)
                {
                    if (card.CardPower > 0)
                    {
                        if (crisisCard.PositiveColors.Contains(card.CardColor))
                            strength += card.CardPower;
                        else
                            strength -= card.CardPower;
                    }
                    /*else if (!scaHit && Consequences.Exists(x => x.Threshold == -1))
                    {
                        // CPS: The consequence here is when the crisis skill check has the 3-dot symbol on it, indicating
                        //      that the effect happens when someone plays a card with a SCA into the check. We should probably add
                        //      Consequences to SkillCards to account for those.
                        //
                        //  Tmesser(3/24/2014) - 
                        //  None of this stuff is relevant right now as it relies on the CardPower 0 cards, which aren't in Base and will be dealt with later.
                        scaHit = true;
                        results.Add(Consequences.Find(x => x.Threshold == -1));    // SCA consequence only happens once
                    }*/
                }
                if (strength < 0)
                    strength = 0;
                var checkResult = crisisCard.PassLevels.OrderByDescending(x => x.Item1).First(result => strength >= result.Item1);
                results.Add(new Consequence(checkResult.Item1, checkResult.Item2));
            }
            catch (Exception e)
            {
                logger.Error("Error while computing skill check.", e);
                throw;
            }

            return results;
        }

    }
}
