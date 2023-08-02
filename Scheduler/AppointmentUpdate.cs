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
    public partial class AppointmentUpdate : Form
    {
        public AppointmentUpdate()
        {
            InitializeComponent();
        }

        private void AppointmentSaveButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show(); this.Close();
        }

        private void AppointmentCancelButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show();  this.Close();
        }
    }
}
