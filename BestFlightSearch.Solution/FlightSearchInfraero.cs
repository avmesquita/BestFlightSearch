using BestFlightSearch.Solution.Entity;
using BestFlightSearch.Solution.infraeroConsultaVoos;
using BestFlightSearch.Solution.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace BestFlightSearch.Solution
{
    /// <summary>
    /// Flight Search Infraero Solution Class
    /// </summary>
    public class FlightSearchInfraero : IFlightSearch
    {
        // INFRAERO WEBSERVICE CLIENT
        protected ConsultaVoosClient client = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public FlightSearchInfraero()
        {
            // INSTANCE CLIENT TO INFRAERO SERVICE
            client = new ConsultaVoosClient();
        }

        /// <summary>
        /// Query Airports
        /// </summary>
        /// <param name="Language">"bra" or "eua" or "esp"</param>
        /// <returns></returns>
        public List<Airport> QueryAirports(string Language = "bra")
        {
            try
            {
                // CALL WEBSERVICE METHOD
                var retorno = client.ListarAeroportos(Language);

                // MOUNT XML FROM STRING
                var xml = new XmlDocument();
                xml.LoadXml(retorno);

                // READ AIRPORT NODES
                var nodes = xml.DocumentElement.SelectNodes("/AEROPORTOS/AEROPORTO");

                // CREATE RESPONSE OBJECT
                var airports = new List<Airport>();

                // MOUNT RESPONSE OBJECT WITH XML NODES
                if (nodes.Count > 0)
                {
                    foreach (XmlNode item in nodes)
                    {
                        var obj = new Airport();

                        obj.AirportCode = item["COD_ICAO"].InnerText;
                        obj.City = item["NOM_CIDADE"].InnerText;
                        obj.HasSIV = (item["POSSUI_SIV"].InnerText == "S") ? true : false;
                        obj.IATACode = item["COD_IATA"].InnerText;
                        obj.Name = item["NOM_AEROPORTO"].InnerText;
                        obj.ShortName = item["VNOM_CURTO"].InnerText;
                        obj.StateCode = item["SIG_UF"].InnerText;

                        airports.Add(obj);
                    };
                }

                // RETURN AIRPORTS LIST
                return airports;
            }
            catch
            {
                return new List<Airport>();
            }
        }

        /// <summary>
        /// Query Flight Companies
        /// </summary>
        /// <param name="AirportCode"></param>
        /// <param name="Language"></param>
        /// <returns></returns>
        public List<FlightCompany> QueryFlightCompanies(string AirportCode, string Language = "bra")
        {
            try
            {
                // CALL WEBSERVICE METHOD
                var retorno = client.ListarCompanhias(AirportCode, Language);

                // MOUNT XML FROM STRING
                var xml = new XmlDocument();
                xml.LoadXml(retorno);

                // READ AIRPORT NODES
                var nodes = xml.DocumentElement.SelectNodes("/COMPANHIAS/COMPANHIA");

                // CREATE RESPONSE OBJECT
                var companies = new List<FlightCompany>();

                if (nodes.Count > 0)
                {
                    foreach (XmlNode item in nodes)
                    {
                        var obj = new FlightCompany();

                        obj.Name = item["NOM_CIA"].InnerText;
                        obj.ShortName = item["SIG_CIA"].InnerText;

                        companies.Add(obj);
                    };
                }

                // RETURN AIRPORTS LIST
                return companies;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("indisponível"))
                {
                    throw ex;
                }
                return new List<FlightCompany>();
            }
        }

        /// <summary>
        /// Query By Flight Number
        /// </summary>
        /// <param name="AirportCode"></param>
        /// <param name="FlightNumber"></param>
        /// <param name="Language">"bra" or "eua" or "esp"</param>
        /// <param name="Departure"></param>
        /// <param name="ShowEndFlights"></param>
        /// <param name="RecordsPerPage"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        public string QueryFlightPerNumber(string AirportCode, string FlightNumber, string Language = "bra", bool Departure = true, bool ShowEndFlights = false, int RecordsPerPage = 10, int PageNumber = 1)
        {
            if (string.IsNullOrEmpty(AirportCode) || string.IsNullOrEmpty(FlightNumber))
            {
                return "Invalid Parameters";
            }
            try
            {
                var retorno = client.ConsultarVoosNumero(AirportCode, Language, Departure, FlightNumber, ShowEndFlights, RecordsPerPage, PageNumber);

                return retorno;
            }
            catch
            {
                return "Error.";
            }
        }

        /// <summary>
        /// Query By Flight Company
        /// </summary>
        /// <param name="AirportCode"></param>
        /// <param name="Language">"bra" or "eua" or "esp"</param>
        /// <param name="Departure"></param>
        /// <param name="FlightCompany"></param>
        /// <param name="ShowEndFlights"></param>
        /// <param name="RecordsPerPage"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        public string QueryFlightPerFlightCompany(string AirportCode, string FlightCompany, string Language = "bra", bool Departure = true, bool ShowEndFlights = false, int RecordsPerPage = 10, int PageNumber = 1)
        {
            if (string.IsNullOrEmpty(AirportCode) || string.IsNullOrEmpty(FlightCompany))
            {
                return "Invalid Parameters";
            }
            try
            {
                var retorno = client.ConsultarVoosCiaAerea(AirportCode, Language, Departure, FlightCompany, ShowEndFlights, RecordsPerPage, PageNumber);

                return retorno;
            }
            catch
            {
                return "Error.";
            }
        }

        /// <summary>
        /// Query By Flight Direction
        /// </summary>
        /// <param name="AirportCode"></param>
        /// <param name="Language">"bra" or "eua" or "esp"</param>
        /// <param name="Departure"></param>
        /// <param name="ShowEndFlights"></param>
        /// <param name="RecordsPerPage"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        public string QueryFlightPerDirection(string AirportCode, string Language, bool Departure = true, bool ShowEndFlights = true, int RecordsPerPage = 10, int PageNumber = 1)
        {
            try
            {
                var retorno = client.ConsultarVoosSentido(AirportCode, Language, Departure, ShowEndFlights, RecordsPerPage, PageNumber);

                return retorno;
            }
            catch
            {
                return "Error.";
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            try
            {
                client.Close();
            }
            finally
            {
                client = null;
            }
        }
    }
}
