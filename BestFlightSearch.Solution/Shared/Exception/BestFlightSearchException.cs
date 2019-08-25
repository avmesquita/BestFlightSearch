using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Shared.Exception
{
    public class BestFlightSearchException : System.Exception
    {

        /// <summary>
        /// Obtém os detalhes do erro em formato string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public override string ToString()
        {
            var exMsg = (Message != null) ? "MESSAGE = " + Message.ToString() : string.Empty;
            var exInner = (InnerException != null) ? " | INNER: " + InnerException.ToString() : string.Empty;
            var exStack = (StackTrace != null) ? " | STACK: " + StackTrace.ToString() : string.Empty;
            var exSource = (StackTrace != null) ? " | SOURCE: " + Source.ToString() : string.Empty;

            var msg = string.Format("[ {0} {1} {3} {2} ]", exMsg, exInner, exStack, exSource);

            return msg;
        }

    }
}
