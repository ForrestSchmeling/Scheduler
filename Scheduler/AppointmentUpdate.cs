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
    public partial class AppointmentUpdate : Form
    {
        User currentUser;
        int apointId;
        bool validApoint;
        public AppointmentUpdate(User user, int apointSelected)
        {
            InitializeComponent();
            MySQL data = new MySQL();
            apointId = apointSelected;

            currentUser = user;
            


            TypeCombo.DataSource = data.GetType();
            TypeCombo.DisplayMember = data.GetType().Columns[0].ToString();



            Appointment apoint = data.GetAppointmentInfo(apointId);
            apoint.userID = currentUser.userID;
            CustomerTextBox.Text = apoint.customerID.ToString();
            TitleTextBox.Text = apoint.title;
            descriptiontextbox.Text = apoint.description;
            locationtextbox.Text = apoint.location;
            TypeCombo.Text = apoint.type;
            urltextbox.Text = apoint.url;
            contacttextbox.Text = apoint.contact;
            StartDateTimePicker.Value = apoint.startDate.ToLocalTime();
            EndDateTimePicker.Value = apoint.endDate.ToLocalTime();
        }

        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            MySQL data = new MySQL();
            

            bool overlap = data.CheckforoverlappingAppointmentWhenUpdating(StartDateTimePicker.Value.ToUniversalTime(), EndDateTimePicker.Value.ToUniversalTime(), apointId);
            if (StartDateTimePicker.Value.Hour < 8 || StartDateTimePicker.Value.Hour >= 16)
            {
                MessageBox.Show("Error start time, try setting the time between buisness hours of 8am-4pm", "Error", MessageBoxButtons.OK);
            }

            if (overlap)
            {
                validApoint = false;
                MessageBox.Show("There is overlapping appointments please choose a different time", "ERROR", MessageBoxButtons.OK);
            }
           
                if (StartDateTimePicker.Value.ToUniversalTime() < EndDateTimePicker.Value.ToUniversalTime())
                {
                    if (!overlap)
                    {
                        validApoint = true;
                    }
                }
                else
                {
                    validApoint = false;
                    MessageBox.Show("The start date should be less than the end date!", "ERROR", MessageBoxButtons.OK);
                }
            
        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            MySQL data = new MySQL();
            

            bool overlap = data.CheckforoverlappingAppointmentWhenUpdating(StartDateTimePicker.Value.ToUniversalTime(), EndDateTimePicker.Value.ToUniversalTime(), apointId);

            if (EndDateTimePicker.Value.Hour <= 8 || EndDateTimePicker.Value.Hour > 16)
            {
                MessageBox.Show("Error start time, try setting the time between buisness hours of 8am-4pm", "Error", MessageBoxButtons.OK);
            }


            if (overlap)
            {
                validApoint = false;
                MessageBox.Show("Error overlapping appointments", "Error", MessageBoxButtons.OK);
                
            }
            
                if (StartDateTimePicker.Value.ToUniversalTime() < EndDateTimePicker.Value.ToUniversalTime())
                {
                    if (!overlap)
                    {
                        validApoint = true;
                    
                    }

                }
                else 
                {
                    validApoint = false;
                    MessageBox.Show("The start date should be less than the end date!", "Error", MessageBoxButtons.OK);
                }
            

        }
            private void AppointmentSaveButton_Click(object sender, EventArgs e)
        {
            bool textboxnotempty;
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                textboxnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(descriptiontextbox.Text))
            {
                textboxnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(urltextbox.Text))
            {
                textboxnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(contacttextbox.Text))
            {
                textboxnotempty = false;
            }
            else if (string.IsNullOrWhiteSpace(locationtextbox.Text))
            {
                textboxnotempty = false;
            }
            else
            {
                textboxnotempty = true;
            }

            if (StartDateTimePicker.Value.Hour < 8 || StartDateTimePicker.Value.Hour >= 16 && EndDateTimePicker.Value.Hour <= 8 || EndDateTimePicker.Value.Hour > 16)
            {
                MessageBox.Show("ERROR start and end time should be betweeen hours of opperation 8AM-4PM", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                if (textboxnotempty)
                {

                    if (validApoint)
                    {
                     
                        Appointment apoint = new Appointment();
                        //string custid = apoint.customerID.ToString();
                        

                        apoint.appointmentID = apointId;
                       // custid = CustomerTextBox.Text;
                        apoint.userID = currentUser.userID;
                        apoint.title = TitleTextBox.Text;
                        apoint.description = descriptiontextbox.Text;
                        apoint.location = locationtextbox.Text;
                        apoint.type = TypeCombo.Text;
                        apoint.url = urltextbox.Text;
                        apoint.contact = contacttextbox.Text;
                        apoint.startDate = StartDateTimePicker.Value.ToUniversalTime();
                        apoint.endDate = EndDateTimePicker.Value.ToUniversalTime();
                        apoint.lastupdate = DateTime.Now;
                        apoint.lastupdateby = currentUser.userName;

                        MySQL data = new MySQL();


                        if (data.UpdateAppointment(apoint))
                        {
                            new MainForm(currentUser).Show(); this.Close();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Please enter valid times ", "ERROR", MessageBoxButtons.OK);
                    }
                }

                else
                {
                    MessageBox.Show("please fill all fields", "ERROR", MessageBoxButtons.OK);
                }
            }

        } // delete here
                    
                
            
        

        private void AppointmentCancelButton_Click(object sender, EventArgs e)
        {
            new MainForm(currentUser).Show();  this.Close();
        }

        
        }
    }

    

