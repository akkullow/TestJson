using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;


namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://127.0.0.1:8090/GetParamsJson/
            //http://localhost/test/


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8090/GetParamsJson");            
            // Set some reasonable limits on resources used by this request
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            request.Accept = "text/html, application/json";
            request.ContentType = "text/json";
            // Set credentials to use for this request.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine("ContentEncoding is {0}", response.ContentEncoding);
            Console.WriteLine("Status Code is {0}", response.StatusCode);
            Console.WriteLine("Method is {0}", response.Method);
            Console.WriteLine("Protocol Version is {0}", response.ProtocolVersion);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Headers is\n{0}", response.Headers);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Content length is {0}", response.ContentLength);
            Console.WriteLine("Content type is {0}", response.ContentType);

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            Console.WriteLine("Response stream received.");
            Console.WriteLine(readStream.ReadToEnd());
            response.Close();
            readStream.Close();
            Console.Read();
        }
    }
}
