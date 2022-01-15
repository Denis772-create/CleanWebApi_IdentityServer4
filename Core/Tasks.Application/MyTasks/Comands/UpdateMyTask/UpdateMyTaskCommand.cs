using System;
using MediatR;

namespace Tasks.Application.MyTasks.Comands.UpdateMyTask
{
    public class UpdateMyTaskCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

    }
}
