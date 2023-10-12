using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Entities;
//added
using Microsoft.EntityFrameworkCore;
namespace TaskApi.Models
{
    public class MemDbContext : DbContext
    {
        public MemDbContext(DbContextOptions<MemDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
