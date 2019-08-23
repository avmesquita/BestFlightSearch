using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Enum
{
    public enum SkyScannerIOMethod
    {
        Autenticatiom_Token,
        FlightsBrowsePrices_BrowseQuotes,
        FlightsBrowsePrices_BrowseRoutes,
        FlightsBrowsePrices_BrowseDates,
        FlightsBrowsePrices_BrowseDatesGrid,
        FlightLivePrices_CreateSession,
        FlightLivePrices_PolingResults,
        FlightLivePrices_GetBookingDetails,
        FlightLivePrices_PollingBookingDetails,
        CarHirePrices_CreateSession,
        CarHirePrices_PollingResults,
        HotelsLivePrices_Endpoint,
        HotelsLivePrices_Headers,
        HotelsLivePrices_UseFlow,
        HotelsLivePrices_SearchPrices,
        HotelsLivePrices_SearchPricesMap,
        HotelsLivePrices_HotelPrices,
        HotelsLivePrices_HotelsPrices,
        Localisation_Locales,
        Localisation_Currencies,
        Localisation_Markets,
        Places_ListPlaces,
        Places_PlaceInformation,
        Places_GeoCatalog,
        Places_Schemas,
        Places_Hotels_Autosuggest,
        BookingRedirects
    }
}
