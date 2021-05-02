using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace InnovaSolTestData
{
    public sealed class SqlDbProvider : IDbProvider
    {
        private readonly string _connectionString;
        public SqlDbProvider(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("InnovaDbConnection");
        }
        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
