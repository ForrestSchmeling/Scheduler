using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scheduler.Database;
using Scheduler.Models;

namespace Scheduler
{
    public partial class Reports : Form
    {
        User currentUser;
        public Reports(User user)
        {
            InitializeComponent();
            MySQL data = new MySQL();
            CustomerCombo.DataSource = data.GetCustomerName();
            CustomerCombo.DisplayMember = data.GetCustomerName().Columns[0].ToString();

            ConsultantCombo.DataSource = data.GetConsultantName();
            ConsultantCombo.DisplayMember = data.GetConsultantName().Columns[0].ToString();
            

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new MainForm(currentUser).Show(); this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
