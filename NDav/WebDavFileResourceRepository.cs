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
        public Stream GetResource(string uri)
        {
            throw new NotImplementedException();
        }

        public void CreateCollection(Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
