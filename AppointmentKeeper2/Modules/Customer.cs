using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentKeeper2.Modules
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int Active { get; }
        public string CreateDate { get; }
        public string CreateBy { get; }
        public string LastUpdate { get; }
        public string LastUpdateBy { get; }

        public Customer(string cName, int addressId)
        {
            Name = cName;
            AddressId = addressId;

            Active = 1;
            CreateDate = "2019-01-01 00:00:00";
            CreateBy = "not used";
            LastUpdate = "2019-01-01 00:00:00";
            LastUpdateBy = "not used";
        }
    }
}