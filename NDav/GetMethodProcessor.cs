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

        public override async Task<HttpResponse> ProcessRequestAsync(HttpRequest request)
        {
            var resourceStream = await Repository.GetResourceAsync(request.Uri);
            var response = new HttpResponse();
            if (resourceStream == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                var ms = new MemoryStream();
                await resourceStream.CopyToAsync(ms);
                response.Body = ms.ToArray();
            }
            return response;
        }
    }
}
