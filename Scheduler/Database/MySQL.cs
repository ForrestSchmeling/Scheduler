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

        public List<Appointment> CheckReminders(int userId)
        {
            List<Appointment> apoint = new List<Appointment>();
            DateTime Currentutc = DateTime.UtcNow;
            
            
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM appointment WHERE userId = @userId AND start BETWEEN @currentTime AND DATE_ADD(@currentTime , INTERVAL 15 MINUTE) ";
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
                string query = "SELECT customer.customerName, address.phone, address.address, address.postalCode, city.city, country.country FROM customer " +
                    "LEFT JOIN address ON customer.addressId = address.addressId " +
                    "LEFT JOIN city ON address.cityId = city.cityId " +
                    "LEFT JOIN country ON city.countryId = country.countryId " +
                    "WHERE customer.customerId = @custId";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@custId", customerID);
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
                    "UPDATE city SET city = @city " +
                    "WHERE cityId = (SELECT cityId FROM address WHERE addressId = (SELECT addressId FROM customer WHERE customerId = @customerID));" +
                    "UPDATE country SET country = @country " +
                    "WHERE countryId = (SELECT countryId FROM city WHERE cityId = (SELECT cityId FROM address WHERE addressId = (SELECT addressId FROM customer WHERE customerId= @customerId)))";

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
                string query = "SELECT customer.customerId, customer.customerName, address.phone, address.address, city.city, address.postalCode, country.country FROM customer " +
                    "LEFT JOIN address ON customer.addressId = address.addressId " +
                    "LEFT JOIN city ON address.cityId = city.cityId " +
                    "LEFT JOIN country ON city.countryId = country.countryId";

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

        public DataTable Getlocation()
        {
            DataTable location = new DataTable();
            if (!location.Columns.Contains("Name")) { location.Columns.Add("Name", typeof(string)); }
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT location FROM appointment;";
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    location.Rows.Add(reader["location"]);

                }
            }
            return location;
        }

        public DataTable Getcountry()
        {
            DataTable country = new DataTable();
            if (!country.Columns.Contains("Name")) { country.Columns.Add("Name", typeof(string)); }
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT country FROM country;";
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    country.Rows.Add(reader["country"]);

                }
            }
            return country;
        }



        public DataTable Getcity()
        {
            DataTable city = new DataTable();
            if (!city.Columns.Contains("Name")) { city.Columns.Add("Name", typeof(string)); }
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT city FROM city;";
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    city.Rows.Add(reader["city"]);

                }
            }
            return city;
        }


        public DataTable GetType()
        {
            DataTable type = new DataTable();
            if (!type.Columns.Contains("Name")) { type.Columns.Add("Name", typeof(string)); }
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT type FROM appointment;";
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    type.Rows.Add(reader["type"]);

                }
            }
            return type;
        }

        public DataTable GetConsultantName()
        {
            DataTable consultant = new DataTable();
            if (!consultant.Columns.Contains("Name")) { consultant.Columns.Add("Name", typeof(string)); }
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT contact FROM appointment;";
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    consultant.Rows.Add(reader["contact"]);

                }
            }
            return consultant;
        }

            public DataTable GetCustomerName()
        {
            DataTable Customers = new DataTable();
            if (!Customers.Columns.Contains("Name")) { Customers.Columns.Add("Name", typeof(string)); }
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT customer.customerName FROM customer;";
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Customers.Rows.Add(reader["customerName"]);

                }
            }
            return Customers;

        }
        public bool AddCustomer(Customer customer)
        {
            
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO customer(customerName,addressId, active,createdBy, createDate,lastUpdate, lastUpdateBy) VAlUES(@customerName,@addressId, @active,@createdBy, @createDate,@lastUpdate,@lastUpdateBy) ";

                cmd.Parameters.AddWithValue("@customerName", customer.customerName);
                cmd.Parameters.AddWithValue("@addressId", customer.addressID);
                cmd.Parameters.AddWithValue("@active", 1);
                cmd.Parameters.AddWithValue("@createdBy", customer.createdBy);
                cmd.Parameters.AddWithValue("@createDate", customer.createDate);
                cmd.Parameters.AddWithValue("@lastUpdate", customer.lastupdate);
                cmd.Parameters.AddWithValue("@lastUpdateBy", customer.lastupdateby);
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
                cmd.CommandText = "INSERT INTO address(address,address2,cityId,postalCode,phone, createdBy,createDate,lastUpdate,lastUpdateBy) VALUES (@address,@address2,@cityId, @postalCode, @phone, @createdBy,@createDate,@lastUpdate,@lastUpdateBy); " +
                    "SELECT addressId FROM address ORDER BY addressId DESC Limit 1";
                cmd.Parameters.AddWithValue("@address", address.address);
                cmd.Parameters.AddWithValue("@address2", address.address2);

                cmd.Parameters.AddWithValue("@cityId", address.cityID);
                cmd.Parameters.AddWithValue("@postalCode", address.postalCode);
                cmd.Parameters.AddWithValue("@phone", address.phone);
                cmd.Parameters.AddWithValue("@createdBy", address.createdby);
                cmd.Parameters.AddWithValue("@createDate", address.createdate);
                cmd.Parameters.AddWithValue("@lastUpdate", address.lastupdate);
                cmd.Parameters.AddWithValue("@lastUpdateBy", address.lastupdateby);
                addressId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding address " + ex);
                addressId = -1;
            }
            return addressId;
        }

        public int addcity(City city)
        {
            int cityId = -1;
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO city (city,countryId, createDate,lastUpdate,createdBy,lastUpdateBy) VALUES (@city, @countryId,@createDate,@lastUpdate,@createdBy,@lastUpdateBy); " +
                    "SELECT cityId FROM city ORDER BY cityId DESC LIMIT 1";
                cmd.Parameters.AddWithValue("@city", city.city);
                cmd.Parameters.AddWithValue("@countryId", city.countryID);
                cmd.Parameters.AddWithValue("@createDate", city.createDate);
                cmd.Parameters.AddWithValue("@lastUpdate", city.lastUpdate);
                cmd.Parameters.AddWithValue("@createdBy", city.createdBy);
                cmd.Parameters.AddWithValue("@lastUpdateBy", city.lastUpdateBy);
                cityId = (int)cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR adding city" + ex , "ERROR", MessageBoxButtons.OK);
                cityId = -1;
            }
            return cityId;
        }

        public int addcountry(Country country)
        {
            int countryId = -1;

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO country(country,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES(@Country,@createDate,@createdBy,@lastUpdate,@lastUpdateBy); " +
                    "SELECT countryId FROM country ORDER BY countryId DESC LIMIT 1";
                cmd.Parameters.AddWithValue("@country", country.country);
                cmd.Parameters.AddWithValue("@createDate", country.createDate);
                cmd.Parameters.AddWithValue("@createdBy", country.createdBy);
                cmd.Parameters.AddWithValue("@lastUpdate", country.lastUpdate);
                cmd.Parameters.AddWithValue("@lastUpdateBy", country.lastUpdateBy);
                countryId = (int)cmd.ExecuteScalar();

            }
            catch(Exception ex)
            {
                MessageBox.Show("error adding country" + ex, "ERROR", MessageBoxButtons.OK);
                countryId = -1;
            }
            return countryId;
        }

        public DataTable GetAppointmentsbycusstname(string customername)
        {

            DataTable AppointmentsDataTable = new DataTable();

            if (!AppointmentsDataTable.Columns.Contains("ID"))  { AppointmentsDataTable.Columns.Add("ID", typeof(int)); }
            if (!AppointmentsDataTable.Columns.Contains("Title")) { AppointmentsDataTable.Columns.Add("Title", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("CustomerName")) { AppointmentsDataTable.Columns.Add("CustomerName", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Contact")) { AppointmentsDataTable.Columns.Add("Contact", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Location")) { AppointmentsDataTable.Columns.Add("Location", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Start")) { AppointmentsDataTable.Columns.Add("Start", typeof(DateTime)); }
            if (!AppointmentsDataTable.Columns.Contains("End")) { AppointmentsDataTable.Columns.Add("End", typeof(DateTime)); }
            try
            {
                string query = "SELECT appointment.appointmentId, appointment.title, customer.customerName,appointment.contact,appointment.location,appointment.start, appointment.end FROM appointment " +
                    "LEFT JOIN customer ON appointment.customerId = customer.customerId " +
                    "WHERE customer.customerName = @customerName";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@customerName", customername);
                

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) {
                        AppointmentsDataTable.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["contact"], reader["location"],reader["start"], reader["end"]);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error getting appointments by customer name: " + ex);
            }
            return AppointmentsDataTable;

        }


        public DataTable GetAppointmentsbycontactname(string contactname)
        {

            DataTable AppointmentsDataTable = new DataTable();

            if (!AppointmentsDataTable.Columns.Contains("ID")) { AppointmentsDataTable.Columns.Add("ID", typeof(int)); }
            if (!AppointmentsDataTable.Columns.Contains("Title")) { AppointmentsDataTable.Columns.Add("Title", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("CustomerName")) { AppointmentsDataTable.Columns.Add("CustomerName", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Contact")) { AppointmentsDataTable.Columns.Add("Contact", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Location")) { AppointmentsDataTable.Columns.Add("Location", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Start")) { AppointmentsDataTable.Columns.Add("Start", typeof(DateTime)); }
            if (!AppointmentsDataTable.Columns.Contains("End")) { AppointmentsDataTable.Columns.Add("End", typeof(DateTime)); }
            try
            {
                string query = "SELECT appointment.appointmentId, appointment.title, customer.customerName,appointment.contact,appointment.location,appointment.start, appointment.end FROM appointment " +
                    "LEFT JOIN customer ON appointment.customerId = customer.customerId " +
                    "WHERE appointment.contact = @contact";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@contact", contactname);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AppointmentsDataTable.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["contact"], reader["location"], reader["start"], reader["end"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting appointments " + ex);
            }
            return AppointmentsDataTable;

        }



        public DataTable GetAppointments()
        {

            DataTable AppointmentsDataTable = new DataTable();

            if (!AppointmentsDataTable.Columns.Contains("ID")) { AppointmentsDataTable.Columns.Add("ID", typeof(int)); }
            if (!AppointmentsDataTable.Columns.Contains("Title")) { AppointmentsDataTable.Columns.Add("Title", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("CustomerName")) { AppointmentsDataTable.Columns.Add("CustomerName", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Contact")) { AppointmentsDataTable.Columns.Add("Contact", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Location")) { AppointmentsDataTable.Columns.Add("Location", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Start")) { AppointmentsDataTable.Columns.Add("Start", typeof(DateTime)); }
            if (!AppointmentsDataTable.Columns.Contains("End")) { AppointmentsDataTable.Columns.Add("End", typeof(DateTime)); }
            try
            {
                string query = "SELECT appointment.appointmentId, appointment.title, customer.customerName, appointment.contact, appointment.location, appointment.start, appointment.end FROM appointment " +
                    "LEFT JOIN customer ON appointment.customerId = customer.customerId";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AppointmentsDataTable.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["contact"], reader["location"], reader["start"], reader["end"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting appointments " + ex);
            }
            return AppointmentsDataTable;

        }

        public DataTable GetAppointmentsbyWeek()
        {

            DateTime startofweek = DateTime.UtcNow;
            DateTime endofweek = startofweek.AddDays(7);
            DataTable AppointmentsDataTable = new DataTable();

            if (!AppointmentsDataTable.Columns.Contains("ID")) { AppointmentsDataTable.Columns.Add("ID", typeof(int)); }
            if (!AppointmentsDataTable.Columns.Contains("Title")) { AppointmentsDataTable.Columns.Add("Title", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("CustomerName")) { AppointmentsDataTable.Columns.Add("CustomerName", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Contact")) { AppointmentsDataTable.Columns.Add("Contact", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Location")) { AppointmentsDataTable.Columns.Add("Location", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Start")) { AppointmentsDataTable.Columns.Add("Start", typeof(DateTime)); }
            if (!AppointmentsDataTable.Columns.Contains("End")) { AppointmentsDataTable.Columns.Add("End", typeof(DateTime)); }
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT appointment.appointmentId, appointment.title, customer.customerName, appointment.contact, appointment.location, appointment.start, appointment.end FROM appointment " +
                "LEFT JOIN customer ON appointment.customerId = customer.customerId " +
                "WHERE appointment.start BETWEEN @startofweek AND @endofweek";
                cmd.Parameters.AddWithValue("@startofweek", startofweek);
                cmd.Parameters.AddWithValue("@endofweek", endofweek);
                cmd.ExecuteNonQuery();
                

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AppointmentsDataTable.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["contact"], reader["location"], reader["start"], reader["end"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting appointments by week " + ex);
            }
            return AppointmentsDataTable;

        }
        public DataTable GetAppointmentsbymonth()
        {

            DateTime thisdate = DateTime.UtcNow;
            int month = thisdate.Month;
            DataTable AppointmentsDataTable = new DataTable();

            if (!AppointmentsDataTable.Columns.Contains("ID")) { AppointmentsDataTable.Columns.Add("ID", typeof(int)); }
            if (!AppointmentsDataTable.Columns.Contains("Title")) { AppointmentsDataTable.Columns.Add("Title", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("CustomerName")) { AppointmentsDataTable.Columns.Add("CustomerName", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Contact")) { AppointmentsDataTable.Columns.Add("Contact", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Location")) { AppointmentsDataTable.Columns.Add("Location", typeof(string)); }
            if (!AppointmentsDataTable.Columns.Contains("Start")) { AppointmentsDataTable.Columns.Add("Start", typeof(DateTime)); }
            if (!AppointmentsDataTable.Columns.Contains("End")) { AppointmentsDataTable.Columns.Add("End", typeof(DateTime)); }
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT appointment.appointmentId, appointment.title, customer.customerName, appointment.contact, appointment.location, appointment.start, appointment.end FROM appointment " +
                "LEFT JOIN customer ON appointment.customerId = customer.customerId " +
                "WHERE MONTH(appointment.start) = @month";
                cmd.Parameters.AddWithValue("@month", month);
                cmd.ExecuteNonQuery();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AppointmentsDataTable.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["contact"], reader["location"], reader["start"], reader["end"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting appointments by month " + ex);
            }
            return AppointmentsDataTable;

        }




        public int AddAppointments(Appointment apt)
        {
            int aptId = -1;

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO appointment(customerId, userId, title, description, location, contact,type, url,createDate,createdBy, lastUpdate, lastUpdateBy, start, end) VALUES (@customerId, @userId,@title,@description,@location,@contact,@type,@url,@createDate,@createdBy,@lastUpdate, @lastUpdateBy, @start,@end);" +
                    "SELECT appointmentId FROM appointment ORDER BY appointmentId DESC LIMIT 1";
                cmd.Parameters.AddWithValue("@customerId", apt.customerID);
                cmd.Parameters.AddWithValue("@userId", apt.userID);
                cmd.Parameters.AddWithValue("@title", apt.title);
                cmd.Parameters.AddWithValue("@description", apt.description);
                cmd.Parameters.AddWithValue("@location", apt.location);
                cmd.Parameters.AddWithValue("@contact", apt.contact);
                cmd.Parameters.AddWithValue("@type", apt.type);
                cmd.Parameters.AddWithValue("@url", apt.url);
                cmd.Parameters.AddWithValue("@createDate", apt.createDate);
                cmd.Parameters.AddWithValue("@createdBy", apt.createdBy);
                cmd.Parameters.AddWithValue("@lastUpdate", apt.lastupdate);
                cmd.Parameters.AddWithValue("@lastUpdateBy", apt.lastupdateby);
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
                    "UPDATE appointment SET  userId = @userId, description = @description, location = @location, " +
                    "contact = @contact, start = @start, end = @end WHERE appointmentId = @appointmentId";
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = UpdateCommand;
                cmd.Parameters.AddWithValue("@appointmentId", aptinfo.appointmentID);
                cmd.Parameters.AddWithValue("@customerId", aptinfo.customerID);
                cmd.Parameters.AddWithValue("@userId", aptinfo.userID);
                cmd.Parameters.AddWithValue("@title", aptinfo.title);
                cmd.Parameters.AddWithValue("@description", aptinfo.description);
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
                cmd.CommandText = "Delete FROM appointment WHERE appointmentId = @appointmentId";
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
                string query = "SELECT customerId, userId, title, description, location,contact, type,url,start,end FROM appointment WHERE appointmentId = @appointmentId";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@appointmentId", aptId);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        aptinfo.customerID = (int)reader["customerId"];
                        aptinfo.userID = (int)reader["userId"];
                        aptinfo.title = reader["title"].ToString();
                        aptinfo.description = reader["description"].ToString();
                        aptinfo.location = reader["location"].ToString();
                        aptinfo.contact = reader["contact"].ToString();
                        aptinfo.type = reader["type"].ToString();
                        aptinfo.url = reader["url"].ToString();
                        aptinfo.startDate = Convert.ToDateTime(reader["start"]);
                        aptinfo.endDate = Convert.ToDateTime(reader["end"]);
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

        public DataTable gettypesmymonth(int userId, int month)
        {
            DataTable monthstable = new DataTable();
            if (!monthstable.Columns.Contains("Counts")) { monthstable.Columns.Add("counts", typeof(int)); }

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(type) AS counts from appointment WHERE userId = @userId AND Month(start) = @month";
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.ExecuteNonQuery();

                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        monthstable.Rows.Add(reader["counts"]);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR getting appointment types by month", "ERROR", MessageBoxButtons.OK);
            }
            return monthstable;
        }







        } 

    }



