using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IBaseRepositoryService<T> where T : class
    {
        Task<List<T>> List();

        Task<T> GetDetails(object id);

        Task Create(T item);

        Task Edit(object id, T item);

        Task Delete(object id);
    }
}