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
    public partial class SongList : UserControl
    {
        public SongList()
        {
            InitializeComponent();
        }
        public event EventHandler Song1, Song2, Song3, Menu;

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
