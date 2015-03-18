using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NDav.Exceptions;
using NDav.Http;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace NDav.Tests
{
    //http://www.webdav.org/specs/rfc2518.html#METHOD_DELETE
    public class DELETE_Tests
    {
        private const string BaseUri = "http://localhost/dav/";

        #region Written Tests

        [Fact]
        public async void If_delete_is_done_return_204()
        //The DELETE method on a collection must act as if a "Depth: infinity" header was used on it
        {
            var header = new KeyValuePair<string, string>("Depth", "Infinity");
            var request = new HttpRequest(new Uri(BaseUri), WebDavMethods.Delete, header);
            var processor = new WebDavProcessor(Substitute.For<IWebDavResourceRepository>());

            var response = await processor.ProcessRequestAsync(request);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        /// <summary>
        /// A client must not submit a Depth header with a DELETE on a collection with any value but infinity.
        /// </summary>
        [Fact]
        public async void client_could_only_send_infinity_value_on_depth_header_with_delete_on_collenction()
        {
            var header = new KeyValuePair<string, string>("Depth", "0");
            var request = new HttpRequest(new Uri(BaseUri), WebDavMethods.Delete, header);
            var processor = new WebDavProcessor(Substitute.For<IWebDavResourceRepository>());

            var response = await processor.ProcessRequestAsync(request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        /// If an error occurs with a resource other than the resource identified in the Request-URI then the response must be a 207 (Multi-Status).
        /// 424 (Failed Dependency) errors should not be in the 207 (Multi-Status). They can be safely left out because the client will know 
        /// that the ancestors of a resource could not be deleted when the client receives an error for the ancestor's progeny. 
        /// Additionally 204 (No Content) errors should not be returned in the 207 (Multi-Status). 
        /// The reason for this prohibition is that 204 (No Content) is the default success code.
        /// </summary>
        [Fact]
        public async void If_error_occur_in_resource_otherthan_resource_in_Request_uri_must_return_207()
        {
            var header = new KeyValuePair<string, string>("Depth", "Infinity");
            var request = new HttpRequest(new Uri(BaseUri + "Locked"), WebDavMethods.Delete, header);
            var sub = Substitute.For<IWebDavResourceRepository>();
            sub.When(x => x.DeleteColletionAsync(new Uri(BaseUri + "Locked")))
                .Do(x =>
                {
                    var exception = new ErrorReportsException();
                    exception.ErrorList.Add("423", "http://www.test.com/content/resource1");
                    exception.ErrorList.Add("404", "http://www.test.com/content/resource2");
                    throw exception;
                });

            var processor = new WebDavProcessor(sub);
            var response = await processor.ProcessRequestAsync(request);
            Assert.Equal((HttpStatusCode)207, response.StatusCode);
        }

        #endregion

        #region Should be written

        //todo:  confusing
        /// <summary>
        /// When the DELETE method has completed processing it must result in a consistent namespace.
        /// </summary>
        [Fact]
        public void When_deleting_process_compelete_must_result_in_consistent_namespace()
        {
            throw new NotImplementedException();
        }

        //TODO : a test for removing uri from collections while executing delete method
        [Fact]
        public async void If_delete_request_is_inernal_member_of_one_collection_any_other_uri_containing_this_resource_must_be_removed_by_server()
        //If the DELETE method is issued to a non-collection resource whose URIs are an internal member of one or more collections,
        //then during DELETE processing a server must remove any URI for the resource identified by the Request-URI from collections which contain it as a member.
        {
            //var header = new KeyValuePair<string, string>("Depth", "Infinity");
            //var request = new HttpRequest(new Uri(BaseUri), WebDavMethods.Delete, header);
            //var newrequest = new HttpRequest(new Uri(BaseUri), WebDavMethods.Delete, header);

            //var sub = Substitute.For<IWebDavResourceRepository>();
            //var processor = new WebDavProcessor(sub);

            //var response = await processor.ProcessRequestAsync(request);
            //var newresponse = await processor.ProcessRequestAsync(newrequest);

            //Assert.Equal(newresponse.StatusCode, CheckParalellResponse(response, newresponse));
            throw new NotImplementedException();

        }
        //private HttpStatusCode CheckParalellResponse(HttpResponse resp1, HttpResponse resp2)
        //{
        //    if(resp1.StatusCode == HttpStatusCode.OK && resp2.)
        //}


        [Fact]
        public async void The_collection_and_its_internal_members_in_request_uri_should_delete()
        //DELETE instructs that the collection specified in the Request-URI and all resources identified by its internal member URIs are to be deleted.
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async void If_a_child_cannot_be_deleted_its_father_mustnot_delete()
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

        #endregion

    }
}
