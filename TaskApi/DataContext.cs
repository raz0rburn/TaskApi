using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskApi.Entities;

namespace TaskApi
{
    public class DataContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}