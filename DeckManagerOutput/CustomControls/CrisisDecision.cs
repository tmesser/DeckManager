
namespace DeckManagerOutput.CustomControls
{
    public class CrisisDecision
    {
        public DeckManager.Cards.CrisisCard Crisis { get; set; }
        public CrisisAction Action { get; set; }
        public int Order { get; set; }
    }
}
