using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Windows.Forms;
using System.Drawing;

namespace piano
{
    /// <summary>
    /// Klasa koja predstavlja samu igru.
    /// </summary>
    class Game
    {
        private Level level;

        // string iz rsc file-a s točnim notama('C1', 'C_1',...) od početka do kraja pjesme
        // razmak(' ') označava pauzu u pjesmi
        private string song;
        // pokazivač na sljedeću 'neobrađenu' notu(ona koja još nema svoju pločicu) iz stringa song
        private int currentNoteIndex;

        // lista 'živih' pločica - one koje nisu pale ispod klavira niti su odsvirane
        private List<Tile> tiles;
        // zadnje stvorena pločica (odgovara zadnjoj pročitanoj noti)
        private Tile previousTile;
        // najniža 'živa' pločica (ona koju treba sljedeću odsvirati)
        public Tile lowestTile;

        //score...

        /// <summary>
        /// Konstruktor igre.
        /// </summary>
        /// <param name="level">1-5</param>
        public Game(int level)
        {
            this.level = Level.getLevel(level);

            song = Properties.Resources.ResourceManager.GetString(this.level.songName);
            currentNoteIndex = 0;

            tiles = new List<Tile>();
            lowestTile = null;
            previousTile = null;
        }

        /// <summary>
        /// Provjerava je li pjesma završila.
        /// </summary>
        /// <returns><code>true</code> ako je pjesma gotova, <code>false</code> inače.</returns>
        public bool isOver()
        {
            return (currentNoteIndex == song.Length && tiles.Count == 0);
        }

        /// <summary>
        /// Čita sljedeću notu iz stringa song i pretvara je u pločicu.
        /// Uzima u obzir pauze između nota.
        /// </summary>
        public void parseOneNote()
        {
            if (currentNoteIndex == song.Length)
            {
                // nema više nota za pročitati
                return;
            }
            // izbroji eventualne pauze
            int pauseCount = 0;
            while (song[currentNoteIndex] == ' ')
            {
                pauseCount++;
                currentNoteIndex++;
            }
            //nova nota
            string note = song[currentNoteIndex++].ToString();
            while (currentNoteIndex < song.Length && "_12".Contains(song[currentNoteIndex].ToString()))
            {
                note += song[currentNoteIndex].ToString();
                currentNoteIndex++;
            }
            string newNoteType = note.Contains("_") ? "black" : "white";
            // klavirska tipka te note
            var noteButton = Application.OpenForms["FormGame"].Controls["piano"].Controls["btn" + note];
            // nova pločica će padati u ravnini s odgovarajućim gumbom, ali je širine za 1.5 manja od širine gumba
            double newNoteX = noteButton.Location.X + (noteButton.Width / 2) - (noteButton.Width / 3);
            double newNoteHeight = (newNoteType.Equals("black")) ? level.blackTilesHeight : level.whiteTilesHeight;

            // nova pločica se crta u ovisnosti od zadnje nacrtane pločice
            double lastY = 0;
            if (previousTile != null)
            {
                lastY = previousTile.Y;
            }
            double newNoteY = lastY - newNoteHeight - level.minSpaceBetweenTiles * (pauseCount + 1);

            Tile newTile = new Tile(newNoteType, newNoteX, newNoteY, noteButton.Width / 1.5, newNoteHeight, note);

            // ažuriranje previous i lowest tile
            if (tiles.Count == 0)
            {
                lowestTile = newTile;
            }
            previousTile = newTile;
           
            tiles.Add(newTile);
        }

        /// <summary>
        /// Ažurira poziciju svih pločica.
        /// </summary>
        public void update()
        {
            // ako je igra gotova, ne radi ništa
            if (isOver())
            {
                return;
            }
            // update postojećih pločica
            for (int i = tiles.Count - 1; i >= 0; i--)
            {
                if (tiles[i].Y >= Application.OpenForms["FormGame"].Controls["tilesBox"].Height)
                {
                    // pločica je pala
                    tiles.RemoveAt(i);
                    if (tiles.Count != 0)
                    {
                        lowestTile = tiles.First();
                    }
                }
                else
                {
                    tiles[i].Y += level.renderStep;
                }
            }
        }

        /// <summary>
        /// Iscrtava sve 'žive' pločice na igraču plohu.
        /// </summary>
        /// <param name="box">Igrača ploha iznad klavira.</param>
        public void render(PictureBox box)
        {
            Bitmap bitmap = new Bitmap(box.Width, box.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            foreach (var tile in tiles)
            {
                tile.render(graphics);
            }
            box.Image = bitmap;
        }

        /// <summary>
        /// Briše najnižu pločicu s igrače plohe 
        /// te ažurira lowestTile na sljedeću najnižu ako takva postoji.
        /// </summary>
        public void hit()
        {
            tiles.RemoveAt(0);
            if (tiles.Count != 0)
            {
                lowestTile = tiles.First();
            }
            else
            {
                lowestTile = null;
            }
        }

        /// <summary>
        /// Resetira igru. Level se ne mijenja.
        /// </summary>
        public void reset()
        {
            currentNoteIndex = 0;
            tiles.Clear();
            lowestTile = null;
            previousTile = null;
        }
    }
}
