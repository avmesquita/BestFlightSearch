using BestFlightSearch.Solution.Domain;
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
        /// Constructor with timout property
        /// </summary>
        /// <param name="TimeOut"></param>
        public FlightSearchInfraero(int TimeOut = 10000)
        {
            // INSTANCE CLIENT TO INFRAERO SERVICE
            client = new ConsultaVoosClient();

            // SET DEFAULT TIMEOUT
            client.InnerChannel.OperationTimeout = new TimeSpan(TimeOut);
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
                        var obj = new Airport
                            (
                                item["NOM_AEROPORTO"].InnerText,
                                item["VNOM_CURTO"].InnerText,
                                item["COD_IATA"].InnerText,
                                item["COD_ICAO"].InnerText,
                                item["NOM_CIDADE"].InnerText,
                                item["SIG_UF"].InnerText,
                                (item["POSSUI_SIV"].InnerText == "S") ? true : false
                            );

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
        public List<Company> QueryFlightCompanies(string AirportCode, string Language = "bra")
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
                var companies = new List<Company>();

                if (nodes.Count > 0)
                {
                    foreach (XmlNode item in nodes)
                    {
                        var obj = new Company();

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
                return new List<Company>();
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
        public List<Flight> QueryFlightPerNumber(string AirportCode, string FlightNumber, string Language = "bra", bool Departure = true, bool ShowEndFlights = false, int RecordsPerPage = 10, int PageNumber = 1)
        {
            try
            {
                // CALL WEBSERVICE METHOD
                var retorno = client.ConsultarVoosNumero(AirportCode, Language, Departure, FlightNumber, ShowEndFlights, RecordsPerPage, PageNumber);

                // MOUNT XML FROM STRING
                var xml = new XmlDocument();
                xml.LoadXml(retorno);

                // READ FLIGHT NODES
                var nodes = xml.DocumentElement.SelectNodes("/VOOS/VOO");

                // CREATE RESPONSE OBJECT
                var flights = new List<Flight>();

                // MOUNT RESPONSE OBJECT WITH XML NODES
                if (nodes.Count > 0)
                {
                    foreach (XmlNode item in nodes)
                    {
                        var obj = new Flight();

                        obj.FlightNumber = item["NUM_VOO"].InnerText;
                        obj.FlightDate = item["DAT_VOO"].InnerText;
                        obj.TimePrev = item["HOR_PREV"].InnerText;
                        obj.TimeConfirmed = item["HOR_CONF"].InnerText;
                        obj.FlightTPS = item["NUM_TPS"].InnerText;
                        obj.FlightGate = item["NUM_GATE"].InnerText;
                        obj.Obs = item["TXT_OBS"].InnerText;
                        obj.CompanyName = item["NOM_CIA"].InnerText;
                        obj.CompanyShortName = item["SIG_CIA_AEREA"].InnerText;
                        obj.Equipment = item["DSC_EQUIPAMENTO"].InnerText;
                        obj.AirportName = item["NOM_AEROPORTO"].InnerText;
                        obj.IATACode = item["COD_IATA"].InnerText;
                        obj.AirportCode = item["COD_ICAO"].InnerText;
                        obj.City = item["NOM_LOCALIDADE"].InnerText;
                        obj.StateCode = item["SIG_UF"].InnerText;
                        obj.Country = item["NOM_PAIS"].InnerText;
                        obj.FlightKind = item["DSC_NATUREZA"].InnerText;
                        obj.FlightStatus = item["DSC_STATUS"].InnerText;
                        obj.FlightStops = item["ESCALAS"].InnerText;

                        flights.Add(obj);
                    };
                }

                // RETURN AIRPORTS LIST
                return flights;
            }
            catch
            {
                return new List<Flight>();
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
        public List<Flight> QueryFlightPerFlightCompany(string AirportCode, string FlightCompany, string Language = "bra", bool Departure = true, bool ShowEndFlights = false, int RecordsPerPage = 10, int PageNumber = 1)
        {
            if (string.IsNullOrEmpty(AirportCode) || string.IsNullOrEmpty(FlightCompany))
            {
                throw new Exception("Invalid Parameters");
            }
            try
            {
                // CALL WEBSERVICE METHOD
                var retorno = client.ConsultarVoosCiaAerea(AirportCode, Language, Departure, FlightCompany, ShowEndFlights, RecordsPerPage, PageNumber);

                // MOUNT XML FROM STRING
                var xml = new XmlDocument();
                xml.LoadXml(retorno);

                // READ FLIGHT NODES
                var nodes = xml.DocumentElement.SelectNodes("/VOOS/VOO");

                // CREATE RESPONSE OBJECT
                var flights = new List<Flight>();

                // MOUNT RESPONSE OBJECT WITH XML NODES
                if (nodes.Count > 0)
                {
                    foreach (XmlNode item in nodes)
                    {
                        var obj = new Flight();

                        obj.FlightNumber = item["NUM_VOO"].InnerText;
                        obj.FlightDate = item["DAT_VOO"].InnerText;
                        obj.TimePrev = item["HOR_PREV"].InnerText;
                        obj.TimeConfirmed = item["HOR_CONF"].InnerText;
                        obj.FlightTPS = item["NUM_TPS"].InnerText;
                        obj.FlightGate = item["NUM_GATE"].InnerText;
                        obj.Obs = item["TXT_OBS"].InnerText;
                        obj.CompanyName = item["NOM_CIA"].InnerText;
                        obj.CompanyShortName = item["SIG_CIA_AEREA"].InnerText;
                        obj.Equipment = item["DSC_EQUIPAMENTO"].InnerText;
                        obj.AirportName = item["NOM_AEROPORTO"].InnerText;
                        obj.IATACode = item["COD_IATA"].InnerText;
                        obj.AirportCode = item["COD_ICAO"].InnerText;
                        obj.City = item["NOM_LOCALIDADE"].InnerText;
                        obj.StateCode = item["SIG_UF"].InnerText;
                        obj.Country = item["NOM_PAIS"].InnerText;
                        obj.FlightKind = item["DSC_NATUREZA"].InnerText;
                        obj.FlightStatus = item["DSC_STATUS"].InnerText;
                        obj.FlightStops = item["ESCALAS"].InnerText;

                        flights.Add(obj);
                    };
                }

                // RETURN AIRPORTS LIST
                return flights;
            }
            catch
            {
                return new List<Flight>();
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
        public List<Flight> QueryFlightPerDirection(string AirportCode, string Language = "bra", bool Departure = true, bool ShowEndFlights = true, int RecordsPerPage = 10, int PageNumber = 1)
        {
            try
            {
                // CALL WEBSERVICE METHOD
                var retorno = client.ConsultarVoosSentido(AirportCode, Language, Departure, ShowEndFlights, RecordsPerPage, PageNumber);

                // MOUNT XML FROM STRING
                var xml = new XmlDocument();
                xml.LoadXml(retorno);

                // READ FLIGHT NODES
                var nodes = xml.DocumentElement.SelectNodes("/VOOS/VOO");

                // CREATE RESPONSE OBJECT
                var flights = new List<Flight>();

                // MOUNT RESPONSE OBJECT WITH XML NODES
                if (nodes.Count > 0)
                {
                    foreach (XmlNode item in nodes)
                    {
                        var obj = new Flight();

                        obj.FlightNumber = item["NUM_VOO"].InnerText;
                        obj.FlightDate = item["DAT_VOO"].InnerText;
                        obj.TimePrev = item["HOR_PREV"].InnerText;
                        obj.TimeConfirmed = item["HOR_CONF"].InnerText;
                        obj.FlightTPS = item["NUM_TPS"].InnerText;
                        obj.FlightGate = item["NUM_GATE"].InnerText;
                        obj.Obs = item["TXT_OBS"].InnerText;
                        obj.CompanyName = item["NOM_CIA"].InnerText;
                        obj.CompanyShortName = item["SIG_CIA_AEREA"].InnerText;
                        obj.Equipment = item["DSC_EQUIPAMENTO"].InnerText;
                        obj.AirportName = item["NOM_AEROPORTO"].InnerText;
                        obj.IATACode = item["COD_IATA"].InnerText;
                        obj.AirportCode = item["COD_ICAO"].InnerText;
                        obj.City = item["NOM_LOCALIDADE"].InnerText;
                        obj.StateCode = item["SIG_UF"].InnerText;
                        obj.Country = item["NOM_PAIS"].InnerText;
                        obj.FlightKind = item["DSC_NATUREZA"].InnerText;
                        obj.FlightStatus = item["DSC_STATUS"].InnerText;
                        obj.FlightStops = item["ESCALAS"].InnerText;

                        flights.Add(obj);
                    };
                }

                // RETURN AIRPORTS LIST
                return flights;
            }
            catch
            {
                return new List<Flight>();
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
