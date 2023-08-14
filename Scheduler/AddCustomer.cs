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
    public partial class AddCustomer : Form
    {
        User currentUser;
        public AddCustomer(User user)
        {
            InitializeComponent();
            MySQL data = new MySQL();
            currentUser = new User();
            currentUser.userName = user.userName;

           
        }

        private void InfoSaveButton_Click(object sender, EventArgs e)
        {
            bool textboxesnotempty;
            if (string.IsNullOrWhiteSpace(CustomerNameTextBox.Text))
            {
                textboxesnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(CustomerPhoneTextBox.Text))
            {
                textboxesnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(CustomerAddresssTextBox.Text))
            {
                textboxesnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(CustomerZipTextBox.Text))
            {
                textboxesnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(Citytextbox.Text))
            {
                textboxesnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(Countrytextbox.Text))
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
                Customer customer = new Customer();
                Address address = new Address();
                City city = new City();
                Country country = new Country();

                customer.createdBy = currentUser.userName;
                customer.createDate = DateTime.Now;
                customer.lastupdate = DateTime.Now;
                customer.lastupdateby = currentUser.userName;
                customer.customerName = CustomerNameTextBox.Text;
                address.address = CustomerAddresssTextBox.Text;
                address.address2 = CustomerAddresssTextBox.Text;
                address.postalCode = CustomerZipTextBox.Text;
                address.phone = CustomerPhoneTextBox.Text;
                address.createdate = DateTime.Now;
                address.lastupdate = DateTime.Now;
                address.createdby = currentUser.userName;
                address.lastupdateby = currentUser.userName;
                city.createdBy = currentUser.userName;
                city.lastUpdateBy = currentUser.userName;
                city.createDate = DateTime.Now;
                city.lastUpdate = DateTime.Now;
                city.city = Citytextbox.Text;
                country.country = Countrytextbox.Text;
                country.createDate = DateTime.Now;
                country.lastUpdate = DateTime.Now;
                country.lastUpdateBy = currentUser.userName;
                country.createdBy = currentUser.userName;

                city.countryID = data.addcountry(country);
                address.cityID = data.addcity(city);
                customer.addressID = data.AddAddress(address);

                if (data.AddCustomer(customer))
                {
                    new MainForm(currentUser).Show(); this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill fields", "ERROR", MessageBoxButtons.OK);
            }
           
        }

        private void InfoCancelButton_Click(object sender, EventArgs e)
        {
            new MainForm(currentUser).Show(); this.Close();
        }
    }
}
