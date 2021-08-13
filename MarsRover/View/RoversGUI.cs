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
        private int squareDimension;
        private Bitmap buffer;
        private readonly Brush c1 = Brushes.OrangeRed, c2 = Brushes.DarkGray;
        private Square[,] board;
        private readonly int upperLimitX;
        private readonly int upperLimitY;


        //INITIALISING THE FORM CODE

        /// <summary>
        /// 1. Initialises the page.
        /// 2. Calls in other methods to draw graphics depending on screen resolution.
        /// </summary>
        /// <param name="upperLimitX">The upper x limit e.g 5</param>
        /// <param name="upperLimitY">The upper y limit e.g 5</param>
        public RoversGUI(int upperLimitX, int upperLimitY)
        {
            InitializeComponent();
            this.upperLimitX = upperLimitX;
            this.upperLimitY = upperLimitY;
            InitGraphics();
            InitialiseModel();
            UpdateAll();
        }

        /// <summary>
        /// Initialises graphics.
        /// 1. Determines the maximum size of the application (depending on the screen resolution)
        /// 2. Initialises a Bitmap object that is used to draw.
        /// 3. Sets the Paint and Resize to GUIView_Paint() and GUIView_Resize() methods respectively.
        /// 4. Sets the dimensions of each square according to the choice user made (upperLimitX and upperLimitY)
        /// </summary>
        private void InitGraphics()
        {
            this.MaximumSize = new Size(dimension, dimension);
            this.MinimumSize = new Size(dimension / 2, dimension / 2);
            this.Size = new Size(dimension, dimension);
            buffer = new Bitmap(bufferDimension, bufferDimension);
            this.Paint += GUIView_Paint;
            this.Resize += GUIView_Resize;
            squareDimension = upperLimitX >= upperLimitY ? bufferDimension / (upperLimitX + 1) : bufferDimension / (upperLimitY + 1);
        }

        /// <summary>
        /// Initialises the square models that will be used for drawing.
        /// </summary>
        private void InitialiseModel()
        {
            board = new Square[upperLimitX + 1, upperLimitY + 1];
            for (int i = 0; i < upperLimitX + 1; i++)
            {
                for (int j = 0; j < upperLimitY + 1; j++)
                {
                    board[i, j] = new Square();
                }
            }
        }

        /// <summary>
        /// Ensures that when resizing, the program's width and height maintain a 1:1 ratio.
        /// </summary>
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
            e.Graphics.DrawImage(buffer, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
        }

        /// <summary>
        /// Draws the square.
        /// 1. Alternating squares have different colours (c1, c2). Achieves the checkered look.
        /// 2. Fills the rectangle around the square dimensions.
        /// 3. If there is a piece (Rover), then draws it in.
        /// </summary>
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

        // UPDATING THE FORM CODE

        /// <summary>
        /// Resets the whole board, and updates the location/image of each rover.
        /// </summary>
        public void UpdateAll()
        {
            ResetSquares();
            foreach (Rover item in RoverInfo.ListOfAllRovers)
            {
                item.image = Image.FromFile("assets\\Rover" + item.Orientation.ToString() + ".png");

                board[item.X, (upperLimitY - item.Y)].piece = item;
            }

            for (int i = 0; i <= upperLimitX; i++)
            {
                for (int j = 0; j <= upperLimitY; j++)
                {
                    Update(new Point(i, j));
                }
            }
            this.Invalidate();
        }

        /// <summary>
        /// Updates the square.
        /// 1. The coordinates are used to get the piece that is located on that square.
        /// 2. If there piece has an image -> pass it along onto DrawSquare() method.
        /// </summary>
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

        /// <summary>
        /// This is used to make sure every square is empty.
        /// </summary>
        private void ResetSquares()
        {
            for (int i = 0; i < upperLimitX + 1; i++)
            {
                for (int j = 0; j < upperLimitY + 1; j++)
                {
                    board[i, j].piece = null;
                }
            }
        }

        //CLOSING WINDOW

        /// <summary>
        /// 1. If the user attemps to close the window, display a dialogue box.
        ///     - If user decides to exit, shutdown the entire application.
        /// </summary>
        private void RoversGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            var window = MessageBox.Show(
                "Close the application?",
                "Are you sure?",
                MessageBoxButtons.YesNo);

            if (window != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
