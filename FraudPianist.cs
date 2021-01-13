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

        public FormGame()
        {
            InitializeComponent();
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
                KeyPress += new KeyPressEventHandler(FormGame_KeyPress);
            };
            chooseSongs.Song2 += (sender, e) =>
            {
                chooseSongs.Visible = false;
                piano.Visible = true;
                buttonMenu.Visible = true;
                KeyPreview = true;
                KeyPress += new KeyPressEventHandler(FormGame_KeyPress);
            };
            chooseSongs.Song3 += (sender, e) =>
            {
                chooseSongs.Visible = false;
                piano.Visible = true;
                buttonMenu.Visible = true;
                KeyPreview = true;
                KeyPress += new KeyPressEventHandler(FormGame_KeyPress);
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
        }

        private void FormGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            piano.play(e.KeyChar);
        }

        private void FormGame_KeyUp(object sender, KeyEventArgs e)
        {
            string name = (new KeysConverter()).ConvertToString(e.KeyCode).ToLower(); 
            piano.keySilence(name);

            this.Focus();
        }


        private void buttonMenu_Click(object sender, EventArgs e)
        {
            KeyPress -= new KeyPressEventHandler(FormGame_KeyPress);
            piano.Visible = false;
            buttonMenu.Visible = false;
            KeyPreview = false;
            newMenu.Visible = true;
        }
    }
}
