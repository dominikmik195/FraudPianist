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
    /// Forma koja se koristi za odabir nove tipke određenog tona.
    /// </summary>
    public partial class KeyPress : Form
    {
        public KeyPress()
        {
            InitializeComponent();
        }

        public KeyPress(string note)
        {
            InitializeComponent();

            lbPressKey.Text = "Press the key you want to set for the tone " + note.ToLower() + "!";
        }

        #region Events

        /// <summary>
        /// Ako pritisnutu tipku nije moguće postaviti za sviranje odabranog tona forma ostaje otvorena i omogućeno je biranje nove tipke.
        /// Inače se pritisnuta tipka postavlja za odabrani ton u daljnoj igri.
        /// Korisnik u svakom trenu može odustati od odabita pritiskom na gumb X za izlaz iz forme.
        /// </summary>
        private void KeyPress_KeyDown(object sender, KeyEventArgs e)
        {
            Button btn = this.Tag as Button;
            string note = btn.Name.Substring(3);
            string oldKey = btn.Text;
            string pressedKeyName = (new KeysConverter()).ConvertToString(e.KeyCode);

            if (string.Equals(pressedKeyName, oldKey, StringComparison.CurrentCultureIgnoreCase))
                    this.Close();

            if (isKeyUsed(pressedKeyName))
            {
                lbPressKey.Text = "Try again! The key is already in use.";
                return;
            }

            if (note.Contains('_'))
            {
                if (pressedKeyName.Length < 2)
                    (this.Tag as Button).Font = new Font("Microsoft Sans Serif", 15);
                else
                    (this.Tag as Button).Font = new Font("Microsoft Sans Serif", 6);
            }
            else
            {
                if (pressedKeyName.Length < 2)
                    (this.Tag as Button).Font = new Font("Microsoft Sans Serif", 20 );
                else
                    (this.Tag as Button).Font = new Font("Microsoft Sans Serif", 12);
            }

            (this.Tag as Button).Text = pressedKeyName;
            FormGame.GameKeys[note] = pressedKeyName;

            this.Close(); 
        }

        private void KeyPress_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms["KeySelection"].Enabled = true;
        }

        #endregion

        #region Private

        /// <summary>
        /// Funkcija koja provjerava je li novoodabrana tipka za neki ton već u upotrebi.
        /// </summary>
        private bool isKeyUsed(string key)
        {
            foreach (KeyValuePair<string, string> dict in FormGame.GameKeys)
            {
                if (string.Equals(dict.Value, key, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        #endregion

    }
}
