using System.Windows.Forms;

namespace DeckManagerOutput.CustomControls
{
    public class ReadOnlyListBox : ListBox
    {
        private bool _readOnly = false;
        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        protected override void DefWndProc(ref Message m)
        {
            // If ReadOnly is set to true, then block any messages 
            // to the selection area from the mouse or keyboard. 
            // Let all other messages pass through to the 
            // Windows default implementation of DefWndProc.
            if (!_readOnly || ((m.Msg <= 512 || m.Msg >= 515)
            && (m.Msg <= 256 || m.Msg >= 265)
            && m.Msg != 8465
            && m.Msg != 135))
            {
                base.DefWndProc(ref m);
            }
        }
    }
}
