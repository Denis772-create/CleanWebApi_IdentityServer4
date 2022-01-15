using System;
using MediatR;

namespace Tasks.Application.MyTasks.Comands.DeleteMyTask
{
    public class DeleteMyTaskCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }

    }
}
