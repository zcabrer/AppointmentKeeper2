using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppointmentKeeper2
{
    class InputValidation
    {

        public static bool validateCustomerInput(string name, string address, string phone, string city, string country)
        {
            bool isValid = true;

            string[] input = { name, address, phone, city, country };

            foreach (string item in input)
            {
                if (System.String.IsNullOrEmpty(item))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        public static bool validatePhone(string phone)
        {
            bool isValid = true;

            string regex = "\\d\\d\\d-\\d\\d\\d-\\d\\d\\d\\d";


            if (Regex.IsMatch(phone, regex))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }



        public static bool validateAppointment(string type, string customer, string consultant)
        {
            bool isValid = true;

            string[] input = { type, customer, consultant };

            foreach (string item in input)
            {
                if (System.String.IsNullOrEmpty(item))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        public static bool validateBusinessHours(DateTime start, DateTime end)
        {
            bool isValid = true;

            TimeSpan startBuseinss = new TimeSpan(12, 0, 0);
            TimeSpan endBusiness = new TimeSpan(21, 0, 0);
            TimeSpan startApp = start.TimeOfDay;
            TimeSpan endApp = end.TimeOfDay;

            //check business hours: 7 days per week. Between 8:00 - 17:00 EST (12:00 - 21:00 UTC)
            if
                (
                startApp < startBuseinss ||
                startApp > endBusiness ||
                endApp < startBuseinss ||
                endApp > endBusiness
                )
            { isValid = false; }

            return isValid;
        }
        public static bool validateAppointmentConflict(DateTime start, DateTime end, string user, bool isNewAppointment, int appointmentId = 0)
        {
            bool isConflict = false;
            string query;

            try
            {
                Datatools.conn.Open();

                int result = 0;
                int userId = Datatools.getIdFromName(user, "user", Datatools.userIdQuery);

                if (isNewAppointment)
                {
                    query = "SELECT EXISTS(SELECT * FROM appointment WHERE start < @end AND end > @start AND userId = @user);";
                }
                else
                {
                    query = "SELECT EXISTS(SELECT * FROM appointment WHERE start < @end AND end > @start AND userId = @user AND appointmentId != @appointmentId);";
                }
                MySqlCommand cmd = new MySqlCommand(query, Datatools.conn);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                cmd.Parameters.AddWithValue("@user", userId);
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                Object obj = cmd.ExecuteScalar();
                result = Convert.ToInt32(obj.ToString());
                if (result > 0)
                {
                    isConflict = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while checking for appointment conflict" + ex);
            }
            finally
            {
                Datatools.conn.Close();
            }
            return isConflict;
        }

    }
}
