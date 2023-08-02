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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void WeekViewRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MonthViewRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AllViewRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            new LoginForm().Show(); this.Hide();
        }

        private void AppoitmentsAddButton_Click(object sender, EventArgs e)
        {
            new Appointment().Show(); this.Hide();
        }

        private void AppoitmentsUpdateButton_Click(object sender, EventArgs e)
        {
            new AppointmentUpdate().Show(); this.Hide();
        }

        private void AppoitmentsDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void CustomersAddButton_Click(object sender, EventArgs e)
        {
            new AddCustomer().Show(); this.Hide();
        }

        private void CustomersUpdateButton_Click(object sender, EventArgs e)
        {
            new CustomerUpdate().Show(); this.Hide();
        }

        private void CustomersDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
