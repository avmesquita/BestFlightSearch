using BestFlightSearch.Solution.Interface;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution
{
    /// <summary>
    /// https://developer.flightstats.com/api-docs/
    /// </summary>
    public class FlightSearchFlightStatus : IFlightSearch
    {
        protected RestClient client = null;
        protected IRestRequest request = null;

        public IRestResponse Response = null;

        public string ErrorMessage { get; set; } = "";

        public string _FlightStatusAPI_Host { get; set; } = "https://api.flightstats.com";

        public string _FlightStatusAPI_Key { get; set; } = "SIGN-UP-FOR-KEY";

        // TO CACHED QUERY
        public List<KeyValuePair<string, string>> FlightStatusResponseStatusCode;
        public List<KeyValuePair<string, string>> FlightStatusResponseFlightType;

        /// <summary>
        /// https://developer.flightstats.com/api-docs/flightstatus/v2/flightstatusresponse
        /// </summary>
        public void LoadResponseStatusCode()
        {
            FlightStatusResponseStatusCode = new List<KeyValuePair<string, string>>();
            FlightStatusResponseStatusCode.Clear();
            FlightStatusResponseStatusCode.Add(new KeyValuePair<string, string>("A","ACTIVE"));
            FlightStatusResponseStatusCode.Add(new KeyValuePair<string, string>("C", "CANCELED"));
            FlightStatusResponseStatusCode.Add(new KeyValuePair<string, string>("D", "DIVERTED"));
            FlightStatusResponseStatusCode.Add(new KeyValuePair<string, string>("DN", "DATA SOURCE NEEDED"));
            FlightStatusResponseStatusCode.Add(new KeyValuePair<string, string>("L", "LANDED"));
            FlightStatusResponseStatusCode.Add(new KeyValuePair<string, string>("NO", "NOT OPERACIONAL"));
            FlightStatusResponseStatusCode.Add(new KeyValuePair<string, string>("R", "REDIRECTED"));
            FlightStatusResponseStatusCode.Add(new KeyValuePair<string, string>("S", "SCHEDULED"));
            FlightStatusResponseStatusCode.Add(new KeyValuePair<string, string>("U", "UNKNOWN"));
        }

        /// <summary>
        /// https://developer.flightstats.com/api-docs/flightstatus/v2/flightstatusresponse
        /// </summary>
        public void LoadResponseFlightType()
        {
            FlightStatusResponseFlightType = new List<KeyValuePair<string, string>>();
            FlightStatusResponseFlightType.Clear();

            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("J", "Scheduled Passenger(Normal Service)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("S", "Scheduled Passenger(Shuttle Service)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("U", "Scheduled Passenger(ServiceVehicle)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("F", "Scheduled Cargo / Mail(Loose loaded cargo and / or preloaded devices)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("V", "ScheduledCargo/ Mail(Surface Vehicle)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("M", "Scheduled Cargo / Mail(MailOnly)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("Q", "Scheduled Passenger / Cargo inCabin".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("G", "  Non - scheduled Passenger(NormalService)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("B", "Non-scheduled Passenger(ShuttleService)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("A", "Non-scheduled Cargo / Mail".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("C", "Charter(Passenger Only)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("O", "Charter(Special handling-Migrants / Immigrants)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("H", "Charter(Cargo and/ or Mail)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("L", "Charter(Passenger and Cargo and/ or Mail)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("P", "Non-revenue".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("T", "Technical Test".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("K", "Training".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("D", "General Aviation".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("E", "Special(FAA/ Government)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("W", "Military".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("R", "Additional Flights - Passenger / Cargo".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("Y", "IATA Special Internal(Y)".ToUpper()));
            FlightStatusResponseFlightType.Add(new KeyValuePair<string, string>("Z", "IATA Special Internal(Z)".ToUpper()));
        }


        public FlightSearchFlightStatus()
        {

        }

        public FlightSearchFlightStatus(string host, string apikey)
        {
            this._FlightStatusAPI_Host = host;
            this._FlightStatusAPI_Key = apikey;
        }

        private void Initialize()
        {
            if (string.IsNullOrEmpty(this._FlightStatusAPI_Host) || string.IsNullOrEmpty(this._FlightStatusAPI_Key))
            {
                throw new Exception("FlightStatus Host and Keys are must required.");
            }
        }





        public void Dispose()
        {
            
        }
    }
}
