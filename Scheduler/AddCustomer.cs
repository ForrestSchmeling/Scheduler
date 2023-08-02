using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void InfoSaveButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show(); this.Close();
        }

        private void InfoCancelButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show(); this.Close();
        }
    }
}
