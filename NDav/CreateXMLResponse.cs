using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Web;
using System.Xml;

namespace NDav
{
    public class CreateXMLResponse
    {
        public CreateXMLResponse()
        {
            
        }

        internal static string ProcessErrorRequest(Dictionary<string, string> errorResources)//, XmlNode appendResponseNode)
        {
            string _errorRequest = "";

            //Build the response 
            using (Stream _responseStream = new MemoryStream())
            {
                XmlTextWriter _xmlWriter = new XmlTextWriter(_responseStream, new UTF8Encoding(false));

               

                _xmlWriter.Formatting = Formatting.Indented;
                _xmlWriter.IndentChar = '\t';
                _xmlWriter.Indentation = 1;
                _xmlWriter.WriteStartDocument();

              

                //Set the Multistatus
                _xmlWriter.WriteStartElement("D", "multistatus", "DAV:");

                //Append the errors
                foreach (string _errorCode in errorResources.Keys)
                {
                    //Open the response element
                    _xmlWriter.WriteStartElement("response", "DAV:");
                    _xmlWriter.WriteElementString("href", "DAV:", errorResources[_errorCode]);
                    _xmlWriter.WriteElementString("status", "DAV:", GetEnumHttpResponse(_errorCode));
                    //Close the response element section
                    _xmlWriter.WriteEndElement();
                }

                //if (appendResponseNode != null)
                //    appendResponseNode.WriteTo(_xmlWriter);

                _xmlWriter.WriteEndElement();
                _xmlWriter.WriteEndDocument();
                _xmlWriter.Flush();

                using (StreamReader _streamReader = new StreamReader(_responseStream, Encoding.UTF8))
                {
                    //Go to the begining of the stream
                    _streamReader.BaseStream.Position = 0;
                    _errorRequest = _streamReader.ReadToEnd();
                }
                _xmlWriter.Close();
            }
            return _errorRequest;
        }

        internal static string GetEnumHttpResponse(string statusCode)
        {
            string _httpResponse = "";

            switch (statusCode)
            {
                case "200":
                    _httpResponse = "HTTP/1.1 200 OK";
                    break;

                case "207":
                    _httpResponse = "HTTP/1.1 207 Multi-Status";
                    break;

                case "404":
                    _httpResponse = "HTTP/1.1 404 Not Found";
                    break;

                case "423":
                    _httpResponse = "HTTP/1.1 423 Locked";
                    break;

                case "424":
                    _httpResponse = "HTTP/1.1 424 Failed Dependency";
                    break;

                case "507":
                    _httpResponse = "HTTP/1.1 507 Insufficient Storage";
                    break;

                default:
                    throw new Exception("InvalidStatusCode");
            }

            return _httpResponse;
        }
    }
}
