using Controller;
using NUnit.Framework;
using System.Collections.Generic;

namespace AutomatedTests
{
    class RoverBigInputTest
    {
        Control controller;

        [SetUp]
        public void Init()
        {
            controller = new();
            Model.Plateau.UpperRightCoordinates = null;
            Model.RoverInfo.ListOfAllRovers.Clear();
        }

        /// <summary>
        /// Test Input:
        /// 5 5
        /// 1 2 N
        /// LMLMLMLMM
        /// 3 3 E
        /// MMRMMRMRRM
        /// Expected Output:
        /// 1 3 N
        /// 5 1 E
        /// </summary>
        [Test]
        public void TwoRoversCreatedAndMovedTest()
        {
            string[] listOfTestCommands = new string[] { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            List<string> output = new();

            foreach (string item in listOfTestCommands)
            {
                string toAdd = controller.ProcessUserInput(item);

                if (toAdd != "")
                {
                    output.Add(toAdd);
                }
            }
            Assert.IsTrue(output[0] == "1 3 N");
            Assert.IsTrue(output[1] == "5 1 E");
        }
    }
}
