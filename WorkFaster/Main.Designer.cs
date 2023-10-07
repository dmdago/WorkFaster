namespace WorkFaster
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button callapibtn;
            callapibtn = new Button();
            SuspendLayout();
            // 
            // callapibtn
            // 
            callapibtn.Location = new Point(585, 157);
            callapibtn.Name = "callapibtn";
            callapibtn.Size = new Size(188, 58);
            callapibtn.TabIndex = 0;
            callapibtn.Text = "callapibtn";
            callapibtn.UseVisualStyleBackColor = true;
            callapibtn.Click += button1_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(callapibtn);
            Name = "Main";
            Text = "Main";
            ResumeLayout(false);
        }

        #endregion

        private Button callapibtn;
    }
}