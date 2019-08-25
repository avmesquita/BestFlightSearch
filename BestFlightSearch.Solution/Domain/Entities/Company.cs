using BestFlightSearch.Solution.Domain.Entities;
using BestFlightSearch.Solution.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Domain
{
    [Serializable]
    public class Company : Entity
    {
        public Company(string name, string shortname)
        {
            this.Name = name;
            this.ShortName = shortname;

            Validate(this, new CompanyValidator());
        }

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
