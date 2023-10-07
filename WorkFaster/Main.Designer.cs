namespace WorkFaster
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
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
            Button callApiButton;
            callApiButton = new Button();
            SuspendLayout();
            // 
            // callApiButton
            // 
            callApiButton.Location = new Point(585, 157);
            callApiButton.Name = "callApiButton";
            callApiButton.Size = new Size(188, 58);
            callApiButton.TabIndex = 0;
            callApiButton.Text = "Call API";
            callApiButton.UseVisualStyleBackColor = true;
            callApiButton.Click += button1_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(callApiButton);
            Name = "Main";
            Text = "Main";
            ResumeLayout(false);
        }

        #endregion

        private Button callApiButton;
    }
}
