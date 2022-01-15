using System;
using FluentValidation;

namespace Tasks.Application.MyTasks.Comands.DeleteMyTask
{
    public class DeleteMyTaskCommandValidator : AbstractValidator<DeleteMyTaskCommand>
    {
        public DeleteMyTaskCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
            RuleFor(command => command.UserId).NotEqual(Guid.Empty);

        }
    }
}
