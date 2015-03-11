using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NDav.Http;
using NSubstitute;
using Xunit;

namespace NDav.Tests
{
    public class Get_Tests
    {
        private const string BaseUri = "http://localhost/dav/";
        [Fact]
        public async void Successful_request_must_return_200()
        {
            var uri = new Uri(BaseUri);
            var request = new HttpRequest(uri, WebDavMethods.Get);
            var sub = Substitute.For<IWebDavResourceRepository>();
            sub.GetResourceAsync(uri).Returns(Task.FromResult<Stream>(new MemoryStream(new byte[] { 0x20, 0x50 })));
            var processor = new WebDavProcessor(sub);
            var response = await processor.ProcessRequestAsync(request);
            Assert.Equal(response.Body, new byte[] { 0x20, 0x50 });
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async void If_file_doesnt_exists_must_return_NotFound()
        {
            var request = new HttpRequest(new Uri(BaseUri + "notfoundfile"), WebDavMethods.Get);
            var processor = new WebDavProcessor(Substitute.For<IWebDavResourceRepository>());
            var response = await processor.ProcessRequestAsync(request);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
