using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Common.Exeptions;
using Tasks.Application.Interfaces;
using Tasks.Domain.Entities;

namespace Tasks.Application.MyTasks.Comands.UpdateMyTask
{
    public class UpdateMyTaskCommandHandler : IRequestHandler<UpdateMyTaskCommand>
    {
        private readonly IMyTasksDbContext _dbContext;

        public UpdateMyTaskCommandHandler(IMyTasksDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateMyTaskCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.MyTasks.FirstOrDefaultAsync(note =>
                    note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(MyTask), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
