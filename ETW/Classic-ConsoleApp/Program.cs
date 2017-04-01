using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classic_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter command:");
                string command = Console.ReadLine();
                MySampleEventProvider.Log.Command(7, command);
            }
        }
    }

    sealed class MySampleEventProvider : EventSource
    {
        public void Command(long commandId, string Name)
        {
            WriteEvent(1, commandId, Name);
        }

        public static MySampleEventProvider Log = new MySampleEventProvider();
    }
}
