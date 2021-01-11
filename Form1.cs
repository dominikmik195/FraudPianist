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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            switch (e.KeyChar)
            {
                case 'q':
                    player.Stream = Properties.Resources.g_;
                    break;
                case 'a':
                    player.Stream = Properties.Resources.a;
                    break;
                case 'w':
                    player.Stream = Properties.Resources.a_;
                    break;
                case 's':
                    player.Stream = Properties.Resources.h;
                    break;
                case 'd':
                    player.Stream = Properties.Resources.c1;
                    break;
                case 'r':
                    player.Stream = Properties.Resources.c_1;
                    break;
                case 'f':
                    player.Stream = Properties.Resources.d1;
                    break;
                case 't':
                    player.Stream = Properties.Resources.d_1;
                    break;
                case 'g':
                    player.Stream = Properties.Resources.e1;
                    break;
                case 'h':
                    player.Stream = Properties.Resources.f1;
                    break;
                case 'u':
                    player.Stream = Properties.Resources.f_1;
                    break;
                case 'j':
                    player.Stream = Properties.Resources.g1;
                    break;
                case 'i':
                    player.Stream = Properties.Resources.g_1;
                    break;
                case 'k':
                    player.Stream = Properties.Resources.a1;
                    break;
                case 'o':
                    player.Stream = Properties.Resources.a_1;
                    break;
                case 'l':
                    player.Stream = Properties.Resources.h1;
                    break;
                case 'č':
                    player.Stream = Properties.Resources.c2;
                    break;
                case 'š':
                    player.Stream = Properties.Resources.c_2;
                    break;
                case 'ć':
                    player.Stream = Properties.Resources.d2;
                    break;
                case 'đ':
                    player.Stream = Properties.Resources.d_2;
                    break;
                case 'ž':
                    player.Stream = Properties.Resources.e2;
                    break;
                default:
                    player.Stream = Properties.Resources.silence;
                    break;
            }
            player.Play();
        }
    }
}
