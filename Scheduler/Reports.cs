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
            
            currentUser = user;
            InitializeComponent();
            
            MySQL data = new MySQL();
            CustomerCombo.DataSource = data.GetCustomerName();
            CustomerCombo.DisplayMember = data.GetCustomerName().Columns[0].ToString();

            ConsultantCombo.DataSource = data.GetConsultantName();
            ConsultantCombo.DisplayMember = data.GetConsultantName().Columns[0].ToString();

            monthscombo.SelectedIndex = 0;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new MainForm(currentUser).Show(); this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CustomerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySQL data = new MySQL();
            string customername = CustomerCombo.Text;
            AppointmentCustomerDGV.DataSource = data.GetAppointmentsbycusstname(customername);
        }

        private void ConsultantCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySQL data = new MySQL();
            string contactname = ConsultantCombo.Text;
            AppointmentConsultantDGV.DataSource = data.GetAppointmentsbycontactname(contactname);
        }

        private void monthscombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            MySQL data = new MySQL();
             int month = monthscombo.SelectedIndex;
            AppointmentTypeDGV.DataSource = data.gettypesmymonth( currentUser.userID, month);
        }

        private void AppointmentConsultantDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                var date = (DateTime)e.Value;
                var localdate = date.ToLocalTime();
                e.Value = localdate;

            }
        }

        private void AppointmentCustomerDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                var date = (DateTime)e.Value;
                var localdate = date.ToLocalTime();
                e.Value = localdate;

            }
        }

        private void AppointmentTypeDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                var date = (DateTime)e.Value;
                var localdate = date.ToLocalTime();
                e.Value = localdate;

            }
        }
    }
}
