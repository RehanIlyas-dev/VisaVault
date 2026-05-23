using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public Country(int CountryId, string CountryName, string CountryCode)
        {
            this.CountryId = CountryId;
            this.CountryName = CountryName;
            this.CountryCode = CountryCode;
        }
    }
   
    }
