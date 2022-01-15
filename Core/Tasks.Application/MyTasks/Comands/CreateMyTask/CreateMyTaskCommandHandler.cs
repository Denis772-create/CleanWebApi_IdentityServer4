using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tasks.Application.Interfaces;
using Tasks.Domain.Entities;

namespace Tasks.Application.MyTasks.Comands.CreateMyTask
{
    public class CreateMyTaskCommandHandler : IRequestHandler<CreateMyTaskCommand, Guid>
    {
        private readonly IMyTasksDbContext _context;

        public CreateMyTaskCommandHandler(IMyTasksDbContext context)=>
            _context = context;

        public async Task<Guid> Handle(CreateMyTaskCommand request, CancellationToken cancellationToken)
        {
            var myTask = new MyTask
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _context.MyTasks.AddAsync(myTask, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return myTask.Id;
        }
    }
}
