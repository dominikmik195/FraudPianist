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
using System.Resources;
using System.IO;


namespace piano
{
    public partial class FormGame : Form
    {
        private Game game;
        private PictureBox pictureBoxNote;

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
        private HowTo rules = new HowTo();

        /// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=net-5.0
        /// <summary>
        /// Riječnik koji predstavlja trenutno aktivne igrače tipke. Ključ je naziv note, a vrijednost je naziv odgovarajuće tipke za tu notu na tipkovnici.
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


            Controls.Add(newMenu);
            Controls.Add(chooseSongs);
            
            enableSavedLevels();

            clearFormGameFor(2430, 785);
            mainMenuShow();

            chooseSongs.Level1 += (sender, e) =>
            {
                playGame(1);
            };
            chooseSongs.Level2 += (sender, e) =>
            {
                playGame(2);
            };
            chooseSongs.Level3 += (sender, e) =>
            {
                playGame(3);
            };
            chooseSongs.Level4 += (sender, e) =>
            {
                playGame(4);
            };
            chooseSongs.Level5 += (sender, e) =>
            {
                playGame(5);
            };
            chooseSongs.MainMenu += (sender, e) =>
            {
                mainMenuShow();
            };
            newMenu.NewGame += (sender, e) =>
            {
                levelMenuShow();
            };
            newMenu.Practice += (sender, e) =>
            {
                practicePianoShow();
            };
            newMenu.Quit += (sender, e) =>
            {
                System.Windows.Forms.Application.Exit();
            };
            newMenu.Settings += (sender, e) =>
            {
                selectKeys.ShowDialog(this);
            };
            newMenu.HowTo += (sender, e) =>
            {
                rules.ShowDialog(this);
            };

            this.MinimumSize = new System.Drawing.Size(piano.Width, 750);
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
            // stopiramo tajmere da igra ne krene prije nego što to želimo
            // ukoliko igrač klikne na meni dok se igra odvija, želimo zaustaviti tijek igre
            timer1.Stop();
            timer2.Stop();
            // ako se vraćamo na meni iz igre, igru moramo resetirati
            if (game != null)
            {
                game.reset();
            }

            KeyDown -= new KeyEventHandler(FormGame_KeyDown);
            mainMenuShow();
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            string name = (new KeysConverter()).ConvertToString(e.KeyCode);

            if (pressedKey != "")
            {
                return;
            }
            else
            {
                piano.play(name, gameKeys);
                pressedKey = name;

                if (Controls["tilesBox"].Visible == true)
                {
                    string s = e.KeyCode.ToString();
                    // provjeri je li igrač odsvirao točnu notu
                    string note = gameKeys.FirstOrDefault(x => x.Value == e.KeyCode.ToString()).Key;
                    if (note != null && game.lowestTile != null && note.Equals(game.lowestTile.Id))
                    {
                        // ako tipka još nije došla na ekran, zapravo ona još ne postoji
                        // stoga je ne prihvaćamo kao točnu:
                        if (game.lowestTile.Y + game.lowestTile.Height < 0)
                        {
                            game.wrong();
                        }
                        else
                        {
                            game.hit(tilesBox.Height);
                        }
                    }
                    else game.wrong();
                    // updateamo bodove
                    labelBodovi.Text = game.Score.ToString();
                }
            }
        }

        private void FormGame_KeyUp(object sender, KeyEventArgs e)
        {
            string name = (new KeysConverter()).ConvertToString(e.KeyCode);

            piano.keySilence(name, gameKeys);

            if (string.Equals(pressedKey, name, StringComparison.CurrentCultureIgnoreCase))
            {
                pressedKey = "";
            }

            this.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.update();
            game.render(this.Controls["tilesBox"] as PictureBox);

            if (game.lowestTile != null && game.lowestTile.Y > tilesBox.Height - 80) game.breakCombo();

            // konstantno provjeravamo vrijedi li naš combo:
            if (game.Combo >= 10)
            {
                // ukoliko je u combo u tijeku, to naznačimo igraču:
                int faktor = game.Combo / 10 + 1;
                if (faktor > 5) faktor = 5;
                labelPoruka.ForeColor = Color.Teal;
                labelPoruka.Text = "COMBO " + faktor + "X";
                labelPoruka.Visible = true;
                game.Combo_made = true;
            }
            else if (game.Combo_made)
            {
                // ako combo više nije u tijeku, ali je combo_made postavljen na true
                // to znači da smo imali combo ali je prekinut, pa treba postaviti poruku:
                game.Combo_made = false;
                labelPoruka.ForeColor = Color.DarkOrchid;
                labelPoruka.Text = "COMBO BROKEN";
            }
            if (game.isOver())
            {
                // stopiramo tajmere kako sljedeća igra ne bi počela čim se pozove game stavi na new Game
                timer1.Stop();
                timer2.Stop();
                game.reset();

                // ako je igra gotova, računamo rezultat:
                double percentage = Math.Round((double)game.Score / game.Level.scorePossible * 100, 1);
                labelPoruka.Text = "";
                labelPoruka.Visible = false;
                labelPercent.Visible = true;
                labelPercent.Text = percentage.ToString() + "%";
                labelPass.Visible = true;

                // ovisno o kvaliteti rezultata, prikazujemo prigodne poruke:
                if (percentage == 100)
                {
                    labelPass.ForeColor = Color.Teal;
                    labelPass.Text = "Perfect score!";
                }
                else if (percentage >= 70)
                {
                    labelPass.ForeColor = Color.Teal;
                    labelPass.Text = "Amazing!";
                }
                else if (percentage >= 60)
                {
                    labelPass.ForeColor = Color.Teal;
                    labelPass.Text = "Well done!";
                }
                else if (percentage >= 40)
                {
                    labelPass.ForeColor = Color.Teal;
                    labelPass.Text = "You passed!";
                }
                else
                {
                    labelPass.ForeColor = Color.DarkOrchid;
                    labelPass.Text = "You failed!";
                }
                KeyDown -= new KeyEventHandler(FormGame_KeyDown);

                // ukoliko je zadnji level prijeđen, ispisujemo poruku o završetku igre
                if (percentage >= 40 && game.Level.Equals(Level.FIVE))
                {
                    string message = "Congrats maestro! You completed the game!";
                    string title = "True pianist";
                    MessageBox.Show(message, title);
                }
                // ukoliko je level prijeđen, otključavamo sljedeći:
                else if (percentage >= 40)
                {
                    if (!isLvlSaved(game.Level.levelNumber + 1) && game.Level.levelNumber < 5)
                    {
                        saveLvl(game.Level.levelNumber + 1);
                        chooseSongs.enable(game.Level.levelNumber + 1);
                        labelLvlMsg.Visible = true;
                        labelLvlMsg.Text = "Level " + (game.Level.levelNumber + 1).ToString() + " is now unlocked!";
                    }
                    restartButton.Text = "Next level";
                    // na kraju igre prikazuje se gumb za ponovno pokretanje igre
                    restartButton.Visible = true;
                }
                else
                {
                    restartButton.Text = "Try again";
                    // na kraju igre prikazuje se gumb za ponovno pokretanje igre
                    restartButton.Visible = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            game.parseOneNote();
        }

        private void FormGame_SizeChanged(object sender, EventArgs e)
        {
            // leveli
            if (chooseSongs.Visible == true)
            {
                chooseSongs.Size = new System.Drawing.Size(Width / 2, chooseSongs.Height);
                chooseSongs.Location = new System.Drawing.Point(this.Width / 2 - chooseSongs.Width / 2, 0);
                chooseSongs.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            }

            // main menu
            if (newMenu.Visible == true)
            {
                newMenu.Size = new System.Drawing.Size(Width / 2, newMenu.Height);
                newMenu.Location = new System.Drawing.Point(this.Width / 2 - newMenu.Width / 2, 0);
                newMenu.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            }

            // igra
            if (piano.Visible == true && tilesBox.Visible == true)
            {
                this.MinimumSize = new System.Drawing.Size(piano.Width, piano.Height + 50);
                piano.Location = new System.Drawing.Point(0, Height - piano.Height - 35);
                buttonMenu.Location = new System.Drawing.Point(
                panelScore.Width / 2 - buttonMenu.Width / 2, panelScore.Height - buttonMenu.Height - 60);
            }
            //practice                
            else if (piano.Visible == true)
            {
                piano.Location = new System.Drawing.Point(this.Width / 2 - piano.Width / 2, this.Height - piano.Height - 38);
                pictureBoxNote.Size = new System.Drawing.Size(piano.Width, this.Height - piano.Height);
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            // gumb pokreće novu igru s istom ili novom pjesmom, ukoliko 
            // se u prošloj igri zadovoljio uvjet za novi level
            if (restartButton.Text.Equals("Next level"))
            {
                playGame(++game.Level.levelNumber);
            }
            else
            {
                playGame(game.Level.levelNumber);
            }
        }
        #endregion

        #region Private
        /// <summary>
        /// Funkcija čisti formu te potom iscrtava i pozicionira sve elemente potrebne za igru i pokreće novu igru određene razine.
        /// </summary>
        /// <param name="level">Razina igre.</param>
        private void playGame(int level)
        {
            clearFormGameFor();
            piano.silenceAllKeys();
            this.BackColor = System.Drawing.SystemColors.ScrollBar;

            game = new Game(level);

            tilesBox.Visible = true;
            tilesBox.Enabled = true;

            piano.Location = new System.Drawing.Point(0, Height - piano.Height - 35);
            piano.Visible = true;
            piano.Enabled = true;

            panelScore.Visible = true;
            panelScore.Enabled = true;

            panelScore.Controls.Add(buttonMenu);
            buttonMenu.Anchor = AnchorStyles.Top;
            buttonMenu.Location = new System.Drawing.Point(
                panelScore.Width / 2 - buttonMenu.Width / 2, panelScore.Height - buttonMenu.Height - 60 );
            buttonMenu.Visible = true;
            buttonMenu.Enabled = true;

            restartButton.Visible = false;

            labelLevel.Text = game.Level.levelNumber.ToString() + ". " + game.Level.songName;
            labelLevel.Visible = true;

            labelBodovi.Text = "0";
            labelPoruka.Text = "";
            labelPercent.Visible = false;
            labelPass.Visible = false;
            labelLvlMsg.Visible = false;

            KeyPreview = true;
            KeyDown += new KeyEventHandler(FormGame_KeyDown);       

            timer1.Start();
            timer2.Start();

            SendKeys.SendWait("{ENTER}");
        }

        /// <summary>
        /// Funkcija čisti formu te iscrtava i pozicionira elemente za odabir levela na ekranu.
        /// </summary>
        private void levelMenuShow()
        {
            clearFormGameFor(chooseSongs.Width, chooseSongs.Height);

            chooseSongs.Size = new System.Drawing.Size(Width / 2, chooseSongs.Height);
            chooseSongs.Location = new System.Drawing.Point(this.Width / 2 - chooseSongs.Width / 2, 0);
            chooseSongs.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

            chooseSongs.Visible = true;
            chooseSongs.Enabled = true;
        }

        /// <summary>
        /// Funkcija čisti formu te iscrtava i pozicionira elemente glavnog izbornika.
        /// </summary>
        private void mainMenuShow()
        {
            clearFormGameFor(newMenu.Width + 100, newMenu.Height + 300);
            if (Size.Width < MinimumSize.Width)
                Width = MinimumSize.Width;
            if (Size.Height < MinimumSize.Height)
                Height = MinimumSize.Height;

            newMenu.Size = new System.Drawing.Size(Width / 2, newMenu.Height);
            newMenu.Location = new System.Drawing.Point(this.Width / 2 - newMenu.Width / 2, 0);
            newMenu.Anchor = AnchorStyles.None;

            newMenu.Visible = true;
            newMenu.Enabled = true;
        }

        /// <summary>
        /// Funkcija čisti formu te iscrtava i pozicionira elemente na Practice ekranu.
        /// </summary>
        private void practicePianoShow()
        {
            clearFormGameFor();

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            KeyPreview = true;
            KeyDown += new KeyEventHandler(FormGame_KeyDown);

            piano.Location = new System.Drawing.Point(this.Width / 2 - piano.Width  /2, this.Height - piano.Height-38);
            piano.Visible = true;
            piano.Enabled = true;

            pictureBoxNote = new PictureBox()
            {
                Name = "pictureBoxNote",
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                Location = new System.Drawing.Point(0, 41),
                Padding = new Padding(0, 100, 0, 0),
                Image = ((System.Drawing.Image)(Properties.Resources.ResourceManager.GetObject("piano"))),
                TabStop = true,
                Dock = System.Windows.Forms.DockStyle.Top,
                BackColor = System.Drawing.Color.Azure
            };
            pictureBoxNote.Size = new System.Drawing.Size(piano.Width, this.Height - piano.Height);
            this.Controls.Add(pictureBoxNote);

            pictureBoxNote.Controls.Add(buttonMenu);
            buttonMenu.Location = new System.Drawing.Point(this.Width - buttonMenu.Width - 30, 5);
            buttonMenu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            buttonMenu.Enabled = true;
            buttonMenu.Visible = true;

            SendKeys.SendWait("{ENTER}");

        }

        /// <summary>
        /// Funkcija čisti FormGame formu u kojoj se inicijalno odvija igra te je priprema za sljedeći prikaz.
        /// </summary>
        /// <param name="width">Minimalna širina ekrana za prikaz.</param>
        /// <param name="height">Minimalna visina ekrana za prikaz.</param>
        private void clearFormGameFor(int width = 500, int height = 500)
        {            
            foreach (Control c in Controls)
            {
                c.Visible = false;
                c.Enabled = false;
            }
            KeyPreview = false;

            // po defaultu se veličina ektana može mijenjati
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.BackColor = System.Drawing.Color.Azure;
        }

        private void enableSavedLevels()
        {
            string path = @"..\..\Resources\levels.txt";
            if (!File.Exists(path)) return;
            StreamReader lvls = File.OpenText(path);
            string line;
            while ((line = lvls.ReadLine()) != null)
                chooseSongs.enable(Int32.Parse(line));
            lvls.Close();
        }

        /// <summary>
        /// Funkcija provjerava je li neki level spremljen.
        /// </summary>
        /// <param name="i">Broj levela.</param>
        private bool isLvlSaved(int i)
        {
            string path = @"..\..\Resources\levels.txt";
            if (!File.Exists(path)) return false;
            StreamReader lvls = File.OpenText(path);
            string line;
            while ((line = lvls.ReadLine()) != null)
                if (Int32.Parse(line) == i)
                {
                    lvls.Close();
                    return true;
                }
            lvls.Close();
            return false;
        }

        /// <summary>
        /// Funkcija sprema level.
        /// </summary>
        /// <param name="i">Broj levela.</param>
        private void saveLvl(int i)
        {
            string path = @"..\..\Resources\levels.txt";
            if (!File.Exists(path)) return;
            StreamWriter lvls = File.AppendText(path);
            lvls.WriteLine(i);
            lvls.Flush();
            lvls.Close();
        }

        #endregion
    }
}
