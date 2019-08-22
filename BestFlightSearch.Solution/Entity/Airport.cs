using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Entity
{
    public class Airport
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string IATACode { get; set; }
        public string AirportCode { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public bool HasSIV { get; set; }
    }
}
