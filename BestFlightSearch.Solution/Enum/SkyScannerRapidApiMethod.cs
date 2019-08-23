using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Enum
{
    public enum SkyScannerRapidApiMethod
    {
        LiveFlightSearch_CreateSession,
        LiveFlightSearch_PollSessionResults,
        Places_ListPlaces,
        BrowseFlightPrices_BrowseQuotes,
        BrowseFlightPrices_BrowseRoutes,
        BrowseFlightPrices_BrowseDates,
        BrowseFlightPrices_BrowseDatesInbound,
        BrowseFlightPrices_BrowseQuotesInbound,
        BrowseFlightPrices_BrowseRoutesInbound,
        Localisation_ListMarkets,
        Localisation_ListCurrencies
    }
}
