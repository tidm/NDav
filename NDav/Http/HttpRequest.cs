using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDav.Http
{
    public class HttpRequest
    {
        public string Method { get; set; }
        public Uri Uri { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public HttpRequest()
        {

        }

        public HttpRequest(Uri uri, string method)
        {
            Uri = uri;
            Method = method;
        }

        public HttpRequest(Uri uri, string method, KeyValuePair<string, string> header)
        {
            Uri = uri;
            Method = method;
            Headers = new Dictionary<string, string>();
            Headers.Add(header);
        }

    }
}
