using Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public partial class RoversGUI : Form
    {
        private readonly int dimension = (int)(Screen.PrimaryScreen.Bounds.Height * 0.95);
        private const int bufferDimension = 1024;
        private readonly int squareDimension;
        private Bitmap buffer;
        private readonly Brush c1 = Brushes.DarkOrange, c2 = Brushes.DarkGray;
        private readonly Square[,] board;

        private readonly int upperLimitX;
        private readonly int upperLimitY;
        //INITIALISATION CODE

        public RoversGUI(int upperLimitX, int upperLimitY)
        {
            InitializeComponent();
            InitGraphics();

            if (upperLimitX >= upperLimitY)
            {
                squareDimension = bufferDimension / upperLimitX;
            }
            else
            {
                squareDimension = bufferDimension / upperLimitY;
            }

            this.upperLimitX = upperLimitX;
            this.upperLimitY = upperLimitY;

            board = new Square[upperLimitX, upperLimitY];
            InitialiseModel();
            UpdateAll();
        }

        private void InitGraphics()
        {
            this.MaximizeBox = false;
            this.MaximumSize = new Size(dimension, dimension);
            this.MinimumSize = new Size(dimension / 2, dimension / 2);
            this.Size = new Size(dimension, dimension);
            buffer = new Bitmap(bufferDimension, bufferDimension);
            this.DoubleBuffered = true;
            this.Paint += GUIView_Paint;
            this.Resize += GUIView_Resize;
        }

        //RESPOND TO USER INPUT CODE

        //RESIZE CODE
        private void GUIView_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.Height = this.Width;
                this.Invalidate();
            }
        }

        //DRAW GRAPHICS CODE

        private void GUIView_Paint(object sender, PaintEventArgs e)
        {
            int x = this.ClientSize.Width / 8;
            int y = this.ClientSize.Height / 8;
            int lineSize = (x + y / 2) / 25;
            e.Graphics.DrawImage(buffer, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

        }

        public void DrawSquare(Image piece, Point coord)
        {
            Brush brush = (coord.Y % 2 == 0) ? (coord.X % 2 == 0) ? c1 : c2 : (coord.X % 2 == 0) ? c2 : c1;
            using Graphics g = Graphics.FromImage(buffer);
            g.FillRectangle(brush, coord.X * squareDimension, coord.Y * squareDimension, squareDimension, squareDimension);
            if (piece != null)
            {
                g.DrawImage(piece, coord.X * squareDimension, coord.Y * squareDimension, squareDimension, squareDimension);
            }
        }

        private void InitialiseModel()
        {
            for (int i = 0; i < upperLimitX; i++)
            {
                for (int j = 0; j < upperLimitY; j++)
                {
                    board[i, j] = new Square();
                }
            }
        }


        public void UpdateAll()
        {
            for (int i = 0; i < upperLimitX; i++)
            {
                for (int j = 0; j < upperLimitY; j++)
                {
                    Update(new Point(i, j));
                }
            }
        }

        private void Update(Point coord)
        {
            Rover piece = board[coord.X, coord.Y].piece;

            Image pieceImage = null;
            if (piece != null)
            {
                pieceImage = piece.image;
            }
            DrawSquare(pieceImage, coord);
        }

        //private void Place(int col, int row, Rover piece)
        //{
        //    board[row, col].piece = piece;
        //    Update(new Point(row, col));
        //}
    }
}
