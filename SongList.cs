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
    /// Klasa (user control) koja predstavlja izbornik za odabir pjesme za sviranje.
    /// </summary>
    public partial class SongList : UserControl
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public SongList()
        {
            InitializeComponent();
            // Postavimo tipke za sve levele osim prvog na neomogućeno
            buttonSong2.Enabled = false;
            buttonSong3.Enabled = false;
        }
        public event EventHandler Song1, Song2, Song3, Menu;

        /// <summary>
        /// Postavlja odgovarajući naslov pjesme na odgovarajuću tipku.
        /// </summary>
        public void set_title(string title, int i)
        {
            switch (i)
            {
                case 1:
                    buttonSong1.Text = title;
                    break;
                case 2:
                    buttonSong2.Text = title;
                    break;
                case 3:
                    buttonSong3.Text = title;
                    break;
                case 4:
                    buttonSong3.Text = title;
                    break;
                default: buttonSong1.Text = title;
                    break;
            }
        }

        /// <summary>
        /// Omogućava tipku za pristup određenoj pjesmi.
        /// </summary>
        public void enable(int i)
        {
            switch (i)
            {
                case 1:
                    buttonSong1.Enabled = true;
                    break;
                case 2:
                    buttonSong2.Enabled = true;
                    break;
                case 3:
                    buttonSong3.Enabled = true;
                    break;
                case 4:
                    buttonSong3.Enabled = true;
                    break;
                default:
                    buttonSong1.Enabled = true;
                    break;
            }
        }
        // Nadalje funkcije koje reagiraju na klikove tipki:
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            if (Menu != null) Menu(sender, e);
        }

        private void buttonSong3_Click(object sender, EventArgs e)
        {
            if (Song3 != null) Song3(sender, e);
        }

        private void buttonSong2_Click(object sender, EventArgs e)
        {
            if (Song2 != null) Song2(sender, e);
        }

        private void buttonSong1_Click(object sender, EventArgs e)
        {
            if (Song1 != null) Song1(sender, e);
        }
    }
}
