using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

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
        // zadnje ispravno odsvirana pločica
        private Tile lastPlayedTile;
        // najniža pločica koju nije 'prošla' kontrolnu liniju (ona koju treba sljedeću odsvirati)
        public Tile lowestTile;

        // pomoćna varijabla koja služi za određivanje perioda u kojem je prikazan
        // pravokutnih iznad točno odsvirane note
        private int counterHit;

        // ukupan broj ostvarenih bodova
        private int score;
        // ukupan broj točno pritisnutih tipki zaredom
        private int combo;
        // varijabla koja pamti je li u tijeku combo
        private bool combo_made;


        #region Properties
        public Level Level
        {
            get { return level; }
        }

        public int Score
        {
            get { return score; }
        }

        public int Combo
        {
            get { return combo; }
        }

        public bool Combo_made
        {
            get { return combo_made; }
            set { combo_made = value; }
        }

        #endregion
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
            lastPlayedTile = null;
            counterHit = 0;

            combo_made = false;
        }

        /// <summary>
        /// Provjerava je li pjesma završila.
        /// </summary>
        /// <returns><code>true</code> ako je pjesma gotova, <code>false</code> inače.</returns>
        public bool isOver()
        {
            Console.WriteLine("counterhit" + counterHit.ToString());
            return (currentNoteIndex == song.Length && tiles.Count == 0 && counterHit == 0);
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
            // update postojećih pločica
            for (int i = tiles.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(tiles[i].Y + tiles[i].Id);
                // kada pločica pređe kontrolnu liniju, više se ne može odsvirati
                if (tiles[i].Y >= Application.OpenForms["FormGame"].Controls["tilesBox"].Height - 72 && 
                    tiles.Count >= 2)
                {
                    lowestTile = tiles[1];
                }
                // kada pločica padne do kraja, više se ne prikazuje
                if (tiles[i].Y >= Application.OpenForms["FormGame"].Controls["tilesBox"].Height)
                {
                    tiles.RemoveAt(i);
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

            // crtanje pravokutnika iznad klavirske tipke
            if (lastPlayedTile != null && counterHit > 0)
            {
                renderHit(graphics);
                counterHit--;
            }

            // crtanje kontrolne linije
            var tilesBoxControl = Application.OpenForms["FormGame"].Controls["tilesBox"];
            float controlLineY = tilesBoxControl.Height - 80;
            graphics.DrawLine(new Pen(Color.DarkSlateBlue, 8), 0, controlLineY, tilesBoxControl.Width, controlLineY);
           
            // crtanje pločica
            foreach (var tile in tiles)
            {
                tile.render(graphics);
            }
            box.Image = bitmap;
        }

        /// <summary>
        /// Iscrtava pravokutnik iznad točno odvirane klavirske tipke.
        /// </summary>
        /// <param name="graphics"></param>
        private void renderHit(Graphics graphics)
        {
            int tilesBoxHeight = Application.OpenForms["FormGame"].Controls["tilesBox"].Height;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, tilesBoxHeight),
                new Point(0, 0),
                Color.FromArgb((255 - (3 - counterHit) * 60), Color.Orchid),
                Color.FromArgb((255 - (3 - counterHit) * 70), Color.Azure)
            );
            Button lastPlayedButton = Application.OpenForms["FormGame"].Controls["piano"].Controls["btn" + lastPlayedTile.Id] as Button;

            graphics.FillRectangle(brush, lastPlayedButton.Location.X, 0, lastPlayedButton.Width, tilesBoxHeight);
        }

        /// <summary>
        /// Briše najnižu pločicu s igrače plohe 
        /// te ažurira lowestTile na sljedeću najnižu ako takva postoji.
        /// Dodaje 10 (ili više, ovisno o postignutom nizu) bodova.
        /// </summary>
        public void hit(int space)
        {
            if (lowestTile.Y + lowestTile.Height < space / 2) score += 2;
            else if (lowestTile.Y + lowestTile.Height < space - 80) score += 5;
            else
            {
                int faktor = combo / 10 + 1;
                if (faktor > 5) faktor = 5;
                score += 10 * faktor;
                combo += 1;
            }

            // ažuriranje info za crtanje pravokutnika iznad tipke klavira
            lastPlayedTile = lowestTile;
            counterHit = 3;

            tiles.Remove(lowestTile);
            if (tiles.Count != 0)
            {
                lowestTile = tiles.First();
            }
            else
            {
                lowestTile = null;
            }
        }
        public void wrong()
        {
            score -= 2;
            if (score < 0) score = 0;
            combo = 0;
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
            lastPlayedTile = null;
            counterHit = 0;

            this.render(Application.OpenForms["FormGame"].Controls["tilesBox"] as PictureBox);
        }
    }
}
