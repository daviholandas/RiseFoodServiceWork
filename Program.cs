using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using RiseFoodServiceWork.Extensions;
using RiseFoodServiceWork.Services.LocalDatabase;
using RiseFoodServiceWork.Services.RemoteDatabase;

namespace RiseFoodServiceWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<ILocalDatabaseService, LocalDatabaseService>();
                    services.AddSingleton<IRemoteDatabaseService, RemoteDatabaseService>();
                    services.AddSingleton(c => new MySqlConnection("Server=localhost;Port=3309;Database=restodba;User=root;Password=;"));
                    services.MapperModels();
                });
    }
}
