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
    public partial class FormGame : Form
    {
        private MainMenu newMenu = new MainMenu();
        private SongList chooseSongs = new SongList();
        private KeySelection selectKeys = new KeySelection();

        //
        static Dictionary<string, string> gameKeys = new Dictionary<string, string>
        {
            {"G_", "Q"},
            {"A", "A"},
            {"A_", "W"},
            {"H", "S"},
            {"C1", "D"},
            {"C_1", "R"},
            {"D1", "F"},
            {"D_1", "T"},
            {"E1", "G"},
            {"F1", "H"},
            {"F_1", "U"},
            {"G1", "J"},
            {"G_1", "I"},
            {"A1", "K"},
            {"A_1", "O"},
            {"H1", "L"},
            {"C2", "Oem1"}, // kod za č
            {"C_2", "Oem4"}, //š
            {"D2", "Oem7"}, //ć
            {"D_2", "Oem6"}, //đ
            {"E2", "Oem5"} //ž
        };
        string pressedKey;

        public static Dictionary<string, string> GameKeys
        {
            get { return gameKeys; }
            set { gameKeys = value; }
        }

        public FormGame()
        {
            InitializeComponent();

            pressedKey = "";

            newMenu.Location = new System.Drawing.Point(450, 15);
            newMenu.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            Controls.Add(newMenu);

            chooseSongs.Location = new System.Drawing.Point(475, 15);
            chooseSongs.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            chooseSongs.Visible = false;
            Controls.Add(chooseSongs);

            chooseSongs.Song1 += (sender, e) =>
            {
                chooseSongs.Visible = false;
                piano.Visible = true;
                buttonMenu.Visible = true;
                KeyPreview = true;
                KeyDown += new KeyEventHandler(piano_KeyDown);
            };
            chooseSongs.Song2 += (sender, e) =>
            {
                chooseSongs.Visible = false;
                piano.Visible = true;
                buttonMenu.Visible = true;
                KeyPreview = true;
                KeyDown += new KeyEventHandler(piano_KeyDown);
            };
            chooseSongs.Song3 += (sender, e) =>
            {
                chooseSongs.Visible = false;
                piano.Visible = true;
                buttonMenu.Visible = true;
                KeyPreview = true;
                KeyDown += new KeyEventHandler(piano_KeyDown);
            };
            chooseSongs.Menu += (sender, e) =>
            {
                chooseSongs.Visible = false;
                newMenu.Visible = true;
            };


            newMenu.NewGame += (sender, e) =>
            {
                newMenu.Visible = false;
                chooseSongs.Visible = true;
            };
            newMenu.Quit += (sender, e) =>
            {
                System.Windows.Forms.Application.Exit();
            };
            newMenu.Settings += (sender, e) =>
            {
                selectKeys.ShowDialog(this);
            };
        }


        #region Events

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            KeyDown -= new KeyEventHandler(piano_KeyDown);
            piano.Visible = false;
            buttonMenu.Visible = false;
            KeyPreview = false;
            newMenu.Visible = true;
        }

        private void piano_KeyDown(object sender, KeyEventArgs e)
        { 
            string name = (new KeysConverter()).ConvertToString(e.KeyCode);

            if (pressedKey != "" )
            {
                return;
            }
            else
            {
                piano.play(name, gameKeys);
                pressedKey = name;
            }
        }

        private void FormGame_KeyUp(object sender, KeyEventArgs e)
        {
            string name = (new KeysConverter()).ConvertToString(e.KeyCode);

            piano.keySilence(name, gameKeys);
            
            if(string.Equals(pressedKey, name, StringComparison.CurrentCultureIgnoreCase))
            {
                pressedKey = "";
            }

            this.Focus();
           // Application.OpenForms["FormGame"].Controls["piano"].Focus();
        }

        #endregion
    }
}
