namespace Model
{
    public class Rover
    {
        //VARIABLE DECLARATIONS

        public int X;
        public int Y;
        public CardinalCompassPoints Orientation;
        public string RoverName;

        //CONSTRUCTOR

        public Rover(int x, int y, CardinalCompassPoints orientation, string roverName)
        {
            X = x;
            Y = y;
            Orientation = orientation;
            RoverName = roverName;
        }

        //METHODS

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




        public bool CanTheMoveBeDone(int newX, int newY)
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
            foreach (Rover item in RoverInfo.listOfAllRovers)
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
