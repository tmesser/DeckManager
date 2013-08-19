namespace DeckManager.ManagerLogic
{
    public class Consequence
    {
        public Consequence(int threshold, string text)
        {
            ConditionText = text;
            Threshold = threshold;
        }
        
        /// <summary>
        /// Threshold for consequence to occur. Max value for skill check is pass, 0 is fail, -1 is a skill check ability consequence.
        /// </summary>
        public int Threshold { get; set; }

        public string ConditionText { get; set; }
    }
}
