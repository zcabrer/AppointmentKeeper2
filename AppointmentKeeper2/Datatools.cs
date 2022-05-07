using AppointmentKeeper2.Forms;
using AppointmentKeeper2.Modules;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentKeeper2
{
    static class Datatools
    {
        //Create DB connection
        static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "appkeeperdb.mysql.database.azure.com",
            Database = "client_schedule",
            UserID = "appkeeperadmin@appkeeperdb",
            Password = "WGUcapstone890!!",
            SslMode = MySqlSslMode.Required,
        };
        public static MySqlConnection conn = new MySqlConnection(builder.ConnectionString);


        public static int validateLogin(string userName, string password)
        {
            int userId = 0;

            try
            {
                conn.Open();
                string query = "SELECT userId FROM user WHERE userName = @uName AND password = @pass";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@uName", userName);
                cmd.Parameters.AddWithValue("@pass", password);
                Object user = cmd.ExecuteScalar();
                userId = Convert.ToInt32(user);

            }
            catch (Exception)
            {
                LoginForm.Exception = true;
            }
            finally
            {
                conn.Close();
            }

            return userId;

        }
        public static DataTable customerTable()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string query =
                        "SELECT customerId AS ID, customerName AS name, phone, address, city, country FROM customer " +
                        "JOIN address ON customer.addressId = address.AddressId " +
                        "JOIN city ON address.cityId = city.cityId " +
                        "JOIN country ON city.countryId = country.countryId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting customer table\n\n" + ex);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public static DataTable appointmentTableByUser(int userId)
        {
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                string query =
                        "SELECT appointmentId AS ID, customerName AS name, userName AS consultant, type, start, end " +
                        "FROM appointment " +
                        "JOIN user ON appointment.userId = user.userId " +
                        "JOIN customer ON appointment.customerId = customer.customerId " +
                        "WHERE appointment.userId = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting appointment table\n\n" + ex);
            }
            finally
            {
                conn.Close();
            }

            setLocalTime(dt);

            return dt;
        }

        //Added this lambda to reduce total lines of code. This lambda replaced 3 unique methods. See the commented funcions below which were replaced methods (appointmentTable, appointmentTableWeekly, appointmentTableMonthly). This lambda reduced total code lines by 48.
        public static Func<string, DataTable> getAppointmentTable = (query) =>
        {
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting appointment table\n\n" + ex);
            }
            finally
            {
                conn.Close();
            }

            setLocalTime(dt);

            return dt;
        };
        public static string allAppointmentsQuery =
            "SELECT appointmentId AS ID, customerName AS name, userName AS consultant, type, start, end " +
            "FROM appointment " +
            "JOIN user ON appointment.userId = user.userId " +
            "JOIN customer ON appointment.customerId = customer.customerId";
        public static string weeklyAppointmentsQuery =
            "SELECT appointmentId AS ID, customerName AS name, userName AS consultant, type, start, end " +
            "FROM appointment " +
            "JOIN user ON appointment.userId = user.userId " +
            "JOIN customer ON appointment.customerId = customer.customerId " +
            "WHERE  YEARWEEK(`start`, 1) = YEARWEEK(CURDATE(), 1);";
        public static string monthlyAppointmentsQuery =
            "SELECT appointmentId AS ID, customerName AS name, userName AS consultant, type, start, end " +
            "FROM appointment " +
            "JOIN user ON appointment.userId = user.userId " +
            "JOIN customer ON appointment.customerId = customer.customerId " +
            "WHERE MONTH(start) = MONTH(CURRENT_DATE()) AND YEAR(start) = YEAR(CURRENT_DATE())";


        //public static DataTable appointmentTable()
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        conn.Open();
        //        string query =
        //                "SELECT appointmentId AS ID, customerName AS name, userName AS consultant, type, start, end " +
        //                "FROM appointment " +
        //                "JOIN user ON appointment.userId = user.userId " +
        //                "JOIN customer ON appointment.customerId = customer.customerId";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
        //        adap.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error getting appointment table\n\n" + ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    setLocalTime(dt);

        //    return dt;
        //}
        //public static DataTable appointmentTableWeekly()
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        conn.Open();
        //        string query =
        //                "SELECT appointmentId AS ID, customerName AS name, userName AS consultant, type, start, end " +
        //                "FROM appointment " +
        //                "JOIN user ON appointment.userId = user.userId " +
        //                "JOIN customer ON appointment.customerId = customer.customerId " +
        //                "WHERE  YEARWEEK(`start`, 1) = YEARWEEK(CURDATE(), 1);";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
        //        adap.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error getting weekly appointment table\n\n" + ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    setLocalTime(dt);

        //    return dt;
        //}
        //public static DataTable appointmentTableMonthly()
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        conn.Open();
        //        string query =
        //                "SELECT appointmentId AS ID, customerName AS name, userName AS consultant, type, start, end " +
        //                "FROM appointment " +
        //                "JOIN user ON appointment.userId = user.userId " +
        //                "JOIN customer ON appointment.customerId = customer.customerId " +
        //                "WHERE MONTH(start) = MONTH(CURRENT_DATE()) AND YEAR(start) = YEAR(CURRENT_DATE())";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
        //        adap.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error getting monthly appointment table\n\n" + ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    setLocalTime(dt);

        //    return dt;
        //}
        public static DataTable alertCheck(int userId)
        {
            DataTable dt = new DataTable();
            DateTime now1 = DateTime.Now.ToUniversalTime();
            DateTime now2 = now1.AddMinutes(15);

            try
            {
                conn.Open();
                string query = "SELECT * FROM appointment WHERE start > @now1 AND start < @now2 AND userId = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@now1", now1);
                cmd.Parameters.AddWithValue("@now2", now2);
                cmd.Parameters.AddWithValue("@userId", userId);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking for alerts\n\n" + ex);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public static DataTable userTable()
        {
            DataTable dt = new DataTable();

            conn.Open();
            string query = "SELECT userId, userName FROM user";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);

            conn.Close();

            return dt;
        }
        public static CustomerDetails getCustomer(int customerId)
        {
            DataTable dt = new DataTable();
            CustomerDetails customer = new CustomerDetails();
            try
            {

                conn.Open();
                string query =
                        "SELECT customerId AS ID, customerName AS name, address, phone, city, country FROM customer " +
                        "JOIN address ON customer.addressId = address.AddressId " +
                        "JOIN city ON address.cityId = city.cityId " +
                        "JOIN country ON city.countryId = country.countryId " +
                        "WHERE customer.customerId = @customerId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);

                customer.Name = (string)dt.Rows[0]["name"];
                customer.Address = (string)dt.Rows[0]["address"];
                customer.Phone = (string)dt.Rows[0]["phone"];
                customer.City = (string)dt.Rows[0]["city"];
                customer.Country = (string)dt.Rows[0]["country"];


            }
            catch (Exception)
            {
                Console.WriteLine("Error getting customer");
            }
            finally
            {
                conn.Close();
            }

            return customer;

        }

        public static bool checkDuplicateCustomer(CustomerDetails customer)
        {
            bool containsDuplicate = false;
            try
            {
                DataTable dt = new DataTable();
                conn.Open();
                string query =
                        "SELECT customerName AS name, address, phone, city, country FROM customer " +
                        "JOIN address ON customer.addressId = address.AddressId " +
                        "JOIN city ON address.cityId = city.cityId " +
                        "JOIN country ON city.countryId = country.countryId " +
                        "WHERE customerName = @name AND address = @address AND phone = @phone AND city = @city AND country = @country";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@address", customer.Address);
                cmd.Parameters.AddWithValue("@phone", customer.Phone);
                cmd.Parameters.AddWithValue("@city", customer.City);
                cmd.Parameters.AddWithValue("@country", customer.Country);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    containsDuplicate = true;
                }


            }
            catch (Exception)
            {
                Console.WriteLine("Error comparing customers");
            }
            finally
            {
                conn.Close();
            }

            return containsDuplicate;
        }

        public static DataTable getAppointment(int appId)
        {
            DataTable dt = new DataTable();

            conn.Open();
            string query =
                "SELECT type, start, customer.customerName AS customer, user.userName as user " +
                "FROM appointment " +
                "JOIN customer ON customer.customerId = appointment.customerId " +
                "JOIN user ON user.userId = appointment.userId " +
                "WHERE appointmentId = @appId";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@appId", appId);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);

            conn.Close();

            return dt;
        }
        public static void addCustomer(string name, string address, string phone, string city, string country)
        {
            int countryId;
            int cityId;
            int addressId;

            conn.Open();
            countryId = addCountry(country);
            cityId = addCity(city, countryId);
            addressId = addAddress(address, phone, cityId);

            Customer customer = new Customer(name, addressId);

            string query =
                "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES(@name, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);" +
                "SELECT last_insert_id();";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", customer.Name);
            cmd.Parameters.AddWithValue("@addressId", customer.AddressId);
            cmd.Parameters.AddWithValue("@active", customer.Active);
            cmd.Parameters.AddWithValue("@createDate", customer.CreateDate);
            cmd.Parameters.AddWithValue("@createdBy", customer.CreateBy);
            cmd.Parameters.AddWithValue("@lastUpdate", customer.LastUpdate);
            cmd.Parameters.AddWithValue("@lastUpdateBy", customer.LastUpdateBy);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public static int addCountry(string name)
        {
            Country country = new Country(name);
            int addressId;

            string query =
                "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);" +
                "SELECT last_insert_id();";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@country", country.Name);
            cmd.Parameters.AddWithValue("@createDate", country.CreateDate);
            cmd.Parameters.AddWithValue("@createdBy", country.CreatedBy);
            cmd.Parameters.AddWithValue("@lastUpdate", country.LastUpdate);
            cmd.Parameters.AddWithValue("@lastUpdateBy", country.LastUpdateBy);
            Object obj = cmd.ExecuteScalar();
            addressId = Convert.ToInt32(obj.ToString());

            return addressId;
        }
        public static int addCity(string name, int countryId)
        {
            City city = new City(name, countryId);
            int cityId;

            string query =
                "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES(@city, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);" +
                "SELECT last_insert_id();";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@city", city.Name);
            cmd.Parameters.AddWithValue("@countryId", countryId);
            cmd.Parameters.AddWithValue("@createDate", city.CreateDate);
            cmd.Parameters.AddWithValue("@createdBy", city.CreatedBy);
            cmd.Parameters.AddWithValue("@lastUpdate", city.LastUpdate);
            cmd.Parameters.AddWithValue("@lastUpdateBy", city.LastUpdateBy);
            Object obj = cmd.ExecuteScalar();
            cityId = Convert.ToInt32(obj.ToString());

            return cityId;
        }
        public static int addAddress(string address_in, string phone, int cityId)
        {
            Address address = new Address(address_in, phone, cityId);
            int addressId;

            string query =
                "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES(@address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);" +
                "SELECT last_insert_id();";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@address", address.Address1);
            cmd.Parameters.AddWithValue("@address2", address.Address2);
            cmd.Parameters.AddWithValue("@cityId", address.CityId);
            cmd.Parameters.AddWithValue("@postalCode", address.PostalCode);
            cmd.Parameters.AddWithValue("@phone", address.Phone);
            cmd.Parameters.AddWithValue("@createDate", address.CreateDate);
            cmd.Parameters.AddWithValue("@createdBy", address.CreateBy);
            cmd.Parameters.AddWithValue("@lastUpdate", address.LastUpdate);
            cmd.Parameters.AddWithValue("@lastUpdateBy", address.LastUpdateBy);
            Object obj = cmd.ExecuteScalar();
            addressId = Convert.ToInt32(obj.ToString());

            return addressId;
        }
        public static void editCustomer(int customerId, string name, string address, string phone, string city, string country)
        {

            conn.Open();

            int addressId = getIdFromId(customerId, "customerId", addressIdQuery);
            int cityId = getIdFromId(addressId, "addressId", cityIdQuery);
            int countryId = getIdFromId(cityId, "cityId", countryIdQuery);

            string query =
                "UPDATE customer SET customerName = @name WHERE customerId = @customerId;" +
                "UPDATE address SET address = @address, phone = @phone WHERE addressId = @addressId;" +
                "UPDATE city SET city = @city WHERE cityId = @cityId;" +
                "UPDATE country SET country = @country WHERE countryId = @countryId";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@addressId", addressId);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@cityId", cityId);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@countryId", countryId);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public static void deleteCustomer(int customerId)
        {
            conn.Open();

            int addressId = getIdFromId(customerId, "customerId", addressIdQuery);
            int cityId = getIdFromId(addressId, "addressId", cityIdQuery);
            int countryId = getIdFromId(cityId, "cityId", countryIdQuery);

            string query =
                "DELETE FROM customer WHERE customerId = @customerId;" +
                "DELETE FROM address WHERE addressId = @addressId;" +
                "DELETE FROM city WHERE cityId = @cityId;" +
                "DELETE FROM country WHERE countryId = @countryId;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@addressId", addressId);
            cmd.Parameters.AddWithValue("@cityId", cityId);
            cmd.Parameters.AddWithValue("@countryId", countryId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Added this lambda to reduce total lines of code. This lambda replaced 3 unique methods. See the commented funcions below which were replaced methods (getAddressId, getCityId, getCountryId). This lambda reduced total code lines by 23.
        public static Func<int, string, string, int> getIdFromId = (id, idType, query) =>
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue($"@{idType}", id);
            Object obj = cmd.ExecuteScalar();
            return Convert.ToInt32(obj.ToString());
        };
        private static string addressIdQuery =
                "SELECT address.addressId FROM address " +
                "JOIN customer ON customer.addressId = address.addressId " +
                "WHERE customer.customerId = @customerId;";
        private static string cityIdQuery =
                "SELECT city.cityId FROM city " +
                "JOIN address ON address.cityId = city.cityId " +
                "WHERE address.addressId = @addressId;";
        private static string countryIdQuery =
                "SELECT country.countryId FROM country " +
                "JOIN city ON country.countryId = city.countryId " +
                "WHERE city.cityId = @cityId;";

        //private static int getAddressId(int customerId)
        //{
        //    int addressId;
        //    string query =
        //        "SELECT address.addressId FROM address " +
        //        "JOIN customer ON customer.addressId = address.addressId " +
        //        "WHERE customer.customerId = @customerId;";
        //    MySqlCommand cmd = new MySqlCommand(query, conn);
        //    cmd.Parameters.AddWithValue("@customerId", customerId);
        //    Object obj = cmd.ExecuteScalar();
        //    addressId = Convert.ToInt32(obj.ToString());

        //    return addressId;
        //}
        //private static int getCityId(int addressId)
        //{
        //    int cityId;
        //    string query =
        //        "SELECT city.cityId FROM city " +
        //        "JOIN address ON address.cityId = city.cityId " +
        //        "WHERE address.addressId = @addressId;";
        //    MySqlCommand cmd = new MySqlCommand(query, conn);
        //    cmd.Parameters.AddWithValue("@addressId", addressId);
        //    Object obj = cmd.ExecuteScalar();
        //    cityId = Convert.ToInt32(obj.ToString());

        //    return cityId;
        //}
        //private static int getCountryId(int cityId)
        //{
        //    int countryId;
        //    string query =
        //        "SELECT country.countryId FROM country " +
        //        "JOIN city ON country.countryId = city.countryId " +
        //        "WHERE city.cityId = @cityId;";
        //    MySqlCommand cmd = new MySqlCommand(query, conn);
        //    cmd.Parameters.AddWithValue("@cityId", cityId);
        //    Object obj = cmd.ExecuteScalar();
        //    countryId = Convert.ToInt32(obj.ToString());

        //    return countryId;
        //}

        //Added this lambda to reduce total lines of code. This lambda replaced 2 unique methods. See the commented funcions below which were replaced methods (getCustomerId, getUserId). This lambda reduced total code lines by 13.
        public static Func<string, string, string, int> getIdFromName = (name, nameType, query) =>
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue($"@{nameType}", name);
            Object obj = cmd.ExecuteScalar();
            return Convert.ToInt32(obj.ToString());
        };
        public static string customerIdQuery =
                "SELECT customerId FROM customer " +
                "WHERE customerName = @customer;";
        public static string userIdQuery =
                "SELECT userId FROM user " +
                "WHERE userName = @user;";

        //public static int getCustomerId(string name)
        //{
        //    int customerId;
        //    string query =
        //        "SELECT customerId FROM customer " +
        //        "WHERE customerName = @customer;";
        //    MySqlCommand cmd = new MySqlCommand(query, conn);
        //    cmd.Parameters.AddWithValue("@customer", name);
        //    Object obj = cmd.ExecuteScalar();
        //    customerId = Convert.ToInt32(obj.ToString());

        //    return customerId;
        //}
        //public static int getUserId(string name)
        //{
        //    int userId;
        //    string query =
        //        "SELECT userId FROM user " +
        //        "WHERE userName = @user;";
        //    MySqlCommand cmd = new MySqlCommand(query, conn);
        //    cmd.Parameters.AddWithValue("@user", name);
        //    Object obj = cmd.ExecuteScalar();
        //    userId = Convert.ToInt32(obj.ToString());

        //    return userId;
        //}
        public static void deleteAppointment(int appId)
        {
            conn.Open();

            string query =
                "DELETE FROM appointment WHERE appointmentId = @appointmentId;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@appointmentId", appId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void addAppointment(Appointment appointment)
        {
            conn.Open();

            string query =
                "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES(@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);" +
                "SELECT last_insert_id();";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@customerId", appointment.CustomerId);
            cmd.Parameters.AddWithValue("@userId", appointment.UserId);
            cmd.Parameters.AddWithValue("@title", appointment.Title);
            cmd.Parameters.AddWithValue("@description", appointment.Description);
            cmd.Parameters.AddWithValue("@location", appointment.Location);
            cmd.Parameters.AddWithValue("@contact", appointment.Contact);
            cmd.Parameters.AddWithValue("@type", appointment.Type);
            cmd.Parameters.AddWithValue("@url", appointment.Url);
            cmd.Parameters.AddWithValue("@start", appointment.TimeStart);
            cmd.Parameters.AddWithValue("@end", appointment.TimeEnd);
            cmd.Parameters.AddWithValue("@createDate", appointment.CreateDate);
            cmd.Parameters.AddWithValue("@createdBy", appointment.CreatedBy);
            cmd.Parameters.AddWithValue("@lastUpdate", appointment.LastUpdate);
            cmd.Parameters.AddWithValue("@lastUpdateBy", appointment.LastUpdateBy);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void editAppointment(Appointment appointment, int appointmentId)
        {
            conn.Open();

            string query =
                "UPDATE appointment SET " +
                "type = @type, " +
                "customerId = @customerId, " +
                "userId = @userId, " +
                "start = @start, " +
                "end = @end " +
                "WHERE appointmentId = @appointmentId;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@customerId", appointment.CustomerId);
            cmd.Parameters.AddWithValue("@userId", appointment.UserId);
            cmd.Parameters.AddWithValue("@type", appointment.Type);
            cmd.Parameters.AddWithValue("@start", appointment.TimeStart);
            cmd.Parameters.AddWithValue("@end", appointment.TimeEnd);
            cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private static void setLocalTime(DataTable dt)
        {
            int rowCount = dt.Rows.Count;

            for (int i = 0; i < rowCount; i++)
            {
                DateTime start = (DateTime)dt.Rows[i]["start"];
                dt.Rows[i]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)dt.Rows[i]["end"];
                dt.Rows[i]["end"] = end.ToLocalTime();
            }

        }

    }
}
