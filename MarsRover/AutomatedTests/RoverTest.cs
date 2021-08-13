using Controller;
using Model;
using NUnit.Framework;

namespace AutomatedTests
{
    [TestFixture]
    class RoverTest
    {
        Control controller;

        [SetUp]
        public void Init()
        {
            controller = new();
            Model.RoverInfo.ListOfAllRovers.Clear();
        }

        /// <summary>
        /// Test checks whether a plateau can be initialised
        /// </summary>
        [Test]
        public void SetUpperLimitsPlateau()
        {
            int upperLimitX = 7;
            int upperLimitY = 8;

            Model.Plateau.UpperRightCoordinates = null;
            controller.ProcessUserInput(upperLimitX + " " + upperLimitY);


            Assert.IsTrue(
                Model.Plateau.UpperRightCoordinates[0, 0] == upperLimitX &&
                Model.Plateau.UpperRightCoordinates[0, 1] == upperLimitY
                );
        }

        /// <summary>
        /// Test checks whether the rover can be created
        /// Test checks whether the created rover has correct X, Y positions and correct orientation
        /// </summary>
        [Test]
        public void SetRoverLocation()
        {
            int roverXPosition = 1;
            int roverYPosition = 3;
            string roverOrientation = "W";

            controller.ProcessUserInput(roverXPosition + " " + roverYPosition + " " + roverOrientation);


            Rover lastRover = RoverInfo.ListOfAllRovers[^1];

            Assert.IsTrue(
                lastRover.X == roverXPosition &&
                lastRover.Y == roverYPosition &&
                lastRover.Orientation.ToString() == roverOrientation
                );
        }


        /// <summary>
        /// Test checks whether new rover can be created and successfully rotated left.
        /// </summary>
        [Test]
        public void Spin90DegreesLeft()
        {
            int roverXPosition = 1;
            int roverYPosition = 4;
            string roverOrientation = "W";

            controller.ProcessUserInput(roverXPosition + " " + roverYPosition + " " + roverOrientation);

            controller.ProcessUserInput("L");

            Rover lastRover = RoverInfo.ListOfAllRovers[^1];

            Assert.IsTrue(
                lastRover.X == roverXPosition &&
                lastRover.Y == roverYPosition &&
                lastRover.Orientation.ToString() == "S"
                );

        }

        /// <summary>
        /// Test checks whether new rover can be created and successfully rotated right.
        /// </summary>
        [Test]
        public void Spin90DegreesRight()
        {
            int roverXPosition = 1;
            int roverYPosition = 5;
            string roverOrientation = "W";

            controller.ProcessUserInput(roverXPosition + " " + roverYPosition + " " + roverOrientation);

            controller.ProcessUserInput("R");

            Rover lastRover = RoverInfo.ListOfAllRovers[^1];

            Assert.IsTrue(
                lastRover.X == roverXPosition &&
                lastRover.Y == roverYPosition &&
                lastRover.Orientation.ToString() == "N"
                );
        }

        /// <summary>
        /// Test checks whether a rover can be created and moved
        /// </summary>
        [Test]
        public void RoverMove()
        {
            int roverXPosition = 2;
            int roverYPosition = 2;
            string roverOrientation = "N";

            controller.ProcessUserInput(roverXPosition + " " + roverYPosition + " " + roverOrientation);
            controller.ProcessUserInput("M");


            Rover lastRover = RoverInfo.ListOfAllRovers[^1];

            Assert.IsTrue(
                lastRover.X == roverXPosition &&
                lastRover.Y == (roverYPosition + 1) &&
                lastRover.Orientation.ToString() == "N"
                );
        }
    }
}
