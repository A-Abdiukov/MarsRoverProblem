using Controller;
using System;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO - ADD CODE TO Display WinForms

            Control controller = new();
            Console.WriteLine("Hi! Welcome to Mars Rover Application.");
            Console.WriteLine("You can exit the application at any moment by typing \'exit\'.");
            Console.WriteLine("You can run the tests by typing \'runtest\'.");
            Console.WriteLine("Or you can begin by typing in the dimensions of the Plateau, for example \'5 5\'. \n");

            while (true)
            {
                string input = (Console.ReadLine()).ToUpper();

                if (input == "EXIT")
                {
                    break;
                }
                else if (input == "RUNTEST")
                {
                    string[] listOfTestCommands = new string[] { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };

                    foreach (string item in listOfTestCommands)
                    {
                        string outputFromTests = controller.ProcessUserInput(item);
                        Console.WriteLine(outputFromTests);
                    }

                }
                else
                {
                    string output = controller.ProcessUserInput(input);
                    Console.WriteLine(output);
                }


            }
        }

    }
}
