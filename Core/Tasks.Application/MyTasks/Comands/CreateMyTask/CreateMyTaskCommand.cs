using System;
using MediatR;

namespace Tasks.Application.MyTasks.Comands.CreateMyTask
{
    public class CreateMyTaskCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

    }
}
