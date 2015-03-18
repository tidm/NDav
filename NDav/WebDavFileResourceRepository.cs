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
        public Task<Stream> GetResourceAsync(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task DeleteColletionAsync(Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
