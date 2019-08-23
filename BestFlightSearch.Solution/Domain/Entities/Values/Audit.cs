using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Domain.Entities.Values
{
    public class Audit
    {
        public DateTime? UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUserId { get; set; }
        public string UpdatedUserId { get; set; }
    }
}
