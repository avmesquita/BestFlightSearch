using BestFlightSearch.Solution.Entity;
using BestFlightSearch.Solution.Enum;
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
    /// RapidApi SkyScanner API
    /// https://rapidapi.com/skyscanner/api/skyscanner-flight-search?endpoint=5b074035e4b09d99505e1e3e    
    /// </summary>
    public class FlightSearchRapidApiSkyScanner : IFlightSearch
    {
        protected RestClient client = null;
        protected IRestRequest request = null;

        public IRestResponse Response = null;

        public string ErrorMessage { get; set; } = "";

        public string _XRapidAPI_Host { get; set; } = "skyscanner-skyscanner-flight-search-v1.p.rapidapi.com";

        public string _XRapidAPI_Key { get; set; } = "SIGN-UP-FOR-KEY";

        public FlightSearchRapidApiSkyScanner()
        {

        }

        public FlightSearchRapidApiSkyScanner(string host, string apikey)
        {
            this._XRapidAPI_Host = host;
            this._XRapidAPI_Key = apikey;
        }

        private void Initialize()
        {
            if (string.IsNullOrEmpty(this._XRapidAPI_Host) || string.IsNullOrEmpty(this._XRapidAPI_Key))
            {
                throw new Exception("XRapidAPI Host and Keys are must required.");
            }
        }

        public IRestResponse Execute(SkyScannerRapidApiMethod method, string[] parameters)
        {
            try
            {
                Initialize();

                switch (method)
                {
                    case SkyScannerRapidApiMethod.LiveFlightSearch_CreateSession:
                        {
                            this.client = new RestClient(this._XRapidAPI_Host + "/apiservices/pricing/v1.0");
                            this.request = new RestRequest(Method.POST);
                            this.request.AddHeader("x-rapidapi-host", this._XRapidAPI_Host);
                            this.request.AddHeader("x-rapidapi-key", this._XRapidAPI_Key);
                            this.request.AddHeader("content-type", "application/x-www-form-urlencoded");
                            this.request.AddParameter("application/x-www-form-urlencoded", "inboundDate=&cabinClass=&children=&infants=&country=&currency=&locale=&originPlace=&destinationPlace=&outboundDate=&adults=", ParameterType.RequestBody);
                            this.Response = client.Execute(request);
                            return this.Response;
                        }
                    case SkyScannerRapidApiMethod.LiveFlightSearch_PollSessionResults:
                        {
                            this.client = new RestClient(this._XRapidAPI_Host + "/apiservices/pricing/uk2/v1.0/%7B" + parameters[0].ToString() + "%7D?pageIndex=" + parameters[1] + "&pageSize=" + parameters[2]);
                            this.request = new RestRequest(Method.GET);
                            this.request.AddHeader("x-rapidapi-host", this._XRapidAPI_Host);
                            this.request.AddHeader("x-rapidapi-key", this._XRapidAPI_Key);
                            this.Response = client.Execute(request);
                            return this.Response;
                        }
                    case SkyScannerRapidApiMethod.Places_ListPlaces:
                        {
                            this.client = new RestClient(this._XRapidAPI_Host + "/apiservices/autosuggest/v1.0/" + parameters[0] + "/" + parameters[1] + "/" + parameters[2] + "/?query=" + parameters[3] + "");
                            this.request = new RestRequest(Method.GET);
                            this.request.AddHeader("x-rapidapi-host", this._XRapidAPI_Host);
                            this.request.AddHeader("x-rapidapi-key", this._XRapidAPI_Key);
                            this.Response = client.Execute(request);
                            return this.Response;
                        }
                    case SkyScannerRapidApiMethod.BrowseFlightPrices_BrowseQuotes:
                        {
                            this.client = new RestClient(this._XRapidAPI_Host + "/apiservices/browsequotes/v1.0/US/USD/en-US/SFO-sky/JFK-sky/2019-09-01?inboundpartialdate=2019-12-01");
                            this.request = new RestRequest(Method.GET);
                            this.request.AddHeader("x-rapidapi-host", this._XRapidAPI_Host);
                            this.request.AddHeader("x-rapidapi-key", this._XRapidAPI_Key);
                            this.Response = client.Execute(request);
                            return this.Response;
                        }
                    case SkyScannerRapidApiMethod.BrowseFlightPrices_BrowseRoutes:
                        {
                            this.client = new RestClient(this._XRapidAPI_Host + "/apiservices/browseroutes/v1.0/US/USD/en-US/SFO-sky/ORD-sky/2019-09-01?inboundpartialdate=2019-12-01");
                            this.request = new RestRequest(Method.GET);
                            this.request.AddHeader("x-rapidapi-host", this._XRapidAPI_Host);
                            this.request.AddHeader("x-rapidapi-key", this._XRapidAPI_Key);
                            this.Response = client.Execute(request);
                            return this.Response;
                        }
                    case SkyScannerRapidApiMethod.BrowseFlightPrices_BrowseDates:
                        {
                            this.client = new RestClient(this._XRapidAPI_Host + "/apiservices/browsedates/v1.0/US/USD/en-US/SFO-sky/LAX-sky/2019-09-01?inboundpartialdate=2019-12-01");
                            this.request = new RestRequest(Method.GET);
                            this.request.AddHeader("x-rapidapi-host", this._XRapidAPI_Host);
                            this.request.AddHeader("x-rapidapi-key", this._XRapidAPI_Key);
                            this.Response = client.Execute(request);
                            return this.Response;
                        }
                    case SkyScannerRapidApiMethod.BrowseFlightPrices_BrowseDatesInbound:
                        {
                            this.client = new RestClient(this._XRapidAPI_Host + "/apiservices/browsedates/v1.0/%7Bcountry%7D/%7Bcurrency%7D/%7Blocale%7D/%7Boriginplace%7D/%7Bdestinationplace%7D/%7Boutboundpartialdate%7D/%7Binboundpartialdate%7D");
                            this.request = new RestRequest(Method.GET);
                            this.request.AddHeader("x-rapidapi-host", this._XRapidAPI_Host);
                            this.request.AddHeader("x-rapidapi-key", this._XRapidAPI_Key);
                            this.Response = client.Execute(request);
                            return this.Response;
                        }
                    case SkyScannerRapidApiMethod.BrowseFlightPrices_BrowseQuotesInbound:
                        {
                            this.client = new RestClient(this._XRapidAPI_Host + "/apiservices/browsequotes/v1.0/%7Bcountry%7D/%7Bcurrency%7D/%7Blocale%7D/%7Boriginplace%7D/%7Bdestinationplace%7D/%7Boutboundpartialdate%7D/%7Binboundpartialdate%7D");
                            this.request = new RestRequest(Method.GET);
                            this.request.AddHeader("x-rapidapi-host", this._XRapidAPI_Host);
                            this.request.AddHeader("x-rapidapi-key", this._XRapidAPI_Key);
                            this.Response = client.Execute(request);
                            return this.Response;
                        }
                    case SkyScannerRapidApiMethod.BrowseFlightPrices_BrowseRoutesInbound:
                        {
                            this.client = new RestClient(this._XRapidAPI_Host + "/apiservices/browseroutes/v1.0/%7Bcountry%7D/%7Bcurrency%7D/%7Blocale%7D/%7Boriginplace%7D/%7Bdestinationplace%7D/%7Boutboundpartialdate%7D/%7Binboundpartialdate%7D");
                            this.request = new RestRequest(Method.GET);
                            this.request.AddHeader("x-rapidapi-host", this._XRapidAPI_Host);
                            this.request.AddHeader("x-rapidapi-key", this._XRapidAPI_Key);
                            this.Response = client.Execute(request);
                            return this.Response;
                        }
                    case SkyScannerRapidApiMethod.Localisation_ListMarkets:
                        {
                            this.client = new RestClient(this._XRapidAPI_Host + "/apiservices/reference/v1.0/countries/en-US");
                            this.request = new RestRequest(Method.GET);
                            this.request.AddHeader("x-rapidapi-host", this._XRapidAPI_Host);
                            this.request.AddHeader("x-rapidapi-key", this._XRapidAPI_Key);
                            this.Response = client.Execute(request);
                            return this.Response;
                        }
                    case SkyScannerRapidApiMethod.Localisation_ListCurrencies:
                        {
                            this.client = new RestClient(this._XRapidAPI_Host + "/apiservices/reference/v1.0/currencies");
                            this.request = new RestRequest(Method.GET);
                            this.request.AddHeader("x-rapidapi-host", this._XRapidAPI_Host);
                            this.request.AddHeader("x-rapidapi-key", this._XRapidAPI_Key);
                            this.Response = client.Execute(request);
                            return this.Response;
                        }
                    default:
                        {
                            this.client = null;
                            this.request = null;
                            this.Response = null;
                            this.ErrorMessage = "Cannot initialize";
                            return null;
                        }
                }
            }
            catch (Exception ex)
            {
                this.client = null;
                this.request = null;
                this.Response = null;
                this.ErrorMessage = ex.Message.ToString() ?? throw new Exception("Cannot initialize");
                return null;
            }
        }

        public void Dispose()
        {
            this.client = null;
            this.request = null;
            this.Response = null;
            this.ErrorMessage = string.Empty;            
        }
    }
}
