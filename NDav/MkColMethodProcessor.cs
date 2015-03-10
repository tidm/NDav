using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NDav.Http;

namespace NDav
{
    internal class MkColMethodProcessor : WebDavMethodProcessor
    {
        public MkColMethodProcessor(IWebDavResourceRepository repository)
            : base(repository)
        {
        }

        public override async Task<HttpResponse> ProcessRequestAsync(HttpRequest request)
        {
            HttpResponse response = new HttpResponse();
            try
            {
                await Repository.CreateCollectionAsync(request.Uri);
                response.StatusCode = HttpStatusCode.Created;
            }
            catch (ResourceExistsException)
            {
                response.StatusCode = HttpStatusCode.MethodNotAllowed;
            }
            return response;
        }
    }
}
