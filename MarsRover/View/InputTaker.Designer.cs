
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
            this.labelUserHint.Size = new System.Drawing.Size(475, 25);
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
            this.textBox_UserInput.Size = new System.Drawing.Size(475, 34);
            this.textBox_UserInput.TabIndex = 1;
            // 
            // btnSendUserInput
            // 
            this.btnSendUserInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSendUserInput.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSendUserInput.Location = new System.Drawing.Point(0, 59);
            this.btnSendUserInput.Name = "btnSendUserInput";
            this.btnSendUserInput.Size = new System.Drawing.Size(475, 34);
            this.btnSendUserInput.TabIndex = 2;
            this.btnSendUserInput.Text = "Send";
            this.btnSendUserInput.UseVisualStyleBackColor = true;
            // 
            // InputTaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 317);
            this.Controls.Add(this.btnSendUserInput);
            this.Controls.Add(this.textBox_UserInput);
            this.Controls.Add(this.labelUserHint);
            this.Name = "InputTaker";
            this.Text = "W";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserHint;
        private System.Windows.Forms.TextBox textBox_UserInput;
        private System.Windows.Forms.Button btnSendUserInput;
    }
}