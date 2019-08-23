using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Enum
{
    public enum SkyScannerIOResponseCodes
    {
        Success =200,
        NoContent = 204,
        MovedPermanently = 301,
        NotModified = 304,
        BadRequest = 400,
        Forbidden = 403,
        Gone = 410,
        TooManyRequests = 429,
        ServerError = 500
    }
}
