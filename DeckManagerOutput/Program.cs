using System;
using System.Windows.Forms;
using DeckManager;

namespace DeckManagerOutput
{
    static class Program
    {
        public static GameManager GManager { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            GManager = new GameManager();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameWindow());

        }
    }
}
