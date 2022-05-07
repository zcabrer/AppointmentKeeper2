using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentKeeper2.Modules
{
    class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public Address(string address, string phone, int cityId)
        {
            Address1 = address;
            Phone = phone;
            CityId = cityId;

            Address2 = "not used";
            PostalCode = "not used";
            CreateDate = "2019-01-01 00:00:00";
            CreateBy = "not used";
            LastUpdate = "2019-01-01 00:00:00";
            LastUpdateBy = "not used";
        }
    }
}
