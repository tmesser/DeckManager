using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeckManager;

namespace DeckManagerOutput
{
    static class Program
    {
        public static GameManager gManager { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // @todo create logger for GUI
            log4net.ILog logger = null;
            Program.gManager = new GameManager(logger);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }
    }
}
