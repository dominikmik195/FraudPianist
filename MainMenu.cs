using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace piano
{
    /// <summary>
    /// Klasa (user control) koja predstavlja glavni izbornik igre.
    /// </summary>
    public partial class MainMenu : UserControl
    {
        /// <summary>
        /// Konstruktor klase.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }

        public event EventHandler NewGame, Practice, Settings, HowTo, Quit;

        // funkcije koje reagiraju na tipke menija
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            if (NewGame != null) NewGame(sender, e);
        }

        private void buttonPractice_Click(object sender, EventArgs e)
        {
            if (Practice != null) Practice(sender, e);
        }

        private void buttonHowTo_Click(object sender, EventArgs e)
        {
            if (HowTo != null) HowTo(sender, e);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (Settings != null) Settings(sender, e);
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            if (Quit != null) Quit(sender, e);
        }

    }
}
