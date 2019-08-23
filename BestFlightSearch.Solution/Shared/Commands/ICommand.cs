using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Shared.Commands
{
    public interface ICommand
    {
        bool Valid();
    }
}
