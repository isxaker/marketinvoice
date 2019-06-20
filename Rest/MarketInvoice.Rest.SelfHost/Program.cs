using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace MarketInvoice.Rest.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpLocalhost = "http://localhost:6800";

            var config = new HttpSelfHostConfiguration(httpLocalhost); 
            config.MapHttpAttributeRoutes();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            //selfHostConfiguration.Routes.MapHttpRoute( 
            //    name: "DefaultApiRoute", 
            //    routeTemplate: "api/{controller}", 
            //    defaults: null 
            //); 

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine($"Server started at: {httpLocalhost}");
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
