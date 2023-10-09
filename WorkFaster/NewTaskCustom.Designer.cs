namespace WorkFaster
{
    partial class NewTaskCustom
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
            customTaskBtn = new Button();
            customTasktxt = new TextBox();
            SuspendLayout();
            // 
            // customTaskBtn
            // 
            customTaskBtn.Location = new Point(12, 65);
            customTaskBtn.Name = "customTaskBtn";
            customTaskBtn.Size = new Size(767, 58);
            customTaskBtn.TabIndex = 0;
            customTaskBtn.Text = "Send";
            customTaskBtn.UseVisualStyleBackColor = true;
            customTaskBtn.Click += customTaskBtn_Click;
            // 
            // customTasktxt
            // 
            customTasktxt.Location = new Point(12, 12);
            customTasktxt.Name = "customTasktxt";
            customTasktxt.Size = new Size(767, 47);
            customTasktxt.TabIndex = 1;
            customTasktxt.KeyDown += customTasktxt_KeyDown;
            // 
            // NewTaskCustom
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 137);
            Controls.Add(customTasktxt);
            Controls.Add(customTaskBtn);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NewTaskCustom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Custom Task";
            Load += NewTaskCustom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button customTaskBtn;
        private TextBox customTasktxt;
    }
}