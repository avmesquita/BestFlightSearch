using BestFlightSearch.Solution.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Interface
{
    /// <summary>
    /// /// Flight Search solution interface
    /// </summary>
    public interface IFlightSearch : IDisposable
    {
        /// <summary>
        /// Query Airports
        /// </summary>
        /// <param name="Language"></param>
        /// <returns></returns>
        List<Airport> QueryAirports(string Language = "bra");


        /// <summary>
        /// Query Flight Companies
        /// </summary>
        /// <param name="AirportCode"></param>
        /// <param name="Language"></param>
        /// <returns></returns>
        List<FlightCompany> QueryFlightCompanies(string AirportCode, string Language = "bra");


        /// <summary>
        /// Query By Flight Number
        /// </summary>
        /// <param name="AirportCode"></param>
        /// <param name="FlightNumber"></param>
        /// <param name="Language"></param>
        /// <param name="Departure"></param>
        /// <param name="ShowEndFlights"></param>
        /// <param name="RecordsPerPage"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        List<Flight> QueryFlightPerNumber(string AirportCode, string FlightNumber, string Language = "bra", bool Departure = true, bool ShowEndFlights = false, int RecordsPerPage = 10, int PageNumber = 1);

        /// <summary>
        /// Query By Flight Company
        /// </summary>
        /// <param name="AirportCode"></param>
        /// <param name="Language"></param>
        /// <param name="Departure"></param>
        /// <param name="FlightCompany"></param>
        /// <param name="ShowEndFlights"></param>
        /// <param name="RecordsPerPage"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        List<Flight> QueryFlightPerFlightCompany(string AirportCode, string FlightCompany, string Language = "bra", bool Departure = true, bool ShowEndFlights = false, int RecordsPerPage = 10, int PageNumber = 1);

        /// <summary>
        /// Query By Flight Direction
        /// </summary>
        /// <param name="AirportCode"></param>
        /// <param name="Language"></param>
        /// <param name="Departure"></param>
        /// <param name="ShowEndFlights"></param>
        /// <param name="RecordsPerPage"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        List<Flight> QueryFlightPerDirection(string AirportCode, string Language = "bra", bool Departure = true, bool ShowEndFlights = false, int RecordsPerPage = 10, int PageNumber = 1);        
    }
}
