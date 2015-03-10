using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDav
{
    public class WebDavFileResourceRepository : IWebDavResourceRepository
    {
        public Task CreateCollectionAsync(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Stream GetResource(string uri)
        {
            throw new NotImplementedException();
        }

    }
}
