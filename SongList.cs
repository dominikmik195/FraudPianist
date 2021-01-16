using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        /// Konstruktor klase.
        /// </summary>
        public SongList()
        {
            InitializeComponent();
            buttonLevel2.Enabled = false;
            buttonLevel3.Enabled = false;
            buttonLevel4.Enabled = false;
            buttonLevel5.Enabled = false;
        }
        public event EventHandler Level1, Level2, Level3, Level4, Level5;

        /// <summary>
        /// Postavlja odgovarajući naslov pjesme na odgovarajuću tipku.
        /// </summary>
        public void set_title(string title, int i)
        {
            switch (i)
            {
                case 1:
                    buttonLevel1.Text = title;
                    break;
                case 2:
                    buttonLevel2.Text = title;
                    break;
                case 3:
                    buttonLevel3.Text = title;
                    break;
                case 4:
                    buttonLevel4.Text = title;
                    break;
                default:
                    buttonLevel5.Text = title;
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
                    buttonLevel1.Enabled = true;
                    break;
                case 2:
                    buttonLevel2.Enabled = true;
                    break;
                case 3:
                    buttonLevel3.Enabled = true;
                    break;
                case 4:
                    buttonLevel4.Enabled = true;
                    break;
                default:
                    buttonLevel5.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// Provjerava je li određeni level omogućen.
        /// </summary>
        /// 
        public bool isEnabled(int i)
        {
            switch (i)
            {
                case 1:
                    return buttonLevel1.Enabled;
                case 2:
                    return buttonLevel2.Enabled;
                case 3:
                    return buttonLevel3.Enabled;
                case 4:
                    return buttonLevel4.Enabled;
                default:
                    return buttonLevel5.Enabled;
            }
        }

        // Nadalje funkcije koje reagiraju na klikove tipki:
        private void buttonLevel1_Click(object sender, EventArgs e)
        {
            if (Level1 != null) Level1(sender, e);
        }

        private void buttonLevel2_Click(object sender, EventArgs e)
        {
            if (Level2 != null) Level2(sender, e);
        }

        private void buttonLevel3_Click(object sender, EventArgs e)
        {
            if (Level3 != null) Level3(sender, e);
        }

        private void buttonLevel4_Click(object sender, EventArgs e)
        {
            if (Level4 != null) Level4(sender, e);
        }

        private void buttonLevel5_Click(object sender, EventArgs e)
        {
            if (Level5 != null) Level5(sender, e);
        }

    }
}
