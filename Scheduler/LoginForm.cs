using Scheduler.Database;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            MySQL data = new MySQL();
            User userInfo = new User(UserNameTextBox.Text, PasswordTextBox.Text);
            userInfo.userID = data.Verifyuserinfo(userInfo);
            

            if (userInfo.userID != -1)
            {
                DateTime datetime = DateTime.Now;
                data.LogUserLogin("USERNAME: " + userInfo.userName + " UserID: " + userInfo.userID + " Logged in at " + datetime);
                new MainForm(userInfo).Show(); this.Hide();
                List<Appointment> appointmentsSoon = data.CheckReminders(userInfo.userID);
                if(appointmentsSoon.Count > 0)
                {
                    foreach (var apoint in appointmentsSoon)
                    {
                        Reminder apointRem = new Reminder(apoint);
                            apointRem.Show();
                    }
                }
                
            }
            else
            {
                if (culture == "de")
                {
                    DateTime datetime = DateTime.Now;
                    data.LogUserLogin("FAILED LOGIN: " + "USERNAME: " + userInfo.userName + " UserID: " + userInfo.userID + " Tried at " + datetime);
                    const string message = "Unrichtig Nutzername/Passwort";
                    const string header = "Fehler";
                    MessageBox.Show(message, header, MessageBoxButtons.OK);
                }
                else
                {
                    DateTime datetime = DateTime.Now;
                    data.LogUserLogin("FAILED LOGIN: " + "USERNAME: " + userInfo.userName + " UserID: " + userInfo.userID + " Tried at " + datetime);
                    const string message = "Inccorect Username/Password";
                    const string header = "Error";
                    MessageBox.Show(message, header, MessageBoxButtons.OK);
                }
            }
            {

            }
            
        }
      



        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
