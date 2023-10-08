using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorkFaster
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // Setting api data into texboxes
            this.apiKeytxt.Text = WorkFaster.Properties.Settings.Default.apiKeySet;
            this.apiTokentxt.Text = WorkFaster.Properties.Settings.Default.apiTokenSet;
            this.idListtxt.Text = WorkFaster.Properties.Settings.Default.apiIdListSet;

            // Set the initial state of the form to Minimized
            this.WindowState = FormWindowState.Minimized;

            // Optionally, you can hide the window if you don't want it to appear in the taskbar
            this.ShowInTaskbar = false;

            // Create ContextMenuStrip
            contextMenuStrip = new ContextMenuStrip();

            // Add "Exit" option
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit");
            exitMenuItem.Click += exitMenuItem_Click;
            contextMenuStrip.Items.Add(exitMenuItem);

            // Assign ContextMenuStrip
            notifyIcon.ContextMenuStrip = contextMenuStrip;
        }


        private void Main_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;

                WorkFaster.Properties.Settings.Default.apiKeySet = this.apiKeytxt.Text;
                WorkFaster.Properties.Settings.Default.apiTokenSet = this.apiTokentxt.Text;
                WorkFaster.Properties.Settings.Default.apiIdListSet = this.idListtxt.Text;
                WorkFaster.Properties.Settings.Default.Save();

            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void exitMenuItem_Click(object? sender, EventArgs e)
        {
            // Clean everything
            // Pending code


            // Close app
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void callApiButton_Click(object sender, EventArgs e)
        {

        }
    }
}