using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace NDav.Tests
{
    public class MKCOL_Tests
    {
        private const string BaseUri = "http://localhost/dav/";

        [Fact]
        public async void Successful_request_must_return_201()
        {
            var request = WebRequest.CreateHttp(BaseUri);
            request.Method = WebDavMethods.MkCol;
            var processor = new WebDavProcessor(Substitute.For<IWebDavResourceRepository>());
            var response = await processor.ProcessRequestAsync(request);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public void If_request_uri_is_non_null_MKCOL_must_fail()
        {
        }

        [Fact]
        public void After_MKCOL_the_uri_must_be_a_member_of_its_parent()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void If_any_of_uri_ancestors_does_not_exist_request_must_fail_with_409()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void When_request_body_does_not_have_body_newly_created_collection_should_have_no_members()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void If_the_server_receives_a_MKCOL_request_entity_type_it_does_not_support_or_understand_it_must_respond_with_a_415()
        {

        }

        [Fact]
        public void If_parent_collection_exists_but_cannot_accept_members_response_must_be_403()
        {
        }

        [Fact]
        public void MKCOL_can_only_be_executed_on_a_deleted_or_non_existent_resource_otherwise_should_return_405()
        {
        }

        [Fact]
        public void If_the_resource_does_not_have_sufficient_space_to_record_the_state_of_the_resource_response_must_be_507()
        {
        }

    }
}
