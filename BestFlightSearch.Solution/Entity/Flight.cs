﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Entity
{
    [Serializable]
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string FlightDate { get; set; }
        public string TimePrev { get; set; }
        public string TimeConfirmed { get; set; }
        public string FlightTPS { get; set; }
        public string FlightGate { get; set; }
        public string Obs { get; set; }
        public string CompanyName { get; set; }
        public string CompanyShortName { get; set; }
        public string Equipment { get; set; }
        public string AirportName { get; set; }
        public string IATACode { get; set; }
        public string AirportCode { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string Country { get; set; }
        public string FlightKind { get; set; }
        public string FlightStatus { get; set; }
        public string FlightStops { get; set; }
    }
}
