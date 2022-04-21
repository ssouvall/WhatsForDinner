using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IBaseRepositoryService<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetDetails(object id);

        Task Create(T item);

        Task Edit(T editedItem, T item);

        Task Delete(object id);
        
        // Task ManyToManyAccess(T entity1, object entityTwoId);
    }
}