using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Tracing;

namespace LocalRepositoryApplication
{
    class LocalTraceWriter : ITraceWriter
    {

        private MainScreen main;

        public LocalTraceWriter(MainScreen main)
        {
            this.main = main;
        }


        private void log(string message)
        {
            this.main.log(message);
            Console.WriteLine(message);
        }

        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {

            if ("Info".Equals(level.ToString()))
            { 
            if ("System.Web.Http.Request".Equals(category))
            {
                    if ("<TraceBeginEndAsync>b__e".Equals(traceAction.Method.Name))
                    log(request.Method+" "+ request.RequestUri);
                }
            }

        }
    }
}
