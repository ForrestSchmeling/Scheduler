using MySql.Data.MySqlClient;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler.Database
{
    class MySQL
    {
        public static MySqlConnection conn { get; set; }
        
        public static void startConnection() {
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            conn = new MySqlConnection(constr);
                conn.Open();
            }
            
    

        public static void closeConnection()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void LogUserLogin(string logtext)
        {
            DirectoryInfo info = new DirectoryInfo(".");
            string logPath = info + "\\logfile.txt";
            if (!File.Exists(logPath))
            {
                var file = File.Create(logPath);
                file.Close();
                TextWriter textwriter = new StreamWriter(logPath);
                textwriter.WriteLine(logtext);
                textwriter.Close();
            }
            else if(File.Exists(logPath)){
                using (var textwriter = new StreamWriter(logPath, true))
                {
                    textwriter.WriteLine(logtext);
                }
            }
        }

        public int Verifyuserinfo(User userInfo)
        {
            int userID = -1;

            string enteredUsername;
            string enteredPassword;

            try
            {
                MySqlCommand checkUserNamecmd = conn.CreateCommand();
                checkUserNamecmd.CommandText = "SELECT EXISTS(SELECT userName FROM user WHERE username = @username)";
                checkUserNamecmd.Parameters.AddWithValue("@username", userInfo.userName);
                enteredUsername = checkUserNamecmd.ExecuteScalar().ToString();


                MySqlCommand checkPasswordcmd = conn.CreateCommand();
                checkPasswordcmd.CommandText = " SELECT EXISTS(SELECT password FROM user WHERE BINARY password = @password AND username = @username)";
                checkPasswordcmd.Parameters.AddWithValue("@password", userInfo.passWord);
                checkPasswordcmd.Parameters.AddWithValue("@username", userInfo.userName);
                enteredPassword = checkPasswordcmd.ExecuteScalar().ToString();

                if (enteredUsername == "1" && enteredPassword == "1")
                {
                    MySqlCommand entereduserIdcmd = conn.CreateCommand();
                    entereduserIdcmd.CommandText = "SELECT userId FROM user WHERE BINARY password = @password AND username = @username";
                    entereduserIdcmd.Parameters.AddWithValue("@password", userInfo.passWord);
                    entereduserIdcmd.Parameters.AddWithValue("@username", userInfo.userName);
                    userID = (int)entereduserIdcmd.ExecuteScalar();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return userID;
            }

        public List <Appointment> CheckReminders(int userId)
        {
            List<Appointment> apoint = new List<Appointment>();
            DateTime Currentutc = DateTime.UtcNow;

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM appointment WHERE userId = @userId AND TIMESTAMPDIFF(MINUTE, start, @currentTime) <15";
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@currentTime", Currentutc);
                cmd.ExecuteNonQuery();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        apoint.Add(new Appointment()
                        {
                            customerID = (int)reader["customerId"],
                            title = reader["appointmentId"].ToString(),
                            contact = reader["contact"].ToString(),
                            location = reader["location"].ToString(),
                            description = reader["appointmentId"].ToString(),
                            type = reader["type"].ToString(),
                            startDate = Convert.ToDateTime(reader["start"]),
                            endDate = Convert.ToDateTime(reader["end"])
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return apoint;

        }

        public CustomerInfo GetCustomerInfo(int customerID)
        {
            CustomerInfo CustomerInf = new CustomerInfo();

            try
            {
                string query = "SELECT customer.customerName, address.phone, address.address, address.postalCode, city.city, country.country FROM customer" +
                    "LEFT JOIN address ON customer.addressId = address.addrressId" +
                    "LEFT JOIN city ON address.Id = city.cityId" +
                    "LEFT JOIN country ON city.countryId = country.countryId" +
                    "WHERE customer.customerId = @CustomerId";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@CustomerId", customerID);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerInf.customerName = reader["customerName"].ToString();
                        CustomerInf.address = reader["address"].ToString();
                        CustomerInf.city = reader["city"].ToString();
                        CustomerInf.country = reader["country"].ToString();
                        CustomerInf.postalcode = reader["postalCode"].ToString();
                        CustomerInf.phone = reader["phone"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exeption thrown getting customerinformation " + ex);
            }
            return CustomerInf;
        }

        public bool SaveCustomerInfo(CustomerInfo CustomerInf)
        {
            bool success;

            try
            {

                string UpdateCommand =
                    "UPDATE customer SET customerName = @customerName WHERE customerId = @customerId;" +
                    "UPDATE address SET address = @address, postalcode = @postalCode, phone= @phone " +
                    "WHERE addressId = (SELECT addressId FROM customer WHERE customerId = @customerId); " +
                    "UPDATE city SET city = @city" +
                    "WHERE cityId = (SELECT cityId FROM address WHERE addressId = (SELECT addressId FROM customer WHERE customerId = @customerID));" +
                    "UPDATE country SET country = @country" +
                    "WHERE countryId = (SELECT countryId FROM city WHERE cityId = (SELECT cityId FROM address WHERE addressId = (SELECT addressId FROM customer WHERE customerId= @customerId";

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = UpdateCommand;

                cmd.Parameters.AddWithValue("@customerId", CustomerInf.customerID);
                cmd.Parameters.AddWithValue("@customerName", CustomerInf.customerName);
                cmd.Parameters.AddWithValue("@address", CustomerInf.address);
                cmd.Parameters.AddWithValue("@city", CustomerInf.city);
                cmd.Parameters.AddWithValue("@postalCode", CustomerInf.postalcode);
                cmd.Parameters.AddWithValue("@phone", CustomerInf.phone);
                cmd.Parameters.AddWithValue("@country", CustomerInf.country);
                cmd.ExecuteNonQuery();

                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customerinfo" + ex);
                success = false;
            }
            return success;
        }


        public DataTable GetCustomers()
        {
            DataTable CustomersDataTable = new DataTable();
            if(!CustomersDataTable.Columns.Contains("ID")) { CustomersDataTable.Columns.Add("ID", typeof(int)); }
            if (!CustomersDataTable.Columns.Contains("Name")) { CustomersDataTable.Columns.Add("Name", typeof(string)); }
            if (!CustomersDataTable.Columns.Contains("PhoneNumber")) { CustomersDataTable.Columns.Add("PhoneNumber", typeof(string)); }
            if (!CustomersDataTable.Columns.Contains("Address")) { CustomersDataTable.Columns.Add("Address", typeof(string)); }
            if (!CustomersDataTable.Columns.Contains("City")) { CustomersDataTable.Columns.Add("City", typeof(string)); }
            if (!CustomersDataTable.Columns.Contains("PostalCode")) { CustomersDataTable.Columns.Add("PostalCode", typeof(string)); }
            if (!CustomersDataTable.Columns.Contains("Country")) { CustomersDataTable.Columns.Add("Country", typeof(string)); }
            try
            {
                string query = "SELECT customer.customerId, customer.customerName, customer.phone, customer.address, customer.city, customer.postalCode, customer.country FROM customer" +
                    "LEFT JOIN address ON customer.addressId = address.addressId" +
                    "LEFT JOIN city ON customer.cityId = city.cityId" +
                    "LEFT JOIN country ON customer.countryId = country.countryId";

                MySqlCommand command = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomersDataTable.Rows.Add(reader["customerId"], reader["customerName"], reader["phone"], reader["address"], reader["city"], reader["postalCode"], reader["country"] );

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error getting customers " + ex);
            }
            return CustomersDataTable;
        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = ("INSERT INTO customer(customerName,addressId,active) VAlUES(@customerName, @addressId, @active");
                cmd.Parameters.AddWithValue("@customerName", customer.customerName);
                cmd.Parameters.AddWithValue("@addressId", customer.addressID);
                cmd.Parameters.AddWithValue("@active", 1);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error creating customer " + ex);
                return false;
            }
            return true;
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM customer WHERE customerID = @customerId";
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error deleting customer " + ex);
                return false;
            }
            return true;
        }

        public int AddAddress(Address address)
        {
            int addressId = -1;

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO address(address,cityId,postalCode,phone) VALUES (@address, @cityId, @postalCode, @phone);" +
                    "SELECT addressId FROM address ORDER BY addressId DESC Limit 1";
                cmd.Parameters.AddWithValue("@address", address.address);
                cmd.Parameters.AddWithValue("@cityId", address.cityID);
                cmd.Parameters.AddWithValue("@postalCode", address.postalCode);
                cmd.Parameters.AddWithValue("@phone", address.phone);
                addressId = (int)cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error adding address " + ex);
            }
            return addressId;
        }

        public DataTable GetAppointments(int customerId, int userId)
        {

            DataTable AppointmentsDataTable = new DataTable();

            if (!AppointmentsDataTable.Columns.Contains("ID"))  { AppointmentsDataTable.Columns.Add("ID", typeof(int)); }
            if (!AppointmentsDataTable.Columns.Contains("Title")) { AppointmentsDataTable.Columns.Add("Title", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("CustomerName")) { AppointmentsDataTable.Columns.Add("CustomerName", typeof(string)); }

            try
            {
                string query = "SELECT appointment.appointmentId, appointment.title, customer.customerName FROM appointment" +
                    "LEFT JOIN customer ON appointment.customerId = customer.customerId" +
                    "WHERE appointment.customerId = @customerId AND appointment.userId = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@userId", userId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read()){
                        AppointmentsDataTable.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"]);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error getting appointments " + ex);
            }
            return AppointmentsDataTable;

        }

        public int AddAppointments(Appointment apt)
        {
            int aptId = -1;

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO appointment(customerId, userId, title, description, location, contact,type, start, end) VALUES (@customerId, @userId,@title,@description,@location,@contact,@type,@start,@end);" +
                    "SELECT appointmentId FROM appointment ORDER BY appointmentId DESC LIMIT 1";
                cmd.Parameters.AddWithValue("@customerId", apt.customerID);
                cmd.Parameters.AddWithValue("@userId", apt.userID);
                cmd.Parameters.AddWithValue("@title", apt.title);
                cmd.Parameters.AddWithValue("@description", apt.description);
                cmd.Parameters.AddWithValue("@location", apt.location);
                cmd.Parameters.AddWithValue("@contact", apt.contact);
                cmd.Parameters.AddWithValue("@type", apt.type);
                cmd.Parameters.AddWithValue("@start", apt.startDate);
                cmd.Parameters.AddWithValue("@end", apt.endDate);
                aptId = (int)cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error adding appointments " + ex);
            }
            return aptId;
        }

        public bool UpdateAppointment(Appointment aptinfo)
        {
            bool success;

            try
            {
                string UpdateCommand =
                    "UPDATE appointment SET customerId =@customerId, userId = @userId, description = @description, location = @location, " +
                    "contact = @contact, start = @start, end = @end WHERE appointmentId = @appointmentId";
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = UpdateCommand;
                cmd.Parameters.AddWithValue("@appointmentId", aptinfo.appointmentID);
                cmd.Parameters.AddWithValue("@customerId", aptinfo.customerID);
                cmd.Parameters.AddWithValue("@userId", aptinfo.userID);
                cmd.Parameters.AddWithValue("@title", aptinfo.title);
                cmd.Parameters.AddWithValue("@descripton", aptinfo.description);
                cmd.Parameters.AddWithValue("@location", aptinfo.location);
                cmd.Parameters.AddWithValue("@contact", aptinfo.contact);
                cmd.Parameters.AddWithValue("@type", aptinfo.type);
                cmd.Parameters.AddWithValue("@start", aptinfo.startDate);
                cmd.Parameters.AddWithValue("@end", aptinfo.endDate);
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error saving customer " + ex);
                success = false;
            }
            return success;
        }

        public bool DeleteAppointment(int aptId)
        {
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Delete FROM appointment WHERE appointmentId= @appointmentId";
                cmd.Parameters.AddWithValue("@appointmentId", aptId);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error deleting appointment " + ex);
                return false;
            }
            return true;
        }

        public Appointment GetAppointmentInfo(int aptId)
        {
            Appointment aptinfo = new Appointment();

            try
            {
                string query = "SELECT customerId, title, description, location,contact, type,start,end FROM appointment WHERE appointmentId = @appointmentId";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@appointmentId", aptId);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        aptinfo.customerID = (int)reader["@customerId"];
                        aptinfo.userID = (int)reader["@userId"];
                        aptinfo.title = reader["@title"].ToString();
                        aptinfo.description = reader["@description"].ToString();
                        aptinfo.location = reader["@location"].ToString();
                        aptinfo.contact = reader["@contact"].ToString();
                        aptinfo.type = reader["@type"].ToString();
                        aptinfo.startDate = Convert.ToDateTime(reader["@start"]);
                        aptinfo.endDate = Convert.ToDateTime(reader["@end"]);
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error getting appointment " + ex);
            }
            return aptinfo;
        }

        public bool CheckforoverlappingAppointment(DateTime aptstart, DateTime aptend)
        {
            bool overlap = false;

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT EXISTS(SELECT * FROM appointment WHERE START <= @end AND end >=@start)";
                cmd.Parameters.AddWithValue("@start", aptstart);
                cmd.Parameters.AddWithValue("@end", aptend);

                if(cmd.ExecuteScalar().ToString() == "1")
                {
                    overlap = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error checking for overlap " + ex);
                
            }
            return overlap;
        }








        } 

    }



