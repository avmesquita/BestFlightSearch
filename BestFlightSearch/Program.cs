using BestFlightSearch.Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var fs = new FlightSearchInfraero();

            var airports = fs.QueryAirports();

            var companies = fs.QueryFlightCompanies("SBGL");


        }
    }
}
