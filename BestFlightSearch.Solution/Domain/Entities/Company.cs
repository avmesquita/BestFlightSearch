using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Domain
{
    [Serializable]
    public class Company
    {
        /// <summary>
        /// Air Company Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Air Companhy Short Name
        /// </summary>
        public string ShortName { get; set; }
    }
}
