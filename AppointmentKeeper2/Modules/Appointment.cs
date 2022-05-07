using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentKeeper2.Modules
{
    class Appointment
    {
        DateTime _timeStart;
        DateTime _timeEnd;
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DateTime TimeStart
        {
            get
            {
                return _timeStart;
            }
            set
            {
                string newStart = value.ToString("yyyy-MM-dd HH:mm");
                _timeStart = DateTime.Parse(newStart);
            }
        }

        public DateTime TimeEnd
        {
            get
            {
                return _timeEnd;
            }
            set
            {
                string newEnd = value.ToString("yyyy-MM-dd HH:mm");
                _timeEnd = DateTime.Parse(newEnd);
            }
        }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public Appointment(string customer, string user, string type, DateTime start, DateTime end)
        {
            try
            {
                Datatools.conn.Open();
                CustomerId = Datatools.getIdFromName(customer, "customer", Datatools.customerIdQuery);
                UserId = Datatools.getIdFromName(user, "user", Datatools.userIdQuery);
            }
            catch (Exception)
            {
                Console.WriteLine("Error while getting customer and user IDs to build Appointment");
            }
            finally
            {
                Datatools.conn.Close();
            }

            Type = type;
            TimeStart = start;
            TimeEnd = end;


            Title = "not used";
            Description = "not used";
            Location = "not used";
            Contact = "not used";
            Url = "not used";
            CreatedBy = "not used";
            LastUpdateBy = "not used";
            CreateDate = "2019-01-01 00:00:00";
            LastUpdate = "2019-01-01 00:00:00";
        }
    }
}
