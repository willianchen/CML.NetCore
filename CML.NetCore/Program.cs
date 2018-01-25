using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using CML.Lib.Configurations;
using CML.Lib.Json;
using CML.Lib.Logging;

namespace CML.NetCore
{
    class Program
    {
        //  private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        static readonly IInternalLogger Logger = InternalLoggerFactory.GetInstance(typeof(Program));
        private static readonly IJsonSerialize Json = JsonSerializerFactory.GetInstance();

        static void Main(string[] args)
        {

            ConfigurationHelper.SetConsoleLogger();
            Logger.Info("test info logger");
            Logger.Error(new Exception("测试"));

            User info = new User() { UserID = 1, userName = "asdfasdf" };

            var jsonString = Json.GetJsonByObj(info);

          //  Console.WriteLine(jsonString);

            Logger.Info("test info Json {0}",jsonString);

            Console.ReadLine();

        }

        //// This method gets called by the runtime. Use this method to add services to the container.
        //public static IServiceProvider ConfigureServices(IServiceCollection services)
        //{
        //    //services.AddLogging();

        //    //var containerBuilder = new ContainerBuilder();

        //    //ContainerManager.UseAutofacContainer(containerBuilder).RegisterType<Runner>();

        //var serviceProvider = ContainerManager.Instance.RegisterProvider(services);
        //ILoggerFactory loggerFactory = ContainerManager.Resolve<ILoggerFactory>();
        //loggerFactory.AddNLog(); //notice: the project's only line of code referencing NLog (aside from .config)
        //    loggerFactory.ConfigureNLog("nlog.config");
        //    return serviceProvider;

        //}

    }

    public class Runner
    {
        private readonly ILogger<Runner> _logger;

        public Runner(ILogger<Runner> logger)
        {
            _logger = logger;
        }

        public void DoActionAsync(string name)
        {
            _logger?.LogInformation("Starting work.");

            for (int i = 0; i <= 100; i += 20)
            {
                // await Task.Delay(TimeSpan.FromSeconds(1));
                _logger?.LogDebug($"Completed {i}% of work");
            }

            _logger?.LogInformation("Finished work.");

        }


    }

    public class User
    {
        public int UserID { get; set; }

        public string userName { get; set; }
    }
}