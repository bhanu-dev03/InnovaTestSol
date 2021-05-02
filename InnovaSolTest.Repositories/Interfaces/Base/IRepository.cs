using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSolTest.Repositories.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task UpdateAsync(T entity);

    }
}
