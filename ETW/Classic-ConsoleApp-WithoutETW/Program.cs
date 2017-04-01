using NLog;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classic_ConsoleApp_WithoutETW
{
    class Program
    {
        static void Main(string[] args)
        {
            Logging1();
            Logging2();
            Logging3();
        }

        static void Logging1()
        {
            try
            {
                Console.WriteLine("Starting to process...");
                var result = ProcessSomething();
                if (result > 0)
                {
                    Console.WriteLine("Pies1 " + result);
                    ProcessMore();
                    Console.WriteLine("Pies2");
                    ProcessWithException(result);
                    Console.WriteLine("Pies3");
                }
                Console.WriteLine("Processing ended.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ojojoj... {ex.Message}");
            }
        }


        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Logging2()
        {
            try
            {
                logger.Info("Starting to process...");
                var result = ProcessSomething();
                if (result > 0)
                {
                    logger.Debug($"Pies1 {result}");
                    ProcessMore();
                    logger.Debug("Pies2");
                    ProcessWithException(result);
                    logger.Debug("Pies3");
                }
                logger.Info("Processing ended.");
            }
            catch (Exception ex)
            {
                logger.Error($"Ojojoj... {ex.Message}");
            }
        }

        static void Logging3()
        {
            Log.Logger = new LoggerConfiguration()
                             .MinimumLevel.Debug()
                             .WriteTo.LiterateConsole()
                             .WriteTo.RollingFile("logs-serilog.txt")
                             .CreateLogger();
            try
            {
                Log.Information("Starting to process...");
                var result = ProcessSomething();
                if (result > 0)
                {
                    var debugData = new { Result = result, IsHappy = true };
                    Log.Debug("Pies1 {@data}", debugData);
                    ProcessMore();
                    Log.Debug("Pies2");
                    ProcessWithException(result);
                    Log.Debug("Pies3");
                }
                logger.Trace("Processing ended.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ojojoj...");
            }
            Log.CloseAndFlush();
        }

        private static void ProcessMore()
        {
            
        }

        private static int ProcessSomething()
        {
            return 10;
        }

        private static void ProcessWithException(int result)
        {
            throw new ArgumentOutOfRangeException("result", result, "Not supported value");
        }
    }
}
