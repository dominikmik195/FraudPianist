using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Drawing.Drawing2D;
using System.Windows.Input; // Keyboard
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace piano
{
    public partial class Piano : UserControl
    {
        List<string> buttons = new List<string> { "g", "A", "H", "C1", "D1", "E1", "F1", "G1", "A1", "H1", "C2", "D2", "E2",
                                                    "G_", "A_", "C_1", "D_1", "F_1", "G_1", "A_1", "C_2", "D_2" };
        List<string> whites = new List<string> {"g", "A", "H", "C1", "D1", "E1", "F1", "G1", "A1", "H1", "C2", "D2", "E2"};
        List<string> blacks = new List<string> {"G_", "A_", "C_1", "D_1", "F_1", "G_1", "A_1", "C_2", "D_2"};

        public Piano()
        {
            InitializeComponent();

            reshape_buttonts();

            // polovicu prve tipke "g" ne možemo stisnuti već je tu radi izgleda klavira
            btng.Enabled = false;
        }


        #region Events

        /// <summary>
        /// Događaj koji boja pritisnutu bijelu tipku klavira u "Orchid".
        /// </summary>
        private void whiteButton_Click(object sender, EventArgs e)
        {
            if (e as System.Windows.Forms.MouseEventArgs != null)
                return;

            if (this.Name == "pianoKeySelection")
                return;

            if (sender as Button != null)
                (sender as Button).BackColor = Color.Orchid;
        }

        /// <summary>
        /// Događaj koji boja pritisnutu crnu tipku klavira i "DarkOrchid".
        /// </summary>
        private void blackButton_Click(object sender, EventArgs e)
        {
            if (e as System.Windows.Forms.MouseEventArgs != null)
                return;

            if (this.Name == "pianoKeySelection")
                return;

            if (sender as Button != null)
                (sender as Button).BackColor = Color.DarkOrchid;
        }

        #endregion

        #region Public

        /// <summary> 
        /// Funkcija prima upravo pritisnutu tipku i provjerava je li ona postavljena za neku od klavirskih tipki.
        /// Ukoliko jest onemogućeva se pritisak drugih tipki klavira dok je ona pritisnuta i svira se odgovarajući ton.
        /// Inače se "svira tišina".
        /// </summary>
        /// <param name="keyPressed">String koji predstavlja naziv upravo pritisnute tipke.</param>
        /// <param name="gameKeys">Riječnik igraćih tipki.</param>
        public void play(string keyPressed, Dictionary<string, string> gameKeys)
        {
            if (gameKeys.FirstOrDefault(x => x.Value == keyPressed).Key != null)
            {
                disableOtherButtons(keyPressed, gameKeys);
            }

            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            switch (keyPressed)
            {
                case string c when c == gameKeys["G_"]:
                    btnG_.PerformClick(); // poziva Click event bez fizičkog klika
                    player.Stream = Properties.Resources.g_;
                    break;
                case string c when c == gameKeys["A"]:
                    btnA.PerformClick();
                    player.Stream = Properties.Resources.a;
                    break;
                case string c when c == gameKeys["A_"]:
                    btnA_.PerformClick();
                    player.Stream = Properties.Resources.a_;
                    break;
                case string c when c == gameKeys["H"]:
                    btnH.PerformClick();
                    player.Stream = Properties.Resources.h;
                    break;
                case string c when c == gameKeys["C1"]:
                    btnC1.PerformClick();
                    player.Stream = Properties.Resources.c1;
                    break;
                case string c when c == gameKeys["C_1"]:
                    btnC_1.PerformClick();
                    player.Stream = Properties.Resources.c_1;
                    break;
                case string c when c == gameKeys["D1"]:
                    btnD1.PerformClick();
                    player.Stream = Properties.Resources.d1;
                    break;
                case string c when c == gameKeys["D_1"]:
                    btnD_1.PerformClick();
                    player.Stream = Properties.Resources.d_1;
                    break;
                case string c when c == gameKeys["E1"]:
                    btnE1.PerformClick();
                    player.Stream = Properties.Resources.e1;
                    break;
                case string c when c == gameKeys["F1"]:
                    btnF1.PerformClick();
                    player.Stream = Properties.Resources.f1;
                    break;
                case string c when c == gameKeys["F_1"]:
                    btnF_1.PerformClick();
                    player.Stream = Properties.Resources.f_1;
                    break;
                case string c when c == gameKeys["G1"]:
                    btnG1.PerformClick();
                    player.Stream = Properties.Resources.g1;
                    break;
                case string c when c == gameKeys["G_1"]:
                    btnG_1.PerformClick();
                    player.Stream = Properties.Resources.g_1;
                    break;
                case string c when c == gameKeys["A1"]:
                    btnA1.PerformClick();
                    player.Stream = Properties.Resources.a1;
                    break;
                case string c when c == gameKeys["A_1"]:
                    btnA_1.PerformClick();
                    player.Stream = Properties.Resources.a_1;
                    break;
                case string c when c == gameKeys["H1"]:
                    btnH1.PerformClick();
                    player.Stream = Properties.Resources.h1;
                    break;
                case string c when c == gameKeys["C2"]:
                    btnC2.PerformClick();
                    player.Stream = Properties.Resources.c2;
                    break;
                case string c when c == gameKeys["C_2"]:
                    btnC_2.PerformClick();
                    player.Stream = Properties.Resources.c_2;
                    break;
                case string c when c == gameKeys["D2"]:
                    btnD2.PerformClick();
                    player.Stream = Properties.Resources.d2;
                    break;
                case string c when c == gameKeys["D_2"]:
                    btnD_2.PerformClick();
                    player.Stream = Properties.Resources.d_2;
                    break;
                case string c when c == gameKeys["E2"]:
                    btnE2.PerformClick();
                    player.Stream = Properties.Resources.e2;
                    break;
                default:
                    player.Stream = Properties.Resources.silence;
                    break;
            }

            player.Play();          
        }

        /// <summary> 
        /// Funkcija provjerava je li otpuštena tipka zaista tipka klavira. 
        /// Ako jest postavlja boju tipke na boju defaultnu za odgovarajuću (bijelu ili crnu) otpuštenu tipku i omogućava pritisak svih tipki klavira.
        /// </summary>
        /// <param name="keyRealised">String koji predstavlja naziv upravo otpuštene tipke.</param>
        /// <param name="gameKeys">Riječnik igraćih tipki.</param>
        public void keySilence(string keyRealised, Dictionary<string, string> gameKeys)
        {
            string buttonName = "btn" + gameKeys.FirstOrDefault(x => x.Value == keyRealised).Key;
            Button btn = this.Controls[buttonName] as Button;

            if (btn != null)
            {
                if (whites.Contains(gameKeys.FirstOrDefault(x => x.Value == keyRealised).Key))
                {
                    btn.BackColor = Color.White;
                }
                else if (blacks.Contains(gameKeys.FirstOrDefault(x => x.Value == keyRealised).Key))
                {
                    btn.BackColor = Color.Black;
                }
            }

            enableAllButtons();
        }

        #endregion

        #region Private

        /// <summary> 
        /// Funkcija zaobljava dva donja vrha svakog gumba koji predstavlja tipku klavira.
        /// </summary>
        private void reshape_buttonts()
        {
            for (int i = 0; i < buttons.Count; i++)
            {

                Button btn = this.Controls["btn" + buttons[i]] as Button;

                if (btn != null)
                {
                    Rectangle Rect = new Rectangle(0, 0, btn.Width, btn.Height);
                    GraphicsPath GraphPath = new GraphicsPath();

                    GraphPath.AddLine(0, 0, btn.Width, 0);
                    GraphPath.AddArc(Rect.X + Rect.Width - 25, Rect.Y + Rect.Height - 25, 25, 25, 0, 90);
                    GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - 25, 25, 25, 90, 90);

                    btn.Region = new Region(GraphPath);
                }
            }
            Console.WriteLine("redshape");
        }

        /// <summary> 
        /// Funkcija stavlja u funkciju sve tipke klavira koje sudjeluju u igri (izuzima tipku "g").
        /// </summary>
        private void enableAllButtons()
        {
            for (int i = 1; i < buttons.Count; i++)
            {
                Button btn = this.Controls["btn" + buttons[i]] as Button;

                if (btn != null)
                {
                    btn.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Funkcija onemogućava pritisak svih klavirskih tipki izuzev tipke "key". Tipka "g" je već onemogućena.
        /// </summary>
        /// <param name="key">String koji predstavlja naziv upravo pritisnute tipke.</param>
        /// <param name="gameKeys">Riječnik igraćih tipki.</param>
        private void disableOtherButtons(string key, Dictionary<string, string> gameKeys)
        {
            for (int i = 1; i < buttons.Count; i++)
            {
                Button btn = this.Controls["btn" + buttons[i]] as Button;

                if (btn != null && gameKeys[buttons[i]] != key)
                {
                    btn.Enabled = false;
                }
            }
        }

        #endregion
    }
}
