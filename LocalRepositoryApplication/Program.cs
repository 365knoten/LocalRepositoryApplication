using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Net.Http.Headers;
using System.Web.Http.Tracing;

namespace LocalRepositoryApplication
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {


            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration("http://localhost:8080/");

            config.MapHttpAttributeRoutes();

            /*
            config.Routes.MapHttpRoute(
   name: "bower",
   routeTemplate: "bower/packages/{action}/{packagename}",
   defaults: new
   {
       controller = "Bower",
       packagename = RouteParameter.Optional,
   }
   );


            config.Routes.MapHttpRoute(
name: "npm",
routeTemplate: "npm/{action}/{packagename}",
defaults: new
{
controller = "NPM",
packagename = RouteParameter.Optional,
}
);



            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
                */

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));


          


            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainScreen main = new MainScreen();
                config.Services.Replace(typeof(ITraceWriter), new LocalTraceWriter(main));
                Application.Run(main);
            }



        }
    }
}
