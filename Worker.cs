using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RiseFoodServiceWork.Services.LocalDatabase;
using RiseFoodServiceWork.Services.RemoteDatabase;

namespace RiseFoodServiceWork
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ILocalDatabaseService _localDatabaseService;
        private readonly IRemoteDatabaseService _remoteDatabaseService;

        public Worker(ILogger<Worker> logger,
            ILocalDatabaseService localDatabaseService, 
            IRemoteDatabaseService remoteDatabaseService)
        {
            _logger = logger;
            _localDatabaseService = localDatabaseService;
            _remoteDatabaseService = remoteDatabaseService;
        }
    

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_remoteDatabaseService.IsCollectionExist())
                _logger.LogInformation("The supplies collection already exist.");
            
            
            
            else
            {
                _logger.LogInformation("The supplies collection will be create.");
                foreach (var supplie in await _localDatabaseService.GetAllSupplies())
                {
                    await _remoteDatabaseService.SaveSupplie(supplie);
                }
            }
            
           


        }
    }
}
