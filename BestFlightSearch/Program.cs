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
            try
            {
                // INSTANCE INFRAERO SOLUTION
                var fs = new FlightSearchInfraero();

                // GET ALL AIRPORTS
                var airports = fs.QueryAirports();
                if (airports.Count > 0)
                {
                    Console.WriteLine("AIRPORTS");
                    foreach (var item in airports)
                    {
                        Console.WriteLine(string.Concat(item.AirportCode, " - ", item.Name, " - ", item.IATACode, " - ", item.StateCode));
                    }
                }

                // GET ALL COMPANIES
                var companies = fs.QueryFlightCompanies("SBGL");
                if (companies.Count > 0)
                {
                    Console.WriteLine("\nCOMPANIES");
                    foreach (var item in companies)
                    {
                        Console.WriteLine(string.Concat(item.ShortName, " - ", item.Name));
                    }
                }

                // GET ALL FLIGHTS BY NUMBER
                var flightsByNumber = fs.QueryFlightPerNumber("SBRJ", "");
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
                        item.TimeConfirmed);

                        Console.WriteLine(outText);
                    }
                }

                // GET ALL FLIGHTS BY AIRPORT AND COMPANY
                var flighstByCompany = fs.QueryFlightPerFlightCompany("SBRJ", "TAM");
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
                        item.TimeConfirmed);

                        Console.WriteLine(outText);
                    }
                }

                // GET ALL FLIGHTS TO AIRPORT DIRECTION
                var flightsByDirection = fs.QueryFlightPerDirection("SBRJ");
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
                        item.TimeConfirmed);

                        Console.WriteLine(outText);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            Console.ReadLine();
        }
    }
}
