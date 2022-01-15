using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Common.Exeptions;
using Tasks.Application.Interfaces;
using Tasks.Domain.Entities;

namespace Tasks.Application.MyTasks.Queries.GetMyTaskDetails
{
    public class GetMyTaskDetailsQueryHandler : IRequestHandler<GetMyTaskDetailsQuery, MyTaskDetailsVm>
    {
        private readonly IMyTasksDbContext _context;
        private readonly IMapper _mapper;

        public GetMyTaskDetailsQueryHandler(IMyTasksDbContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);

        public async Task<MyTaskDetailsVm> Handle(GetMyTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.MyTasks.FirstOrDefaultAsync(myTask =>
                myTask.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
                throw new NotFoundException(nameof(MyTask), request.Id);

            return _mapper.Map<MyTaskDetailsVm>(entity);
        }
    }
}
