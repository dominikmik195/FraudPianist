using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace piano
{
    public partial class FormGame : Form
    {
        private Game game;

        /*
         * Kako bismo izbjegli otvaranje mnogo novih formi, definirali smo pomoćne UserControls.
         * Jedna od njih je MainMenu koja se prikazuje pri samom početku igre.
         * Klikom na tipku 'New game' prikazat će se kontrola SongList koja nudi moguće igre.
         * Istovremeno, sakrije se kontrola MainMenu.
         * Tako odabirom pjesme skrivamo SongList ali prikazujemo klavijaturu i pločice.
         * Klikom na 'Main menu' skrivamo sve funkcionalnosti ali prikazujemo Mainmenu kontrolu.
         */
        private MainMenu newMenu = new MainMenu();
        private SongList chooseSongs = new SongList();
        private KeySelection selectKeys = new KeySelection();

        /// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=net-5.0
        /// <summary>
        /// Riječnik koji predstavlja trenutno aktivne igraće tipke. Ključ je naziv note, a vrijednost je naziv odgovarajuće tipke za tu notu na tipkovnici.
        /// </summary>
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
            {"C_2", "OemOpenBrackets"}, //š
            {"D2", "Oem7"}, //ć
            {"D_2", "Oem6"}, //đ
            {"E2", "Oem5"} //ž
        };

        // Upravo pritisnuta tipka. Ukoliko niti jedna tipka nije pritisnuta vrijednost je "".
        string pressedKey;

        public FormGame()
        {
            InitializeComponent();
            pressedKey = "";

            // Ovdje inicijaliziramo početni ekran - glavni izbornik:
            panel1.Visible = false;
            Width = 600;
            Height = 450;
            newMenu.Location = new System.Drawing.Point(0, 0);
            newMenu.Dock = DockStyle.Fill;
            Controls.Add(newMenu);

            // Inicijaliziramo izbornik za odabir pjesme:
            chooseSongs.Location = new System.Drawing.Point(0, 0);
            chooseSongs.Dock = DockStyle.Fill;
            chooseSongs.Visible = false;
            // Postavljamo tekstove na tipkama izbornika:
            chooseSongs.set_title("1. Twinkle, Twinkle Little Star", 1);
            chooseSongs.set_title("2. Swan Lake", 2);
            chooseSongs.set_title("3. Twinkle, Twinkle Little Star", 3);
            Controls.Add(chooseSongs);

            Controls["tilesBox"].Visible = false;

            // Dodajemo pretplatnike na događaje:
            chooseSongs.Song1 += (sender, e) =>
            {
                // Standardna veličina ekrana za sviranje:
                Width = 1350;
                Height = 710;
                game = new Game(1); // pjesma 1

                // nadalje postavljamo na 'vidljivo' samo one stvari
                // koje doista želimo vidjeti na ekranu:
                Controls["tilesBox"].Visible = true;
                panel1.Visible = true;
                labelBodovi.Text = "0";
                labelPoruka.Text = "";
                labelResult.Visible = false;
                labelPercent.Visible = false;
                labelPass.Visible = false;
                labelLvlMsg.Visible = false;
                chooseSongs.Visible = false;
                piano.Visible = true;
                buttonMenu.Visible = true;
                // omogućavamo rad tipkovnicom
                KeyPreview = true;
                KeyDown += new KeyEventHandler(piano_KeyDown);
                // pokrećemo timere
                timer1.Start();
                timer2.Start();
            };
            chooseSongs.Song2 += (sender, e) =>
            {
                Width = 1350;
                Height = 710;
                game = new Game(2);
                Controls["tilesBox"].Visible = true;
                panel1.Visible = true;
                labelBodovi.Text = "0";
                labelPoruka.Text = "";
                labelResult.Visible = false;
                labelPercent.Visible = false;
                labelPass.Visible = false;
                labelLvlMsg.Visible = false;
                chooseSongs.Visible = false;
                piano.Visible = true;
                buttonMenu.Visible = true;
                KeyPreview = true;
                KeyDown += new KeyEventHandler(piano_KeyDown);
                timer1.Start();
                timer2.Start();
            };
            chooseSongs.Song3 += (sender, e) =>
            {
                Width = 1350;
                Height = 710;
                game = new Game(3);
                Controls["tilesBox"].Visible = true;
                panel1.Visible = true;
                labelBodovi.Text = "0";
                labelPoruka.Text = "";
                labelResult.Visible = false;
                labelPercent.Visible = false;
                labelPass.Visible = false;
                labelLvlMsg.Visible = false;
                chooseSongs.Visible = false;
                piano.Visible = true;
                buttonMenu.Visible = true;
                KeyPreview = true;
                KeyDown += new KeyEventHandler(piano_KeyDown);
                timer1.Start();
                timer2.Start();
            };
            chooseSongs.Menu += (sender, e) =>
            {
                // povratak na meni
                Width = 600;
                Height = 450;
                chooseSongs.Visible = false;
                newMenu.Visible = true;
                panel1.Visible = false;
            };

            // pretplatnici na događaje (vezane uz glavni izbornik):
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

        #region Properties

        public static Dictionary<string, string> GameKeys
        {
            get { return gameKeys; }
            set { gameKeys = value; }
        }

        #endregion

        #region Events

        /// <summary>
        /// Reakcija na klik tipke za povratak na meni iz pjesme.
        /// </summary>
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            // vraćamo se na meni i skrivamo ono što nam ne treba
            Width = 600;
            Height = 450;
            KeyDown -= new KeyEventHandler(piano_KeyDown);
            piano.Visible = false;
            buttonMenu.Visible = false;
            Controls["tilesBox"].Visible = false;
            KeyPreview = false;
            newMenu.Visible = true;
            panel1.Visible = false;
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

                string s = e.KeyCode.ToString();
                // provjeri je li igrač odsvirao točnu notu
                string note = gameKeys.FirstOrDefault(x => x.Value == e.KeyCode.ToString()).Key;
                if (note != null && game.lowestTile != null && note.Equals(game.lowestTile.id))
                {
                    // ako tipka još nije došla na ekran, zapravo ona još ne postoji
                    // stoga je ne prihvaćamo kao točnu:
                    if (game.lowestTile.Y + game.lowestTile.Height < 0) game.wrong();
                    else game.hit(tilesBox.Height);
                    renderHit(Controls["piano"].Controls["btn" + note] as Button);
                }
                else game.wrong();
                // updateamo bodove
                labelBodovi.Text = game.score.ToString();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.update();
            game.render(this.Controls["tilesBox"] as PictureBox);
            // konstantno provjeravamo vrijedi li naš combo:
            if (game.combo >= 10) 
            {
                // ukoliko je u combo u tijeku, to naznačimo igraču:
                int faktor = game.combo / 10 + 1;
                if (faktor > 5) faktor = 5;
                labelPoruka.ForeColor = Color.DarkGreen;
                labelPoruka.Text = "COMBO " + faktor + "X";
                game.combo_made = true;
            }
            else if (game.combo_made)
            {
                // ako combo više nije u tijeku, ali je combo_made postavljen na true
                // to znači da smo imali combo ali je prekinut, pa treba postaviti poruku:
                game.combo_made = false;
                labelPoruka.ForeColor = Color.DarkRed;
                labelPoruka.Text = "COMBO BROKEN";
            }
            if (game.isOver())
            {
                // ako je igra gotova, računamo rezultat:
                double percentage = Math.Round((double)game.score / game.score_possible * 100, 2);
                labelPoruka.Text = "";
                labelResult.Visible = true;
                labelPercent.Visible = true;
                labelPercent.Text = percentage.ToString() + "%";
                labelPass.Visible = true;

                // ovisno o kvaliteti rezultata, prikazujemo prigodne poruke:
                if (percentage == 100)
                {
                    labelPass.ForeColor = Color.DarkGreen;
                    labelPass.Text = "Perfect score!";
                }
                else if (percentage >= 75)
                {
                    labelPass.ForeColor = Color.DarkGreen;
                    labelPass.Text = "Amazing!";
                }
                else if (percentage >= 55)
                {
                    labelPass.ForeColor = Color.DarkGreen;
                    labelPass.Text = "Well done!";
                }
                else if (percentage >= 30)
                {
                    labelPass.ForeColor = Color.DarkGreen;
                    labelPass.Text = "You passed!";
                }
                else
                {
                    labelPass.ForeColor = Color.DarkRed;
                    labelPass.Text = "You failed!";
                }
                KeyDown -= new KeyEventHandler(piano_KeyDown);

                // ukoliko je level prijeđen, otključavamo sljedeći:
                if (percentage >= 30)
                {
                    switch (game.Level.levelNumber)
                    {
                        case 1: 
                            chooseSongs.enable(2);
                            labelLvlMsg.Visible = true;
                            labelLvlMsg.Text = "Level 2 is now unlocked!";
                            break;
                        case 2:
                            chooseSongs.enable(3);
                            labelLvlMsg.Visible = true;
                            labelLvlMsg.Text = "Level 3 is now unlocked!";
                            break;
                        default: chooseSongs.enable(1);
                            labelLvlMsg.Visible = true;
                            labelLvlMsg.Text = "Level 2 is now unlocked!";
                            break;
                    }
                }
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            game.parseOneNote();
        }
        #endregion

        //TODO
        private void renderHit(Button button)
        {
            Graphics g = CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, this.Controls["tilesBox"].Height),
                new Point(0, 0),
                Color.Orchid,
                Color.LightCyan
            );

            g.FillRectangle(brush, button.Location.X, 0, button.Width, this.Controls["tilesBox"].Height);
        }
    }
}
