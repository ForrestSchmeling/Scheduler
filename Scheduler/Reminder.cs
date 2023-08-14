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
using Scheduler.Database;
namespace Scheduler
{
    public partial class Reminder : Form
    {
        public Reminder(Appointment apoint)
        {
            InitializeComponent();
            MySQL data = new MySQL();
            string name = data.GetCustomerInfo(apoint.customerID).customerName;
            string consultant = apoint.contact;
            

            Customer.Text = name;
            Consultant.Text = consultant;
            Location.Text = apoint.location;
            dateTimePicker1.Value = apoint.startDate.ToLocalTime();
            dateTimePicker2.Value = apoint.endDate.ToLocalTime();
        }

        private void OKButtton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
