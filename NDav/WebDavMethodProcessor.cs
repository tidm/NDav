﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NDav
{
    public abstract class WebDavMethodProcessor
    {
        protected readonly IWebDavResourceRepository Repository;
        protected WebDavMethodProcessor(IWebDavResourceRepository repository)
        {
            Repository = repository;
        }

        public abstract Task<HttpWebResponse> ProcessRequestAsync(HttpWebRequest request);
    }
}
