using Scheduler.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scheduler.Models;

namespace Scheduler
{
    public partial class MainForm : Form
    {
        User currentUser;
        public MainForm(User user)
        {
            InitializeComponent();
            MySQL data = new MySQL();
            currentUser = new User();
            currentUser = user;
            CustomersDGV.DataSource = data.GetCustomers();
            AppointmentsDGV.DataSource = data.GetAppointments();
        }

        private void WeekViewRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MonthViewRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AllViewRadio_CheckedChanged(object sender, EventArgs e)
        {
            MySQL data = new MySQL();
            AppointmentsDGV.DataSource = data.GetAppointments();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            new LoginForm().Show(); this.Hide();
        }

        private void AppoitmentsAddButton_Click(object sender, EventArgs e)
        {
            int custSelected = Convert.ToInt32(CustomersDGV.Rows[CustomersDGV.CurrentCell.RowIndex].Cells[0].Value);
            if(custSelected != -1)
            {
                new AddAppointment(currentUser, custSelected).Show(); this.Hide();
            }
          else
            {
                MessageBox.Show("Please select a customer from the grid to add an appointment", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void AppoitmentsUpdateButton_Click(object sender, EventArgs e)
        {

           
            int apointSelected = Convert.ToInt32(AppointmentsDGV.Rows[AppointmentsDGV.CurrentCell.RowIndex].Cells[0].Value);
            if (apointSelected != -1)
            {
                new AppointmentUpdate(currentUser,apointSelected).Show(); this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a customer from the grid to modify an appointment", "ERROR", MessageBoxButtons.OK);
            }
           
        }

        private void AppoitmentsDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult aptdelete = MessageBox.Show("Are you sure you would like to delete this appointment, it cannot be undone", "Delete Appointment", MessageBoxButtons.YesNo);
            int apptselected = Convert.ToInt32(AppointmentsDGV.Rows[AppointmentsDGV.CurrentCell.RowIndex].Cells[0].Value);
            
            if(apptselected != -1)
            {
                if(aptdelete == DialogResult.Yes)
                {
                    MySQL data = new MySQL();
                    data.DeleteAppointment(apptselected);
                    AppointmentsDGV.DataSource = data.GetAppointments();
                }
            }
            else
            {
                MessageBox.Show("please select an appointment to delete", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void CustomersAddButton_Click(object sender, EventArgs e)
        {
            new AddCustomer(currentUser).Show(); this.Hide();
        }

        private void CustomersUpdateButton_Click(object sender, EventArgs e)
        {
            int custSelected = Convert.ToInt32(CustomersDGV.Rows[CustomersDGV.CurrentCell.RowIndex].Cells[0].Value);
            if (custSelected != -1)
            {
                new CustomerUpdate(currentUser, custSelected).Show(); this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a customer to modify", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void CustomersDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult custdelete = MessageBox.Show("Are you sure you would like to delete this customer, it cannot be undone", "Delete Customer", MessageBoxButtons.YesNo);
            int custSelected = Convert.ToInt32(CustomersDGV.Rows[CustomersDGV.CurrentCell.RowIndex].Cells[0].Value);

            if(custSelected != -1)
            {
                if(custdelete == DialogResult.Yes)
                {
                    MySQL data = new MySQL();
                    data.DeleteCustomer(custSelected);
                    CustomersDGV.DataSource = data.GetCustomers();
                }
            }
            else
            {
                MessageBox.Show("Select a customer to delete", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            new Reports(currentUser).Show(); this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
