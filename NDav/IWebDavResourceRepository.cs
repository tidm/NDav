using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NDav
{
    public interface IWebDavResourceRepository
    {
        Stream GetResource(string uri);
    }
}
