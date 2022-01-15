using System;
using MediatR;
using Tasks.Application.MyTasks.Queries.GetMyTaskDetails;

namespace Tasks.Application.MyTasks.Queries
{
    public class GetMyTaskDetailsQuery : IRequest<MyTaskDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
