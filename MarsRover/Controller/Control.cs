using Model;
using System;

namespace Controller
{
    public class Control
    {
        /// <summary>
        /// Validates user input
        /// Input:
        /// The first line of input is the upper-right coordinates of the plateau, the lower-left coordinates are assumed to be 0,0.
        /// The rest of the input is information pertaining to the rovers that have been deployed.Each rover has two lines of input.
        /// The first line gives the rover's position, and the second line is a series of instructions telling the rover how to explore the plateau.
        /// The position is made up of two integers and a letter separated by spaces, corresponding to the x and y co-ordinates and the rover's orientation.
        /// Each rover will be finished sequentially, which means that the second rover won't start to move until the first one has finished moving.
        /// </summary>
        public string ProcessUserInput(string line)
        {
            string[] inputDividedBySpace = line.Split(" ");

            if (Plateau.UpperRightCoordinates is null)
            {
                if (inputDividedBySpace.Length == 2)
                {
                    int x = -1;
                    int y = -1;

                    int.TryParse(inputDividedBySpace[0], out x);
                    int.TryParse(inputDividedBySpace[1], out y);

                    if (x < 1 && y < 1)
                    {
                        return "The Mars Plateau dimensions were not successfully updated." +
                            "\nPlease try again. Try entering two positive whole numbers, for example \'5 5\'";
                    }

                    Plateau.UpperRightCoordinates = new int[,] { { x, y } };
                    return "The Mars Plateau dimensions were set to [" + x + "," + y + "]";
                }
                else
                {
                    return "The Mars Plateau dimensions were not successfully updated." +
                            "\nPlease try again. Try entering two positive whole numbers, for example \'5 5\'";
                }
            }
            else if (line.Contains("M")
                || line.Contains("L")
                || line.Contains("R"))
            {
                if (RoverInfo.listOfAllRovers.Count > 0)
                {
                    Rover lastRover = RoverInfo.listOfAllRovers[RoverInfo.listOfAllRovers.Count - 1];

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

                    //return the position of the rover
                    //e.g 1 3 N
                    string positionOfRover = lastRover.RoverName + " position is " + lastRover.X + " " + lastRover.Y + " " + lastRover.Orientation;

                    return positionOfRover;
                }
                else
                {
                    return "Please add at least one rover before trying to move it";
                }
            }

            // 3 3 E
            else if (inputDividedBySpace.Length == 3)
            {
                int x = -1;
                int y = -1;

                int.TryParse(inputDividedBySpace[0], out x);
                int.TryParse(inputDividedBySpace[1], out y);

                if (x < 1 && y < 1)
                {
                    return "The Mars Rover position was not successfully updated." +
                        "\nPlease try again. Try entering two positive whole numbers, for example \'5 5\'.";
                }

                if (Enum.TryParse(inputDividedBySpace[2], out CardinalCompassPoints orientation) == false)
                {
                    return "The Mars Rover orientation was not successfully entered." +
                    "\nPlease try again. Try entering one of the compass directions, such as N W S E";
                }

                string roverName = "Rover #" + (int)(RoverInfo.listOfAllRovers.Count + 1);

                Rover roverToAdd = new Rover(x, y, orientation, roverName);
                RoverInfo.listOfAllRovers.Add(roverToAdd);

                return roverName + " has been successfully added to Mars Plateau. [" + roverToAdd.X + " " + roverToAdd.Y + " " + roverToAdd.Orientation + "]";
            }

            return "Cannot understand your input. Your input is\n" + line + "\nPlease try again.";
        }

    }
}
