using BestFlightSearch.Solution.Domain;
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
    /// SkyScanner.IO class
    /// https://skyscanner.github.io/slate/?_ga=1.104705984.172843296.1446781555#api-documentation
    /// </summary>
    public class FlightSearchSkyScannerIO : IFlightSearch
    {
        protected RestClient client = null;
        protected IRestRequest request = null;
        public IRestResponse Response = null;
        public string _SkyScannerIO_Host { get; set; } = "partners.api.skyscanner.net";
        public string _SkyScannerIO_Key { get; set; } = "SIGN-UP-FOR-KEY";
        public string ErrorMessage { get; set; } = "";

        public void Dispose()
        {

        }

        public IRestResponse Execute(SkyScannerIOMethod method, string[] parameters)
        {
            try
            {
                switch (method)
                {
                    case SkyScannerIOMethod.Autenticatiom_Token:
                        {
                            this.client = new RestClient(this._SkyScannerIO_Host + "/apiservices/token/v2/gettoken?apiKey={ "+this._SkyScannerIO_Key+" }");
                            this.request = new RestRequest(Method.GET);
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
    }
