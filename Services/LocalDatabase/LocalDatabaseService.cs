using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using RiseFoodServiceWork.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiseFoodServiceWork.Services.LocalDatabase
{
    public class LocalDatabaseService : ILocalDatabaseService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<LocalDatabaseService> _logger;
        private readonly MySqlConnection _db;


        public LocalDatabaseService(IConfiguration configuration,
            ILogger<LocalDatabaseService> logger,
            MySqlConnection db)
        {
            _configuration = configuration;
            _logger = logger;
            _db = db;
        }

        public async Task<IEnumerable<Supplie>> GetAllSupplies()
        {
            _db.Open();

            var supplies = await _db.QueryAsync<Supplie>("SELECT IN_ID, IN_NOM,IN_COD, IN_VALOR, categoria.SG_NOM as Category FROM restodba.si_insu as insumos inner join restodba.si_s_gru as categoria on insumos.IN_SUBGR = categoria.SG_COD;");    
            
            _db.Close();
            
            return supplies;
            
        }

        
    }
}
