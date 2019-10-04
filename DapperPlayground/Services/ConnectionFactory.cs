using DapperPlayground.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperPlayground.Services
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _config;

        public ConnectionFactory(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection GetOpenConnection()
        {
            var connection = new SqlConnection(_config.GetConnectionString("DapperPlaygroundShop"));
            connection.Open();
            return connection;
        }
    }
}
