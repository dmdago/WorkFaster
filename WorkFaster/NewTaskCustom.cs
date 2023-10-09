using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkFaster
{
    public partial class NewTaskCustom : Form
    {
        public NewTaskCustom()
        {
            InitializeComponent();
        }

        private void customTaskBtn_Click(object sender, EventArgs e)
        {
            Program.Fnname(customTasktxt.Text);
            this.Close();
        }

        private void NewTaskCustom_Load(object sender, EventArgs e)
        {
            customTasktxt.Focus();
        }

        private void customTasktxt_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                customTaskBtn.PerformClick();

        }
    }
}
