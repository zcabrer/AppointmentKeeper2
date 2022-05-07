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
    class Data
    {
        static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "appkeeperdb.mysql.database.azure.com",
            Database = "client_schedule",
            UserID = "appkeeperadmin@appkeeperdb",
            Password = "WGUcapstone890!!",
            SslMode = MySqlSslMode.Required,
        };
        public static MySqlConnection conn = new MySqlConnection(builder.ConnectionString);

        public virtual DataTable customerTable()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string query =
                        "SELECT customerId AS ID, customerName AS name, phone, address, city, country FROM customer " +
                        "JOIN address ON customer.addressId = address.AddressId " +
                        "JOIN city ON address.cityId = city.cityId " +
                        "JOIN country ON city.countryId = country.countryId " +
                        "WHERE INSTR(customerName ,@name) > 0";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
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
    }
}
