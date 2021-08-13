using Model;
using System.Windows.Forms;
namespace View
{
    public partial class InputTaker : Form
    {
        private readonly Controller.Control controller;
        private RoversGUI MarsRoverGUI;

        public InputTaker()
        {
            InitializeComponent();
            controller = new();
        }

        /// <summary>
        /// Runs all the tests and update the GUI.
        /// </summary>
        private void ButtonRunTest_Click(object sender, System.EventArgs e)
        {
            RunTests();
            UpdateMarsRoverGUI();
        }

        /// <summary>
        /// Event fires when user clicks the "Send" button.
        /// 1. Sends the input from textbox into controller.
        /// 2. Updates the rich text box with output (from controller).
        /// 3. Updates MarsRoverGUI.
        /// </summary>
        private void BtnSendUserInput_Click(object sender, System.EventArgs e)
        {
            string input = textBox_UserInput.Text.ToUpper();
            string output = controller.ProcessUserInput(input);
            UpdateOutputTextArea(output);
            UpdateMarsRoverGUI();
        }

        /// <summary>
        /// Runs all the tests to make sure the application is working properly.
        /// Expected Output:
        /// 1 3 N
        /// 5 1 E
        /// </summary>
        private void RunTests()
        {
            string[] listOfTestCommands = new string[] { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };

            foreach (string item in listOfTestCommands)
            {
                string output = controller.ProcessUserInput(item);

                UpdateOutputTextArea(output);
            }
        }

        /// <summary>
        /// Adds provided string to the rich text box.
        /// </summary>
        /// <param name="textToAdd">Text to be added</param>
        private void UpdateOutputTextArea(string textToAdd)
        {
            if (textToAdd != "")
            {
                richTextBoxOutput.Text += textToAdd + "\n";
            }
        }

        /// <summary>
        /// 1. If mars rover gui has not been initialised
        ///  - Check that the Plateau.UpperRightCoordinates have been set. If they have been set, initialise the mars rover gui.
        /// 2. If mars rover gui has been initialised, then update it.
        /// </summary>
        private void UpdateMarsRoverGUI()
        {
            if (MarsRoverGUI is null)
            {
                if (Plateau.UpperRightCoordinates is not null)
                {
                    MarsRoverGUI = new(Plateau.UpperRightCoordinates[0, 0], Plateau.UpperRightCoordinates[0, 1]);
                    MarsRoverGUI.Show();
                }
            }
            else
            {
                MarsRoverGUI.UpdateAll();
            }
        }

    }
}
