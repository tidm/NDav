﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NDav
{
    internal class MkColMethodProcessor : WebDavMethodProcessor
    {
        public MkColMethodProcessor(IWebDavResourceRepository repository)
            : base(repository)
        {
        }

        public override async Task<HttpWebResponse> ProcessRequestAsync(HttpWebRequest request)
        {
            //Repository.CreateCollection(request.RequestUri);
            //var response = (HttpWebResponse) await request.GetResponseAsync();
            throw new NotImplementedException();
        }
    }
}
