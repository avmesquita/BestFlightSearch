using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFlightSearch.Solution.Domain;
using BestFlightSearch.Solution.Domain.Entities;
using BestFlightSearch.Solution.Domain.Validators;

namespace BestFlightSearch.Solution.Domain
{
    [Serializable]
    public class Airport : Entity
    {
        public Airport(string name, string shortname,string iatacode, string airportcode,string city, string state, bool hassiv)
        {
            this.Name = name;
            this.ShortName = shortname;
            this.IATACode = iatacode;
            this.AirportCode = airportcode;
            this.City = city;
            this.StateCode = state;
            this.HasSIV = hassiv;

            Validate(this, new AirportValidator());
        }
        /// <summary>
        /// Airport Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short Name
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// IATA Code
        /// </summary>
        public string IATACode { get; set; }

        /// <summary>
        /// ICAO Code
        /// </summary>
        public string AirportCode { get; set; }

        /// <summary>
        /// Airport City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Airport City State
        /// </summary>
        public string StateCode { get; set; }

        /// <summary>
        /// Has SIV
        /// </summary>
        public bool HasSIV { get; set; }
    }
}
