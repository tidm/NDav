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
            await Repository.CreateCollectionAsync(request.Uri);
            var response = new HttpResponse {StatusCode = HttpStatusCode.Created};
            return response;
        }
    }
}
