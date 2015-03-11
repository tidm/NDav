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
    public class DELETE_Tests
    {
        private const string BaseUri = "http://localhost/dav/";

        [Fact]
        public async void If_delete_request_is_inernal_member_of_one_collection_any_other_uri_containing_this_resource_must_be_removed_by_server()
        //If the DELETE method is issued to a non-collection resource whose URIs are an internal member of one or more collections, then during DELETE processing a server must remove any URI for the resource identified by the Request-URI from collections which contain it as a member.
        {
            var request = WebRequest.CreateHttp(BaseUri);
            request.Method = WebDavMethods.Delete;
            var sub = Substitute.For<IWebDavResourceRepository>();
            sub.GetResource("").Returns(new MemoryStream());
            var processor = new WebDavProcessor(sub);

            var newrequest = WebRequest.CreateHttp(BaseUri);
            request.Method = WebDavMethods.Delete;
            
            var response = await processor.ProcessRequestAsync(request);
            var newresponse = await processor.ProcessRequestAsync(newrequest);

            Assert.Equal(HttpStatusCode.ExpectationFailed, newresponse.StatusCode);

            throw new NotImplementedException();
        }

        [Fact]
        public async void If_depth_equal_infinity_used_on_header_delete_must_act()
        //The DELETE method on a collection must act as if a "Depth: infinity" header was used on it
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async void client_could_only_send_infinity_value_on_depth_header_with_delete_on_collenction()
        // A client must not submit a Depth header with a DELETE on a collection with any value but infinity.
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async void The_collection_and_its_internal_members_in_request_uri_sheold_delete()
        //DELETE instructs that the collection specified in the Request-URI and all resources identified by its internal member URIs are to be deleted.
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async void If_a_child_cannot_be_deleted_its_fathers_mustnot_delete()
        //If any resource identified by a member URI cannot be deleted then all of the member's ancestors must not be deleted,so as to maintain namespace consistency
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Apply_delete_process_to_any_header_containing_delete()
        //Any headers included with DELETE must be applied in processing every resource to be deleted.
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void When_deleting_process_compelete_must_result_in_consistent_namespace()
        //When the DELETE method has completed processing it must result in a consistent namespace.
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void If_error_occur_in_resource_otherthan_resource_in_Request_uri_must_return_207()
        //If an error occurs with a resource other than the resource identified in the Request-URI then the response must be a 207 (Multi-Status).
        // 424 (Failed Dependency) errors should not be in the 207 (Multi-Status). They can be safely left out because the client will know that the ancestors of a resource could not be deleted when the client receives an error for the ancestor's progeny. Additionally 204 (No Content) errors should not be returned in the 207 (Multi-Status). The reason for this prohibition is that 204 (No Content) is the default success code.
        {
            throw new NotImplementedException();
        }
    }
}
