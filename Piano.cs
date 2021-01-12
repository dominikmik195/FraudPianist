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

namespace piano
{
    public partial class Piano : UserControl
    {
        List<string> buttons = new List<string> { "g", "A", "H", "C1", "D1", "E1", "F1", "G1", "A1", "H1", "C2", "D2", "E2",
                                                    "G_", "A_", "C_1", "D_1", "F_1", "G_1", "A_1", "C_2", "D_2" };
        List<string> whites = new List<string> {"g", "A", "H", "C1", "D1", "E1", "F1", "G1", "A1", "H1", "C2", "D2", "E2"};
        List<string> blacks = new List<string> {"G_", "A_", "C_1", "D_1", "F_1", "G_1", "A_1", "C_2", "D_2"};

        // Inicijalizacija tipki jedne proširene oktave (g# - e2). "Ove komande igrač mora moći po volji izmijeniti."
        Dictionary<string, char> keys = new Dictionary<string, char>
        {
            {"G_", 'q'},
            {"A", 'a'},
            {"A_", 'w'},
            {"H", 's'},
            {"C1", 'd'},
            {"C_1", 'r'},
            {"D1", 'f'},
            {"D_1", 't'},
            {"E1", 'g'},
            {"F1", 'h'},
            {"F_1", 'u'},
            {"G1", 'j'},
            {"G_1", 'i'},
            {"A1", 'k'},
            {"A_1", 'o'},
            {"H1", 'l'},
            {"C2", 'č'},
            {"C_2", 'š'},
            {"D2", 'ć'},
            {"D_2", 'đ'},
            {"E2", 'ž'}
        };

        public Piano()
        {
            InitializeComponent();

            reshape_buttons();

            // polovicu prve tipke "g" ne možemo stisnuti već je tu radi izgleda klavira
            btng.Enabled = false;  
        }

        /// <summary> 
        /// Funkcija zaobljava dva donja vrha svakog gumba koji predstavlja tipku klavira.
        /// </summary>
        private void reshape_buttons()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                Button btn = this.Controls["btn" + buttons[i]] as Button;

                if(btn != null)
                {
                    Rectangle Rect = new Rectangle(0, 0, btn.Width, btn.Height);
                    GraphicsPath GraphPath = new GraphicsPath();

                    GraphPath.AddLine(0, 0, btn.Width, 0);
                    GraphPath.AddArc(Rect.X + Rect.Width - 25, Rect.Y + Rect.Height - 25, 25, 25, 0, 90);
                    GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - 25, 25, 25, 90, 90);

                    btn.Region = new Region(GraphPath);
                }
            }
        }

        /// <summary> 
        /// Funkcija prima upravo pritisnutu tipku i provjerava koja je to tipka neovisno o tome je li CapsLock uključen ili nije.
        /// Ukoliko je primljena tipka postavljena kao tipka klavira svira odgovarajući ton.
        /// </summary>
        public void play(char keyPressed)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            switch (Char.ToLower(keyPressed))
            {
                case char c when c == keys["G_"]:
                    btnG_.PerformClick(); // poziva Click event bez fizičkog klika
                    player.Stream = Properties.Resources.g_;
                    break;
                case char c when c == keys["A"]:
                    btnA.PerformClick();
                    player.Stream = Properties.Resources.a;
                    break;
                case char c when c == keys["A_"]:
                    btnA_.PerformClick();
                    player.Stream = Properties.Resources.a_;
                    break;
                case char c when c == keys["H"]:
                    btnH.PerformClick();
                    player.Stream = Properties.Resources.h;
                    break;
                case char c when c == keys["C1"]:
                    btnC1.PerformClick();
                    player.Stream = Properties.Resources.c1;
                    break;
                case char c when c == keys["C_1"]:
                    btnC_1.PerformClick();
                    player.Stream = Properties.Resources.c_1;
                    break;
                case char c when c == keys["D1"]:
                    btnD1.PerformClick();
                    player.Stream = Properties.Resources.d1;
                    break;
                case char c when c == keys["D_1"]:
                    btnD_1.PerformClick();
                    player.Stream = Properties.Resources.d_1;
                    break;
                case char c when c == keys["E1"]:
                    btnE1.PerformClick();
                    player.Stream = Properties.Resources.e1;
                    break;
                case char c when c == keys["F1"]:
                    btnF1.PerformClick();
                    player.Stream = Properties.Resources.f1;
                    break;
                case char c when c == keys["F_1"]:
                    btnF_1.PerformClick();
                    player.Stream = Properties.Resources.f_1;
                    break;
                case char c when c == keys["G1"]:
                    btnG1.PerformClick();
                    player.Stream = Properties.Resources.g1;
                    break;
                case char c when c == keys["G_1"]:
                    btnG_1.PerformClick();
                    player.Stream = Properties.Resources.g_1;
                    break;
                case char c when c == keys["A1"]:
                    btnA1.PerformClick();
                    player.Stream = Properties.Resources.a1;
                    break;
                case char c when c == keys["A_1"]:
                    btnA_1.PerformClick();
                    player.Stream = Properties.Resources.a_1;
                    break;
                case char c when c == keys["H1"]:
                    btnH1.PerformClick();
                    player.Stream = Properties.Resources.h1;
                    break;
                case char c when c == keys["C2"]:
                    btnC2.PerformClick();
                    player.Stream = Properties.Resources.c2;
                    break;
                case char c when c == keys["C_2"]:
                    btnC_2.PerformClick();
                    player.Stream = Properties.Resources.c_2;
                    break;
                case char c when c == keys["D2"]:
                    btnD2.PerformClick();
                    player.Stream = Properties.Resources.d2;
                    break;
                case char c when c == keys["D_2"]:
                    btnD_2.PerformClick();
                    player.Stream = Properties.Resources.d_2;
                    break;
                case char c when c == keys["E2"]:
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
        /// Ako jest postavlja boju tipke na boju defaultnu za odgovarajuću otpuštenu tipku.
        /// </summary>
        public void keySilence(string keyRealised)
        {
            char key = convertKeyName(keyRealised);

            string buttonName = "btn" + keys.FirstOrDefault(x => x.Value == key).Key;
            Button btn = this.Controls[buttonName] as Button;

            if (btn != null && whites.Contains(keys.FirstOrDefault(x => x.Value == key).Key))
            {
                btn.BackColor = Color.White;
            }
            else if (btn != null && blacks.Contains(keys.FirstOrDefault(x => x.Value == key).Key))
            {
                btn.BackColor = Color.Black;
            }
        }

        /// <summary> 
        /// Funkcija prima uprabo otpuštenu tipku provjerava je li ona jedno od hrvatskih slova č,ć,ž,š i đ (ZASADdddddDDDDDD!!) čiji kod je specifičan. 
        /// Ako jest vraća ime tona pridruženog toj tipki, a ako nije vraća Unicode "null" character.
        /// </summary>
        private char convertKeyName(string keyRealised)
        {
            char key = '\0';
            if (keyRealised.ToCharArray().Length != 1)
            {
                switch (keyRealised)
                {
                    case "oem1":
                        key = 'č';
                        break;
                    case "oem4":
                        key = 'š';
                        break;
                    case "oemopenbrackets": // uključen CapsLock
                        key = 'š';
                        break;
                    case "oem5":
                        key = 'ž';
                        break;
                    case "oem6":
                        key = 'đ';
                        break;
                    case "oem7":
                        key = 'ć';
                        break;
                    default:
                        break;
                }
            }
            else
                key = keyRealised.ToCharArray()[0];

            return key;
        }


        // ako nam slučajno u igri ne budu trebali svi ovu klikovi zasebno, spojiti ih u dvije funkcije whiteButton_Click i blackButton_Click 
        private void btnA_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnA.BackColor = Color.Orchid;
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnH.BackColor = Color.Orchid;
        }

        private void btnC1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnC1.BackColor = Color.Orchid;
        }

        private void btnD1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnD1.BackColor = Color.Orchid;
        }

        private void btnE1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnE1.BackColor = Color.Orchid;
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnF1.BackColor = Color.Orchid;
        }

        private void btnG1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnG1.BackColor = Color.Orchid;
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnA1.BackColor = Color.Orchid;
        }

        private void btnH1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnH1.BackColor = Color.Orchid;
        }

        private void btnC2_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnC2.BackColor = Color.Orchid;
        }

        private void btnD2_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnD2.BackColor = Color.Orchid;
        }

        private void btnE2_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnE2.BackColor = Color.Orchid;
        }

        private void btnG__Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnG_.BackColor = Color.DarkOrchid;
        }

        private void btnA__Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnA_.BackColor = Color.DarkOrchid;
        }

        private void btnC_1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnC_1.BackColor = Color.DarkOrchid;
        }

        private void btnD_1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnD_1.BackColor = Color.DarkOrchid;
        }

        private void btnF_1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnF_1.BackColor = Color.DarkOrchid;
        }

        private void btnG_1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnG_1.BackColor = Color.DarkOrchid;
        }

        private void btnA_1_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnA_1.BackColor = Color.DarkOrchid;
        }

        private void btnC_2_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnC_2.BackColor = Color.DarkOrchid;
        }

        private void btnD_2_Click(object sender, EventArgs e)
        {
            if (e as MouseEventArgs != null)
                return;
            btnD_2.BackColor = Color.DarkOrchid;
        }
    }
}
