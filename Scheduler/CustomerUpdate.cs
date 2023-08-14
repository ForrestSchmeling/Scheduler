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
    public partial class CustomerUpdate : Form
    {
        User currentUser;
        int custID;
        public CustomerUpdate(User user, int custId)
        {
            InitializeComponent();
            MySQL data = new MySQL();
            currentUser = user;
            custID = custId;

            CustomerInfo custinfo = data.GetCustomerInfo(custId);

            CustomerNameTextBox.Text = custinfo.customerName;
            CustomerPhoneTextBox.Text = custinfo.phone;
            CustomerAddresssTextBox.Text = custinfo.address;
           citytextbox.Text = custinfo.city;
            countrytextbox.Text = custinfo.country;
            CustomerZipTextBox.Text = custinfo.postalcode;



        }

        private void InfoSaveButton_Click(object sender, EventArgs e)
        {
            bool textboxesnotempty;
            if (string.IsNullOrWhiteSpace(CustomerNameTextBox.Text))
            {
                textboxesnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(CustomerAddresssTextBox.Text))
            {
                textboxesnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(CustomerPhoneTextBox.Text))
            {
                textboxesnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(CustomerZipTextBox.Text))
            {
                textboxesnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(citytextbox.Text))
            {
                textboxesnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(countrytextbox.Text))
            {
                textboxesnotempty = false;
            }
            else
            {
                textboxesnotempty = true;
            }
            if (textboxesnotempty)
            {
                MySQL data = new MySQL();
                CustomerInfo custinfo = new CustomerInfo();
                custinfo.customerID = custID;
                custinfo.customerName = CustomerNameTextBox.Text;
                custinfo.phone = CustomerPhoneTextBox.Text;
                custinfo.address = CustomerAddresssTextBox.Text;
                custinfo.address2 = CustomerAddresssTextBox.Text;
                custinfo.city = citytextbox.Text;
                custinfo.postalcode = CustomerZipTextBox.Text;
                custinfo.country = countrytextbox.Text;
                bool insertcustomerinfo = data.SaveCustomerInfo(custinfo);

                if (insertcustomerinfo)
                {
                    new MainForm(currentUser).Show(); this.Close();
                }
            }
            else
            {
                MessageBox.Show("please fill all fields", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void InfoCancelButton_Click(object sender, EventArgs e)
        {
            new MainForm(currentUser).Show(); this.Close();
        }

        private void CustomerUpdate_Load(object sender, EventArgs e)
        {

        }
    }
}
