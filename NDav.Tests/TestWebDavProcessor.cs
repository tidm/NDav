using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NDav.Tests
{
    public class TestWebDavProcessor
    {
        public void Test_get_request()
        {
            
           // var webdav = new WebDavProcessor();
            var request = HttpWebRequest.CreateHttp("http://localhost/test");
            request.Method = "GET";
        }
    }
}
