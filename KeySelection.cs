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
    /// Forma se koristi za izmjenu zadanih komandi za svaku klavirsku tipku.
    /// </summary>
    public partial class KeySelection : Form
    {
        public KeySelection()
        {
            InitializeComponent();
        }

        #region Events

        /// <summary>
        /// Klikom miša na gumb koji sadrži trenutno zadanu tipku za klavirsku tipku svira se ton 
        /// i otvara se forma za odabir nove tipke.
        /// </summary>
        private void key_MouseClick(object sender, MouseEventArgs e)
        {
            if((sender as Button) != null)
            {
                string note = (sender as Button).Name.Substring(3);

                string title = (note.Contains('_')) ? note.Remove(1, 1) + "#" : note;

                string value = (sender as Button).Text;

                pianoKeySelection.play(FormGame.GameKeys[note], FormGame.GameKeys);

                Form keyPressForm = new KeyPress(title);
                keyPressForm.Tag = sender as Button;
                keyPressForm.Show(this);

                Application.OpenForms["KeySelection"].Enabled = false;
            }
        }

        #endregion
    }
}
