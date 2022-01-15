using System;
using MediatR;

namespace Tasks.Application.MyTasks.Queries.GetMyTasksList
{
    public class GetMyTaskListQuery : IRequest<MyTasksListVm>
    {
        public Guid UserId { get; set; }
    }
}
