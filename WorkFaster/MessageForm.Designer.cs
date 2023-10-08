namespace WorkFaster
{
    partial class MessageForm
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
            messageLbl = new Label();
            SuspendLayout();
            // 
            // messageLbl
            // 
            messageLbl.AutoSize = true;
            messageLbl.Location = new Point(27, 21);
            messageLbl.Margin = new Padding(5, 0, 5, 0);
            messageLbl.Name = "messageLbl";
            messageLbl.Size = new Size(0, 41);
            messageLbl.TabIndex = 0;
            // 
            // MessageForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 60);
            ControlBox = false;
            Controls.Add(messageLbl);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MessageForm";
            Text = "MessageForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label messageLbl;
    }
}