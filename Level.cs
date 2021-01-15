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
        public int levelNumber { get; private set; }

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
        public static Level ONE = new Level("twinkle", 80, 60, 40, 7, 1);
        public static Level TWO = new Level("swanlake", 80, 60, 40, 6, 2); //TODO
        public static Level THREE = new Level("twinkle", 80, 60, 40, 5, 3); //TODO
        public static Level FOUR = new Level("twinkle", 80, 60, 40, 5, 4); //TODO
        public static Level FIVE = new Level("twinkle", 80, 60, 40, 5, 5); //TODO

        public Level(string song, double whiteWidth, double blackWidth, double space, double step, int number)
                    : base(song, whiteWidth, blackWidth, space, step, number)
        {
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
    }
}

