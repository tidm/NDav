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
        Task CreateCollectionAsync(Uri uri);
        Task<Stream> GetResourceAsync(Uri uri);
        Task DeleteColletionAsync(Uri uri);   
    }
}
