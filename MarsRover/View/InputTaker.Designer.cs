
namespace View
{
    partial class InputTaker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUserHint = new System.Windows.Forms.Label();
            this.textBox_UserInput = new System.Windows.Forms.TextBox();
            this.btnSendUserInput = new System.Windows.Forms.Button();
            this.buttonRunTest = new System.Windows.Forms.Button();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelUserHint
            // 
            this.labelUserHint.CausesValidation = false;
            this.labelUserHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelUserHint.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUserHint.Location = new System.Drawing.Point(0, 0);
            this.labelUserHint.Margin = new System.Windows.Forms.Padding(0);
            this.labelUserHint.Name = "labelUserHint";
            this.labelUserHint.Size = new System.Drawing.Size(474, 25);
            this.labelUserHint.TabIndex = 0;
            this.labelUserHint.Text = "Please enter input:";
            this.labelUserHint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox_UserInput
            // 
            this.textBox_UserInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_UserInput.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_UserInput.Location = new System.Drawing.Point(0, 25);
            this.textBox_UserInput.Name = "textBox_UserInput";
            this.textBox_UserInput.Size = new System.Drawing.Size(474, 34);
            this.textBox_UserInput.TabIndex = 1;
            // 
            // btnSendUserInput
            // 
            this.btnSendUserInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSendUserInput.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSendUserInput.Location = new System.Drawing.Point(0, 59);
            this.btnSendUserInput.Name = "btnSendUserInput";
            this.btnSendUserInput.Size = new System.Drawing.Size(474, 34);
            this.btnSendUserInput.TabIndex = 2;
            this.btnSendUserInput.Text = "Send";
            this.btnSendUserInput.UseVisualStyleBackColor = true;
            this.btnSendUserInput.Click += new System.EventHandler(this.BtnSendUserInput_Click);
            // 
            // buttonRunTest
            // 
            this.buttonRunTest.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRunTest.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRunTest.Location = new System.Drawing.Point(0, 93);
            this.buttonRunTest.Name = "buttonRunTest";
            this.buttonRunTest.Size = new System.Drawing.Size(474, 34);
            this.buttonRunTest.TabIndex = 3;
            this.buttonRunTest.Text = "Run tests";
            this.buttonRunTest.UseVisualStyleBackColor = true;
            this.buttonRunTest.Click += new System.EventHandler(this.ButtonRunTest_Click);
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBoxOutput.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxOutput.Location = new System.Drawing.Point(0, 127);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.ReadOnly = true;
            this.richTextBoxOutput.Size = new System.Drawing.Size(474, 243);
            this.richTextBoxOutput.TabIndex = 5;
            this.richTextBoxOutput.Text = "";
            // 
            // InputTaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 382);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.buttonRunTest);
            this.Controls.Add(this.btnSendUserInput);
            this.Controls.Add(this.textBox_UserInput);
            this.Controls.Add(this.labelUserHint);
            this.Name = "InputTaker";
            this.Text = "Mars Rover Control System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserHint;
        private System.Windows.Forms.TextBox textBox_UserInput;
        private System.Windows.Forms.Button btnSendUserInput;
        private System.Windows.Forms.Button buttonRunTest;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
    }
}