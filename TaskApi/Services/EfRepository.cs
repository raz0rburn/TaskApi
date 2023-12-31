using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Entities;
using TaskApi.Models;
namespace TaskApi.Services
{
    public class UserRepository<T> : IEfRepository<T> where T : BaseEntity
    {
        private readonly dbContext _context;
        public UserRepository(dbContext context)
        {
            _context = context;
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(long id)
        {
            var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return null;
            }

            return result;
        }
        public async Task<long> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
