using Model;
using System;

namespace Controller
{
    public class Control
    {
        /// <summary>
        /// Processes user input.
        /// 1. Check if plateau dimensions were set. If plateau dimensions were not set,  call SetPlateauDimensions() method.
        /// 2. Check if user is trying to move the rover by checking whether input includes "M" or "L" or "R".  If user is trying to move rover, call MoveRotateRover() method.
        /// 3. Check if there are 3 letters in the input e.g "1 3 N". If there are 3 inputs, that means the user is trying to add a new rover, and the program calls PlaceRover() method.
        /// </summary>
        /// <param name="line">Raw user input</param>
        /// <returns> "" if success; or coordinates of the rover after it moved, for example "1 3 N"; or an error message. </returns>
        public string ProcessUserInput(string line)
        {
            string[] inputArray = line.Split(" ");

            if (Plateau.UpperRightCoordinates is null)
            {
                return SetPlateauDimensions(inputArray);
            }
            else if (line.Contains("M")
                || line.Contains("L")
                || line.Contains("R"))
            {
                return MoveRotateRover(line);
            }
            else if (inputArray.Length == 3)
            {
                return PlaceRover(inputArray);
            }
            else
            {
                return "Error. Cannot understand your input. Your input is\n" + line + "\nPlease try again.";

            }
        }

        /// <summary>
        /// Sets dimensions for the plateau.
        /// </summary>
        /// <param name="inputArray">Array which contains user input. For example, {1},{2} .</param>
        /// <returns>"" if success; or an error message. </returns>
        private string SetPlateauDimensions(string[] inputArray)
        {
            string errorMsg = "Error. The Mars Plateau dimensions were not successfully updated." +
                        "\nPlease try again. Try entering two positive whole numbers, for example \'5 5\'";
            if (inputArray.Length == 2)
            {
                int x = -1;
                int y = -1;

                int.TryParse(inputArray[0], out x);
                int.TryParse(inputArray[1], out y);

                if (x < 1 || y < 1)
                {
                    return errorMsg;
                }

                Plateau.UpperRightCoordinates = new int[,] { { x, y } };
                return "";
            }
            else
            {
                return errorMsg;
            }
        }

        /// <summary>
        /// Either moves or rotates the rover.
        /// </summary>
        /// <param name="line">Raw user input</param>
        /// <returns>The new position of the rover e.g 1 3 N; or an error message.</returns>
        private string MoveRotateRover(string line)
        {
            if (RoverInfo.ListOfAllRovers.Count > 0)
            {
                Rover lastRover = RoverInfo.ListOfAllRovers[^1];

                foreach (char command in line)
                {
                    switch (command)
                    {
                        case 'M':
                            lastRover.Move();
                            break;
                        case 'L':
                            lastRover.Spin90DegreesLeft();
                            break;
                        case 'R':
                            lastRover.Spin90DegreesRight();
                            break;
                    }
                }

                string positionOfRover = lastRover.X + " " + lastRover.Y + " " + lastRover.Orientation;

                return positionOfRover;
            }
            else
            {
                return "Error. Please add at least one rover before trying to move it";
            }
        }

        /// <summary>
        /// Places the rover onto the plateau.
        /// </summary>
        /// <param name="inputArray">Array which contains user input. For example, {1},{2},{N} .</param>
        /// <returns>"" if success; or an error message.</returns>
        private string PlaceRover(string[] inputArray)
        {
            int x = -1;
            int y = -1;

            int.TryParse(inputArray[0], out x);
            int.TryParse(inputArray[1], out y);

            if (
                (x < 1 || y < 1)
                || Enum.TryParse(inputArray[2], out CardinalCompassPoints orientation) == false
                )
            {
                return "Error. The Mars Rover was not placed." +
                    "\nPlease try again. Try entering two positive whole numbers and one of the compass directions, for example \'1 2 N\'.";
            }

            Rover roverToAdd = new(x, y, orientation);
            RoverInfo.ListOfAllRovers.Add(roverToAdd);

            return "";
        }
    }
}
