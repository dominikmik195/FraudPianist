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

        public FormGame()
        {
            InitializeComponent();            
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

    }
}
