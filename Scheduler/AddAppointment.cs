using Scheduler.Database;
using Scheduler.Models;
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
    public partial class AddAppointment : Form
    {

        User currentUser;
        bool validApoint;
        int custId;
        public AddAppointment(User user, int custSelected)
        {
            InitializeComponent();
            MySQL data = new MySQL();
            custId = custSelected;
            CustomerIdtextbox.Text = custSelected.ToString();

      

            TypeCombo.DataSource = data.GetType();
            TypeCombo.DisplayMember = data.GetType().Columns[0].ToString();

           

            currentUser = new User();
            currentUser.userName = user.userName;
            currentUser.userID = user.userID;

        }

        private void AppointmentSaveButton_Click(object sender, EventArgs e)
        {
          
           
                bool textboxesnotEmpty;
                if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
                {
                    textboxesnotEmpty = false;
                }
                else if (string.IsNullOrWhiteSpace(Descriptiontextbox.Text))
                {
                    textboxesnotEmpty = false;
                }
                else if (string.IsNullOrWhiteSpace(urltextbox.Text))
                {
                    textboxesnotEmpty = false;
                }
                else if (string.IsNullOrWhiteSpace(contacttextbox.Text))
                {
                    textboxesnotEmpty = false;
                }
                else if (string.IsNullOrWhiteSpace(locationtextbox.Text))
                {
                    textboxesnotEmpty = false;
                }
                else
                {
                    textboxesnotEmpty = true;
                }

            if (StartDateTimePicker.Value.Hour < 8 || StartDateTimePicker.Value.Hour >= 16 && EndDateTimePicker.Value.Hour <= 8 || EndDateTimePicker.Value.Hour > 16)
            {
                MessageBox.Show("ERROR start and end time should be betweeen hours of opperation 8AM-4PM", "ERROR", MessageBoxButtons.OK);
            }
            else
            {

                if (textboxesnotEmpty && validApoint)
                {

                    Appointment apoint = new Appointment();
                    User user = new User();
                    apoint.customerID = custId;
                    apoint.userID = currentUser.userID;
                    apoint.title = TitleTextBox.Text;
                    apoint.description = Descriptiontextbox.Text;
                    apoint.location = locationtextbox.Text;
                    apoint.contact = contacttextbox.Text;
                    apoint.type = TypeCombo.Text;
                    apoint.url = urltextbox.Text;
                    apoint.createDate = DateTime.Now;
                    apoint.createdBy = user.userName;
                    apoint.lastupdate = DateTime.Now;
                    apoint.lastupdateby = user.userName;
                    apoint.startDate = StartDateTimePicker.Value.ToUniversalTime();
                    apoint.endDate = EndDateTimePicker.Value.ToUniversalTime();

                    MySQL data = new MySQL();





                    if (data.AddAppointments(apoint) != -1)
                    {
                        new MainForm(currentUser).Show(); this.Close();
                    }


                }
                else
                {
                    MessageBox.Show("Please fill all available fields with correct items", "ERROR", MessageBoxButtons.OK);
                }



            }


           
        }




        private void AppointmentCancelButton_Click(object sender, EventArgs e)
        {
            new MainForm(currentUser).Show();  this.Close();
        }

        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            MySQL data = new MySQL();

            bool overlap = data.CheckforoverlappingAppointment(StartDateTimePicker.Value.ToUniversalTime(), EndDateTimePicker.Value.ToUniversalTime());
           
               if(StartDateTimePicker.Value.Hour < 8 || StartDateTimePicker.Value.Hour >= 16)
                {
                
                    MessageBox.Show("Error start time, try setting the time between buisness hours of 8am-4pm, a meeting cannot start at 4pm ", "Error", MessageBoxButtons.OK);
                }
           

            if (overlap)
            {
                validApoint = false;
                MessageBox.Show("There is overlapping appointments please choose a different time", "ERROR", MessageBoxButtons.OK);
            }
            if(StartDateTimePicker.Value.ToUniversalTime() < EndDateTimePicker.Value.ToUniversalTime())
            {
                if (!overlap)
                {
                    validApoint = true;
                }
            }
            else
            {
                validApoint = false;
                MessageBox.Show("There is overlapping appointments please choose a different time", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            MySQL data = new MySQL();

            bool overlap = data.CheckforoverlappingAppointment(EndDateTimePicker.Value.ToUniversalTime(), EndDateTimePicker.Value.ToUniversalTime());
           if( EndDateTimePicker.Value.Hour <= 8 || EndDateTimePicker.Value.Hour > 16 )
            {
                
                MessageBox.Show("Please have end time between hours of operation 8am - 4pm", "ERROR", MessageBoxButtons.OK);
            }
            

            if (overlap)
            {
                validApoint = false;
                MessageBox.Show("Error overlapping appointments", "Error", MessageBoxButtons.OK);
            }
            if(StartDateTimePicker.Value.ToUniversalTime() < EndDateTimePicker.Value.ToUniversalTime())
            {
                if (!overlap)
                {
                    validApoint = true;
                }
            }
            else
            {
                validApoint = false;
                MessageBox.Show("Error overlapping appointments", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
