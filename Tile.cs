using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace piano
{
    /// <summary> 
    /// Klasa koja predstavlja padajuću pločicu.
    /// </summary>
    class Tile
    {
        private double x, y, width, height;

        private string id; // nota na koju se odnosi (A_-E2)
        private string type; // "white" ili "black"

        // za iscrtavanje pločice
        private Brush brush;
        private Pen pen;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="type"> Tip pločice ovisno na kakvu se klavirsku tipku odnosi - "white" ili "black".</param>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="note"> Nota na koju se pločica odnosi (A_-E2).</param>
        public Tile(string type, double xPosition, double yPosition, double width, double height, string note)
        {
            this.type = type;
            if (type == "white")
            {
                brush = new SolidBrush(Color.Teal);
            }
            else
            {
                brush = new HatchBrush(HatchStyle.LightVertical, Color.DarkSlateBlue, Color.Teal);
            }
            pen = new Pen(brush);

            x = xPosition;
            Y = yPosition;
            this.width = width;
            this.height = height;
            id = note;
        }

        /// <summary>
        /// Svojstvo y.
        /// </summary>
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Svojstvo height.
        /// </summary>
        public double Height
        {
            get { return height; }
        }

        /// <summary>
        /// Svojstvo Id.
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Iscrtava pločicu koristeći <code>Graphics</code> parametar predan kao argument.
        /// </summary>
        /// <param name="graphics"></param>
        public void render(Graphics graphics)
        {
            double pictureBoxHeight = Application.OpenForms["FormGame"].Controls["tilesBox"].Height;
            drawFillRoundedRectangle(graphics, (int)x, (int)y,
                (int)width, (int)(height - Math.Max(0, (y + height - pictureBoxHeight))), 10);
        }

        /// <summary>
        /// Pomoćna funkcija za crtanje kvadrata sa zaobljenim vrhovima.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        private void drawFillRoundedRectangle(Graphics g, int x, int y, int width, int height, int radius)
        {
            Rectangle corner = new Rectangle(x, y, radius, radius);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(corner, 180, 90);
            corner.X = x + width - radius;
            path.AddArc(corner, 270, 90);
            corner.Y = y + height - radius;
            path.AddArc(corner, 0, 90);
            corner.X = x;
            path.AddArc(corner, 90, 90);
            path.CloseFigure();

            g.FillPath(brush, path);

            if (pen != null)
            {
                g.DrawPath(pen, path);
            }
        }
    }
}
