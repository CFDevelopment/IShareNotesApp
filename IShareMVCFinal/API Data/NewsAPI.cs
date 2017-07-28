using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IShareMVCFinal.API_Data
{
    public class NewsAPI
    {

        /*Should be a singleton !!!
         HttpClient is intended to be instantiated once and re-used throughout the life of an application. 
         Especially in server applications, creating a new HttpClient instance for every request will exhaust
         the number of sockets available under heavy loads. This will result in SocketException errors.*/
        static HttpClient client = new HttpClient();
        
        /*public static Task RunAsync()
        {
            // New code:
            client.BaseAddress = new Uri("\r\nhttps://newsapi.org/v1/articles?source=bloomberg&sortBy=top&apiKey=fd39537e496a499189011751864344ed");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Console.ReadLine();
        }*/

    }
}