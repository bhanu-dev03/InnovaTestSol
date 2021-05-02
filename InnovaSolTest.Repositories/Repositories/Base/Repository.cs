using InnovaSolTest.Repositories.Interfaces.Base;
using InnovaSolTestData;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using InnovaSolTest.Common.Constants;

namespace InnovaSolTest.Repositories.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly string _tableName;
        protected readonly IDbProvider _dbProvider;
        protected readonly IConfiguration _configuration;

        public Repository(IConfiguration configuration, IDbProvider dbProvider)
        {
            _configuration = configuration;
            _dbProvider = dbProvider;
            _tableName = "[" + typeof(T).Name + "]";
        }

        public async Task<T> GetAsync(int id)
        {
            T result;
            var query = RepositoryConstants.Get;
            query = string.Format(query, _tableName, id);
            using (var conn = _dbProvider.GetDbConnection())
            {
                conn.Open();
                result = await conn.QueryFirstOrDefaultAsync(query);
            }
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {

            IEnumerable<T> result;
            var query = RepositoryConstants.GetAll;
            query = string.Format(query, _tableName);
            using (var conn = _dbProvider.GetDbConnection())
            {
                conn.Open();
                result = await conn.QueryAsync<T>(query);
            }
            return result;
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
