using BestFlightSearch.Solution.Domain.Entities;
using BestFlightSearch.Solution.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Domain
{
    [Serializable]
    public class Flight : Entity
    {
        public Flight(string flightnumber, string flightdate, string timeprev, string timeconfirmed,
                      string flighttps, string flightgate, string obs, string companyname, string companyshortname,
                      string equipment, string airportname, string iatacode, string airportcode, string city, string statecode, 
                      string country, string flightkind, string flightstatus, string flightstops)

        {
            this.FlightNumber = flightnumber;

            this.FlightDate = flightdate;

            this.TimePrev = timeprev;

            this.TimeConfirmed = timeconfirmed;

            this.FlightTPS = flighttps;

            this.FlightGate = flightgate;

            this.Obs = obs;

            this.CompanyName = companyname;

            this.CompanyShortName = companyshortname;

            this.Equipment = equipment;

            this.AirportName = airportname;

            this.IATACode = iatacode;

            this.AirportCode = airportcode;

            this.City = city;

            this.StateCode = statecode;

            this.Country = country;

            this.FlightKind = flightkind;

            this.FlightStatus = flightstatus;

            this.FlightStops = flightstops;

            Validate(this, new FlightValidator());
        }

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

        /// <summary>
        /// IATA
        /// </summary>
        public string IATACode { get; set; }

        /// <summary>
        /// ICAO
        /// </summary>
        public string AirportCode { get; set; }

        public string City { get; set; }

        public string StateCode { get; set; }

        public string Country { get; set; }

        public string FlightKind { get; set; }

        public string FlightStatus { get; set; }

        public string FlightStops { get; set; }
    }
}
