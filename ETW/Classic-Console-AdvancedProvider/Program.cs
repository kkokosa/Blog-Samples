using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Classic_Console_AdvancedProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            while (true)
            {
                Console.WriteLine("Enter command:");
                string command = Console.ReadLine();
                MySampleEventAdvancedProvider.Log.CommandEntered(index, command);
                Thread.Sleep(1000);
                MySampleEventAdvancedProvider.Log.CommandProcessed(index, "Succeeded");
                index++;
            }
        }
    }

    [EventSource(Name = "MySampleEventAdvancedProvider-General")]
    sealed class MySampleEventAdvancedProvider : EventSource
    {
        [Event(1, Keywords = Keywords.Commands)]
        public void CommandEntered(long commandId, string Name)
        {
            WriteEvent(1, commandId, Name);
        }

        [Event(2, Keywords = Keywords.Commands)]
        public void CommandProcessed(long commandId, string Result)
        {
            WriteEvent(2, commandId, Result);
        }

        public class Keywords
        {
            public const EventKeywords Commands = (EventKeywords)0x0001;
            public const EventKeywords Debug = (EventKeywords)0x0002;
        }

        public static MySampleEventAdvancedProvider Log = new MySampleEventAdvancedProvider();
    }
}
