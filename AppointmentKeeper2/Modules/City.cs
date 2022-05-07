using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentKeeper2.Modules
{
    class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public City(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;

            CreateDate = "2019-01-01 00:00:00";
            CreatedBy = "not used";
            LastUpdate = "2019-01-01 00:00:00";
            LastUpdateBy = "not used";
        }

    }
}
