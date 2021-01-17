using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piano
{
    /// <summary> 
    /// Klasa koja će služiti za čuvanje bitnih konstanti specifičnih za neki level.
    /// </summary>
    public abstract class Enumeration
    {
        // ime pjesme u resx file-u
        public string songName { get; private set; }
        // visina pločica koje se odnose na bijele tipke klavira
        public double whiteTilesHeight { get; private set; }
        // visina pločica koje se odnose na crne tipke klavira
        public double blackTilesHeight { get; private set; }
        // vertikalni razmak pločica susjednih tonova (bez pauza između)
        public double minSpaceBetweenTiles { get; private set; }
        // "brzina pločica" tj. korak za koliko se u jednom tick-u spuštaju pločice
        public double renderStep { get; private set; }
        // numerička reprezentacija levela
        public int levelNumber { get; set; }
        public int scorePossible { get; set; }

        protected Enumeration(string s, double wt, double bt, double ms, double rs, int ln)
            => (songName, whiteTilesHeight, blackTilesHeight, minSpaceBetweenTiles, renderStep, levelNumber) = (s, wt, bt, ms, rs, ln);

        protected Enumeration(string s, double wt, double bt, double ms, double rs)
            => (songName, whiteTilesHeight, blackTilesHeight, minSpaceBetweenTiles, renderStep) = (s, wt, bt, ms, rs);
    }

    /// <summary> 
    /// Klasa koja predstavlja enumeraciju sa informacijama o svim levelima igre.
    /// </summary>
    public class Level
        : Enumeration
    {
        public static Level ONE = new Level("Twinkle Twinkle", 110, 95, 40, 7, 1);
        public static Level TWO = new Level("Fur Elise", 100, 85, 30, 7, 2);
        public static Level THREE = new Level("Seniorita", 90, 75, 25, 8, 3);
        public static Level FOUR = new Level("La Bamba", 80, 65, 20, 9, 4); 
        public static Level FIVE = new Level("Habanera", 70, 55, 15, 10, 5); 

        public Level(string song, double whiteWidth, double blackWidth, double space, double step, int number)
                    : base(song, whiteWidth, blackWidth, space, step, number)
        {
            computeMaxScore();
        }
        public static Level getLevel(int i)
        {
            switch (i)
            {
                case 1:
                    return ONE;
                case 2:
                    return TWO;
                case 3:
                    return THREE;
                case 4:
                    return FOUR;
                case 5:
                    return FIVE;
                default:
                    return ONE;
            }
        }
        
        /// <summary>
        /// Računa maksimalan broj bodova koji se može osvojiti na nekom levelu.
        /// </summary>
        private void computeMaxScore()
        {
            // Najveći mogući broj bodova je onaj koji se ostvari ako su sve note
            // idealno odsvirane.
            scorePossible = 0;
            int factor = 1;
            int noteCount = 0;
            string song = Properties.Resources.ResourceManager.GetString(songName);
            for (int i = 0; i < song.Length; i++)
            {
                if (song[i] != ' ' && !Char.IsDigit(song[i]))
                {
                    noteCount++;
                }
            }
            while (noteCount > 9)
            {
                // Dobivamo po 10*faktor bodova za svaku od 10 idealno odsviranih nota zaredom:
                scorePossible += factor * 10 * 10;
                // Za svakih deset idealno odsviranih nota, faktor se poveća za 1,
                // ako još nije dosegao najveću vrijednost:
                if (factor < 5) factor++;
                noteCount -= 10;
            }
            // Dodamo još bodove za ostale note:
            scorePossible += factor * 10 * noteCount;
            return;
        }
    }
}

