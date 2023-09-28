using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//added
using Microsoft.EntityFrameworkCore;
namespace TaskApi.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {

        }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
