using System.Windows.Forms;
namespace View
{
    public partial class InputTaker : Form
    {
        private readonly Controller.Control controller;
        private readonly RoversGUI GUI;
        public InputTaker()
        {
            InitializeComponent();
            controller = new();
            GUI = new(5, 5);
            GUI.Show();
        }

        private void ButtonRunTest_Click(object sender, System.EventArgs e)
        {
            string[] listOfTestCommands = new string[] { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };

            foreach (string item in listOfTestCommands)
            {
                string output = controller.ProcessUserInput(item);
                if (output != "")
                {
                    richTextBoxOutput.Text += "\n" + output;
                }
            }
            GUI.UpdateAll();
        }

        private void BtnSendUserInput_Click(object sender, System.EventArgs e)
        {
            string input = textBox_UserInput.Text.ToUpper();
            string output = controller.ProcessUserInput(input);
            if (output != "")
            {
                richTextBoxOutput.Text += "\n" + output;
            }

            GUI.UpdateAll();
        }
    }
}
