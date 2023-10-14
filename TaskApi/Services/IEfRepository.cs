using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApi.Entities;

namespace TaskApi.Services
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(long id);
        Task<long> Add(T entity);
    }
}
