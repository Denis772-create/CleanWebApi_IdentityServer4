using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasks.Domain.Entities;

namespace Tasks.Application.Interfaces
{
    public interface IMyTasksDbContext
    {
        DbSet<MyTask> MyTasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
