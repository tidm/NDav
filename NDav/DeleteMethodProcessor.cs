using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NDav.Exceptions;
using NDav.Http;

namespace NDav
{
    class DeleteMethodProcessor : WebDavMethodProcessor
    {
        private static bool flag = false;
        public DeleteMethodProcessor(IWebDavResourceRepository repository)
            : base(repository)
        {
        }

        public override async Task<HttpResponse> ProcessRequestAsync(HttpRequest request)
        {
            HttpResponse response = new HttpResponse();
            try
            {
                if (request.Headers["Depth"] == "Infinity")
                {
                    await Repository.DeleteColletionAsync(request.Uri);
                    response.StatusCode = HttpStatusCode.NoContent;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
            }
            catch (ErrorReportsException e)
            {
                 //response.Body = 
                 string returnBody = CreateXMLResponse.ProcessErrorRequest(e.ErrorList);
                returnBody = CreateXMLResponse.GetEnumHttpResponse("207")+ Environment.NewLine + 
                             "Content-Type: text/xml; charset=\"utf-8\"" + Environment.NewLine +
                             "Content-Length: xxxx" + Environment.NewLine +
                             returnBody;

                response.Body = Encoding.ASCII.GetBytes(returnBody);
                response.StatusCode = (HttpStatusCode) 207;
            }
            return response;
        }
    }
}