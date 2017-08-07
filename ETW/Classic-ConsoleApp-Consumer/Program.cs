using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Parsers;
using Microsoft.Diagnostics.Tracing.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Classic_ConsoleApp_Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = new TraceEventSession("MyRealTimeSession")) 
            {
                session.Source.Dynamic.All += delegate (TraceEvent data)
                {
                    Console.WriteLine("GOT Event " + data);
                };

                var eventSourceGuid = TraceEventProviders.GetEventSourceGuidFromName("MySampleEventProvider");
                session.EnableProvider(eventSourceGuid);
                session.Source.Process();
            }
        }
    }
}
