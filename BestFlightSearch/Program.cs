using BestFlightSearch.Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch
{
    /// <summary>
    /// TEST PROJECT
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Test();

            StudyCase();

            Console.ReadLine();
        }

        /// <summary>
        /// Studying...
        /// </summary>
        static void StudyCase()
        {
            try
            {
                // INSTANCE INFRAERO SOLUTION
                var fs = new FlightSearchInfraero();





            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Test for main methods
        /// </summary>
        static void Test()
        {
            try
            {
                // INSTANCE INFRAERO SOLUTION
                var fs = new FlightSearchInfraero();

                #region [ GET AIRPORTS LIST ]
                
                var airports = fs.QueryAirports();
                if (airports.Count > 0)
                {
                    Console.WriteLine("AIRPORTS\n");
                    Console.WriteLine("Airport Code | Name | IATA Code | State Code ");
                    foreach (var item in airports)
                    {
                        Console.WriteLine(string.Concat(item.AirportCode, " | ", item.Name, " | ", item.IATACode, " | ", item.StateCode));
                    }
                }                

                #endregion

                #region [ PROMPT ]

                // PROMPT AIRPORT CODE
                Console.Write("Insert 4-digit Airport Code [Default SBGL]: ");
                string _airportCode = Console.ReadLine();
                if (string.IsNullOrEmpty(_airportCode))
                    _airportCode = "SBGL";

                // PROMPT FLIGHT NUMBER
                Console.Write("Insert Flight Number [Default '']: ");
                string _flightNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(_flightNumber))
                    _flightNumber = string.Empty;

                // PROMPT COMPANY
                Console.Write("Insert Company Code [Default '']: ");
                string _flightCompany = Console.ReadLine();
                if (string.IsNullOrEmpty(_flightCompany))
                    _flightCompany = string.Empty;

                #endregion

                #region [ GET ALL COMPANIES FROM AIRPORT SELECTED ]

                var companies = fs.QueryFlightCompanies(_airportCode);
                if (companies.Count > 0)
                {
                    Console.WriteLine("\nCOMPANIES");
                    foreach (var item in companies)
                    {
                        Console.WriteLine(string.Concat(item.ShortName, " - ", item.Name));
                    }
                }

                #endregion

                #region [ GET ALL FLIGHTS BY NUMBER SELECTED ]

                var flightsByNumber = fs.QueryFlightPerNumber(_airportCode, _flightNumber);
                if (flightsByNumber.Count > 0)
                {
                    Console.WriteLine("\nFLIGHTS BY NUMBER");
                    foreach (var item in flightsByNumber)
                    {
                        string outText = string.Concat(
                        item.AirportName, " | ",
                        item.CompanyShortName, " | ",
                        item.Country, " | ",
                        item.FlightKind, " | ",
                        item.FlightGate, " | ",
                        item.FlightDate, " | ",
                        item.TimePrev, " | ",
                        item.TimeConfirmed, " | ",
                        item.FlightStops);

                        Console.WriteLine(outText);
                    }
                }

                #endregion

                #region [ GET ALL FLIGHTS BY AIRPORT AND/OR COMPANY SELECTED ]

                var flighstByCompany = fs.QueryFlightPerFlightCompany(_airportCode, _flightCompany);
                if (flighstByCompany.Count > 0)
                {
                    Console.WriteLine("\nFLIGHTS BY COMPANY");
                    foreach (var item in flighstByCompany)
                    {
                        string outText = string.Concat(
                        item.AirportName, " | ",
                        item.CompanyShortName, " | ",
                        item.Country, " | ",
                        item.FlightKind, " | ",
                        item.FlightGate, " | ",
                        item.FlightDate, " | ",
                        item.TimePrev, " | ",
                        item.TimeConfirmed, " | ", " | ",
                        item.FlightStops);

                        Console.WriteLine(outText);
                    }
                }

                #endregion

                #region [ GET ALL FLIGHTS TO SELECTED AIRPORT DIRECTION ]

                var flightsByDirection = fs.QueryFlightPerDirection(_airportCode);
                if (flightsByDirection.Count > 0)
                {
                    Console.WriteLine("\nFLIGHTS BY DIRECTION");
                    foreach (var item in flightsByDirection)
                    {
                        string outText = string.Concat(
                        item.AirportName, " | ",
                        item.CompanyShortName, " | ",
                        item.Country, " | ",
                        item.FlightKind, " | ",
                        item.FlightGate, " | ",
                        item.FlightDate, " | ",
                        item.TimePrev, " | ",
                        item.TimeConfirmed, " | ",
                        item.FlightStops);

                        Console.WriteLine(outText);
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
