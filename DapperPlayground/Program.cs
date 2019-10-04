using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DapperPlayground.Entities;
using DapperPlayground.Interfaces;
using DapperPlayground.Repositories;
using DapperPlayground.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DapperPlayground
{
    class Program
    {
        public class ConsoleApplication
        {
            private readonly IUserRepository _userRepository;

            public ConsoleApplication(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task Main()
            {
                Console.WriteLine("ConsoleApplication Started...");

                IEnumerable<User> users = await _userRepository.AllAsync();

                Console.WriteLine($"Users count: {users.Count()}");

                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            // Register application entry point
            var app = serviceProvider.GetService<ConsoleApplication>();
            // Run application and wait until it finishes work
            app.Main().Wait();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var config = LoadConfiguration();
            services.AddSingleton(config);

            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ConsoleApplication>();

            return services;
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
