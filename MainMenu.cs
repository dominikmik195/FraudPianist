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
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();

        }

        public event EventHandler NewGame, Settings, HowTo, Quit;

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            if (Quit != null) Quit(sender, e);
        }

        private void buttonHowTo_Click(object sender, EventArgs e)
        {
            if (HowTo != null) HowTo(sender, e);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (Settings != null) Settings(sender, e);
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            if (NewGame != null) NewGame(sender, e);
        }
    }
}
