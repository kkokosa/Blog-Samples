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
                MySampleEventAdvancedProvider.Log.CommandStart(index, command);
                ProcessCommand(index, command);
                MySampleEventAdvancedProvider.Log.CommandStop(index, "Succeeded");
                index++;
            }
        }

        private static void ProcessCommand(long commandId, string command)
        {
            Parallel.For(0, 100, index =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    MySampleEventAdvancedProvider.Log.CommandProcessing(
                        commandId,
                        $"Command {command} processing step {i}");
                }
            });
            
        }
    }

    [EventSource(Name = "4Developers-MySampleEventAdvancedProvider-General")]
    sealed class MySampleEventAdvancedProvider : EventSource
    {
        [Event(1, Keywords = Keywords.Commands)]
        public void CommandStart(long commandId, string Name)
        {
            WriteEvent(1, commandId, Name);
        }

        [Event(2, Keywords = Keywords.Commands)]
        public void CommandStop(long commandId, string Result)
        {
            WriteEvent(2, commandId, Result);
        }

        [Event(3, Keywords = Keywords.Debug)]
        public void CommandProcessing(long commandId, string Message)
        {
            WriteEvent(3, commandId, Message);
        }

        public class Keywords
        {
            public const EventKeywords Commands = (EventKeywords)0x0001;
            public const EventKeywords Debug = (EventKeywords)0x0002;
        }

        public static MySampleEventAdvancedProvider Log = new MySampleEventAdvancedProvider();
    }
}
