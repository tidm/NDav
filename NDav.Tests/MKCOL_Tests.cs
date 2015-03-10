using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NDav.Http;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace NDav.Tests
{
    // http://www.webdav.org/specs/rfc2518.html#METHOD_MKCOL
    public class MKCOL_Tests
    {
        private const string BaseUri = "http://localhost/dav/";

        [Fact]
        public async void Successful_request_must_return_201_Created()
        {
            var request = new HttpRequest(new Uri(BaseUri), WebDavMethods.MkCol);

            var processor = new WebDavProcessor(Substitute.For<IWebDavResourceRepository>());
            var response = await processor.ProcessRequestAsync(request);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public async void If_request_uri_is_an_existed_resource_MKCOL_must_fail_with_405_MethodNotAllowed()
        {
            var request = new HttpRequest(new Uri(BaseUri + "existed"), WebDavMethods.MkCol);
            var repo = Substitute.For<IWebDavResourceRepository>();
            repo.When(x => x.CreateCollectionAsync(new Uri(BaseUri + "existed")))
                .Do(x => { throw new ResourceExistsException(); });

            var processor = new WebDavProcessor(repo);
            var response = await processor.ProcessRequestAsync(request);

            Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }
        [Fact]
        public async void If_any_of_uri_ancestors_does_not_exist_request_must_fail_with_409_Conflict()
        {
            var request = new HttpRequest(new Uri(BaseUri + "notexisted/notexisted"), WebDavMethods.MkCol);
            var repo = Substitute.For<IWebDavResourceRepository>();
            repo.When(x => x.CreateCollectionAsync(new Uri(BaseUri + "notexisted/notexisted")))
                .Do(x => { throw new ResourceAncestorDoesNotExistException(); });

            var processor = new WebDavProcessor(repo);
            var response = await processor.ProcessRequestAsync(request);

            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }
        [Fact]
        public async void If_any_of_uri_ancestors_are_not_a_collection_request_must_fail_with_409_Conflict()
        {
            var request = new HttpRequest(new Uri(BaseUri + "file.html/notexisted"), WebDavMethods.MkCol);
            var repo = Substitute.For<IWebDavResourceRepository>();
            repo.When(x => x.CreateCollectionAsync(new Uri(BaseUri + "file.html/notexisted")))
                .Do(x => { throw new ResourceAncestorIsNotCollectionException(); });

            var processor = new WebDavProcessor(repo);
            var response = await processor.ProcessRequestAsync(request);

            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }
        [Fact]
        public async void If_the_server_receives_a_MKCOL_request_entity_type_it_does_not_support_or_understand_it_must_respond_with_a_415()
        {
            var request = new HttpRequest(new Uri(BaseUri + "unsupported*name"), WebDavMethods.MkCol);
            var repo = Substitute.For<IWebDavResourceRepository>();
            repo.When(x => x.CreateCollectionAsync(new Uri(BaseUri + "unsupported*name")))
                .Do(x => { throw new UnsupportedResourceException(); });

            var processor = new WebDavProcessor(repo);
            var response = await processor.ProcessRequestAsync(request);

            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }
        [Fact]
        public async void If_the_resource_does_not_have_sufficient_space_to_record_the_state_of_the_resource_response_must_be_507_InsufficientSpace()
        {
            var request = new HttpRequest(new Uri(BaseUri + "hugecol"), WebDavMethods.MkCol);
            var repo = Substitute.For<IWebDavResourceRepository>();
            repo.When(x => x.CreateCollectionAsync(new Uri(BaseUri + "hugecol")))
                .Do(x => { throw new InsufficientSpaceException(); });

            var processor = new WebDavProcessor(repo);
            var response = await processor.ProcessRequestAsync(request);

            Assert.Equal((HttpStatusCode)507, response.StatusCode);
        }
        [Fact]
        public async void If_parent_collection_exists_but_cannot_accept_members_response_must_be_403_Forbidden()
        {
            var request = new HttpRequest(new Uri(BaseUri + "unacceptable"), WebDavMethods.MkCol);
            var repo = Substitute.For<IWebDavResourceRepository>();
            repo.When(x => x.CreateCollectionAsync(new Uri(BaseUri + "unacceptable")))
                .Do(x => { throw new CollectionDoesNotAcceptMembersException(); });

            var processor = new WebDavProcessor(repo);
            var response = await processor.ProcessRequestAsync(request);

            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Fact]
        public void After_MKCOL_the_uri_must_be_a_member_of_its_parent()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void When_request_body_does_not_have_body_newly_created_collection_should_have_no_members()
        {
            throw new NotImplementedException();
        }
    }
}
