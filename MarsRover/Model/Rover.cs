using System.Drawing;

namespace Model
{
    /// <summary>
    /// Square is used to render rovers/ martian plateau in GUI.
    /// </summary>
    public class Square
    {
        public Rover piece;
    }

    /// <summary>
    /// Contains information about the martian rover, it's position, it's compass orientation.
    /// Contains methods to move the rover.
    /// </summary>
    public class Rover
    {
        //VARIABLE DECLARATIONS

        public int X;
        public int Y;
        public CardinalCompassPoints Orientation;
        public Image image;

        //CONSTRUCTOR


        /// <param name="x">X coordinate of the rover</param>
        /// <param name="y">Y coordinate of the rover</param>
        /// <param name="orientation">Which compass orientation the rover is facing towards. Possible values: N, W, S, E.</param>
        public Rover(int x, int y, CardinalCompassPoints orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        //METHODS

        /// <returns>True if rover has been successfuly spun left 90 degrees. False if rover failed to spin.</returns>
        public bool Spin90DegreesLeft()
        {
            switch (Orientation)
            {
                case CardinalCompassPoints.N:
                    Orientation = CardinalCompassPoints.W;
                    break;
                case CardinalCompassPoints.W:
                    Orientation = CardinalCompassPoints.S;
                    break;
                case CardinalCompassPoints.S:
                    Orientation = CardinalCompassPoints.E;
                    break;
                case CardinalCompassPoints.E:
                    Orientation = CardinalCompassPoints.N;
                    break;
                default:
                    return false;
            }
            return true;
        }

        /// <returns>True if rover has been successfuly spun right 90 degrees. False if rover failed to spin.</returns>
        public bool Spin90DegreesRight()
        {
            switch (Orientation)
            {
                case CardinalCompassPoints.N:
                    Orientation = CardinalCompassPoints.E;
                    break;
                case CardinalCompassPoints.E:
                    Orientation = CardinalCompassPoints.S;
                    break;
                case CardinalCompassPoints.S:
                    Orientation = CardinalCompassPoints.W;
                    break;
                case CardinalCompassPoints.W:
                    Orientation = CardinalCompassPoints.N;
                    break;
                default:
                    return false;
            }
            return true;
        }

        /// <returns>True if rover has successfully moved. False if rover failed to move.</returns>
        public bool Move()
        {
            int newX;
            int newY;

            switch (Orientation)
            {
                case CardinalCompassPoints.N:
                    newX = X;
                    newY = Y + 1;
                    break;
                case CardinalCompassPoints.E:
                    newX = X + 1;
                    newY = Y;
                    break;
                case CardinalCompassPoints.S:
                    newX = X;
                    newY = Y - 1;
                    break;
                case CardinalCompassPoints.W:
                    newX = X - 1;
                    newY = Y;
                    break;
                default:
                    return false;
            }

            if (CanTheMoveBeDone(newX, newY) == true)
            {
                X = newX;
                Y = newY;
                return true;
            }
            return false;
        }

        /// <returns>True if the rover can successfully move. False if rover cannot do the move.</returns>
        public static bool CanTheMoveBeDone(int newX, int newY)
        {
            //CHECK THAT THE ROVER WANTS TO MOVE WITHIN BOUNDARIES

            if (newX > Plateau.UpperRightCoordinates[0, 0] || newX < Plateau.LowerLeftCoordinates[0, 0])
            {
                return false;
            }

            if (newY > Plateau.UpperRightCoordinates[0, 1] || newY < Plateau.LowerLeftCoordinates[0, 1])
            {
                return false;
            }

            //CHECK WHETHER THERE IS A ROVER OCCUPYING SPACE THAT ANOTHER ROVER TRIES TO MOVE ONTO
            foreach (Rover item in RoverInfo.ListOfAllRovers)
            {
                if (item.X == newX && item.Y == newY)
                {
                    return false;
                }
            }

            //IF A MOVE IS CORRECT, THEN RETURN TRUE
            return true;
        }

    }
}
