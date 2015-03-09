using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NDav
{
    public class WebDavProcessor
    {
        private Dictionary<string, WebDavMethodProcessor> _methodProcessors;
        private IWebDavResourceRepository _resourceRepository;

        public WebDavProcessor(IWebDavResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
            InitializeMethodProcessors();
        }

        private void InitializeMethodProcessors()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpWebResponse> ProcessRequestAsync(HttpWebRequest request)
        {
            return await _methodProcessors[request.Method].ProcessRequestAsync(request);
        }
    }

}
