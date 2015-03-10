using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NDav.Http
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public IDictionary<string, string> Headers { get; private set; }
        public Stream Body { get; set; }
    }
}

