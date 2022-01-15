using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Interfaces;

namespace Tasks.Application.MyTasks.Queries.GetMyTasksList
{
    public class GetMyTaskListQueryHandler : IRequestHandler<GetMyTaskListQuery, MyTasksListVm>
    {
        private readonly IMyTasksDbContext _context;
        private readonly IMapper _mapper;

        public GetMyTaskListQueryHandler(IMyTasksDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MyTasksListVm> Handle(GetMyTaskListQuery request, CancellationToken cancellationToken)
        {
            var listMyTasks = await _context.MyTasks
                .Where(mt => mt.UserId == request.UserId)
                .ProjectTo<MyTaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MyTasksListVm { MyTasks = listMyTasks };
        }
    }
}
