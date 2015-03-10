using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NDav.Http;

namespace NDav
{
    internal class GetMethodProcessor : WebDavMethodProcessor
    {
        public GetMethodProcessor(IWebDavResourceRepository repository)
            : base(repository)
        {
        }

        public override Task<HttpResponse> ProcessRequestAsync(HttpRequest request)
        {
            //WebResponse response = request.GetResponse();
            //var stream = response.GetResponseStream();
            //var resource = Repository.GetResource(request.RequestUri.AbsoluteUri);
            //byte[] output = new byte[resource.Length];
            //resource.Read(output, 0, (int)resource.Length);
            //stream.Write(output, 0, (int)resource.Length);
            throw new NotImplementedException();
        }

    }
}
