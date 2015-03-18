using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDav.Exceptions
{
    public class ErrorReportsException : Exception
    {
        public Dictionary<string, string> ErrorList { get; set; }

        public ErrorReportsException()
        {
            ErrorList = new Dictionary<string, string>();
        }
    }
}
