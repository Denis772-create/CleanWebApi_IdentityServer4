using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Interfaces;
using Tasks.Domain.Entities;
using Tasks.Infrastructure.Configurations;

namespace Tasks.Infrastructure
{
    public class MyTasksDbContext : DbContext, IMyTasksDbContext
    {
        public DbSet<MyTask> MyTasks { get; set; }

        public MyTasksDbContext(DbContextOptions<MyTasksDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MyTaskConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
