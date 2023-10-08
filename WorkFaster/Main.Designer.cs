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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            callApiButton = new Button();
            notifyIcon = new NotifyIcon(components);
            apiKeylbl = new Label();
            apiTokenlbl = new Label();
            idListlbl = new Label();
            apiKeytxt = new TextBox();
            apiTokentxt = new TextBox();
            idListtxt = new TextBox();
            SuspendLayout();
            // 
            // callApiButton
            // 
            callApiButton.Location = new Point(565, 324);
            callApiButton.Name = "callApiButton";
            callApiButton.Size = new Size(188, 58);
            callApiButton.TabIndex = 0;
            callApiButton.Text = "Call API";
            callApiButton.UseVisualStyleBackColor = true;
            callApiButton.Click += callApiButton_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipText = "Running";
            notifyIcon.BalloonTipTitle = "WorkAid Status";
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "WorkAid";
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // apiKeylbl
            // 
            apiKeylbl.AutoSize = true;
            apiKeylbl.Location = new Point(32, 36);
            apiKeylbl.Name = "apiKeylbl";
            apiKeylbl.Size = new Size(118, 41);
            apiKeylbl.TabIndex = 1;
            apiKeylbl.Text = "Api Key";
            apiKeylbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // apiTokenlbl
            // 
            apiTokenlbl.AutoSize = true;
            apiTokenlbl.Location = new Point(32, 129);
            apiTokenlbl.Name = "apiTokenlbl";
            apiTokenlbl.Size = new Size(149, 41);
            apiTokenlbl.TabIndex = 2;
            apiTokenlbl.Text = "Api Token";
            apiTokenlbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // idListlbl
            // 
            idListlbl.AutoSize = true;
            idListlbl.Location = new Point(32, 227);
            idListlbl.Name = "idListlbl";
            idListlbl.Size = new Size(96, 41);
            idListlbl.TabIndex = 3;
            idListlbl.Text = "Id List";
            // 
            // apiKeytxt
            // 
            apiKeytxt.Location = new Point(241, 36);
            apiKeytxt.Name = "apiKeytxt";
            apiKeytxt.Size = new Size(512, 47);
            apiKeytxt.TabIndex = 4;
            // 
            // apiTokentxt
            // 
            apiTokentxt.Location = new Point(241, 129);
            apiTokentxt.Name = "apiTokentxt";
            apiTokentxt.Size = new Size(512, 47);
            apiTokentxt.TabIndex = 5;
            // 
            // idListtxt
            // 
            idListtxt.Location = new Point(241, 227);
            idListtxt.Name = "idListtxt";
            idListtxt.Size = new Size(512, 47);
            idListtxt.TabIndex = 6;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 434);
            Controls.Add(idListtxt);
            Controls.Add(apiTokentxt);
            Controls.Add(apiKeytxt);
            Controls.Add(idListlbl);
            Controls.Add(apiTokenlbl);
            Controls.Add(apiKeylbl);
            Controls.Add(callApiButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "WordAid";
            Load += Main_Load;
            Resize += Main_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button callApiButton;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
        private Label apiKeylbl;
        private Label apiTokenlbl;
        private Label idListlbl;
        private TextBox apiKeytxt;
        private TextBox apiTokentxt;
        private TextBox idListtxt;
    }
}
