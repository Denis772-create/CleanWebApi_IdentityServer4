using System;
using FluentValidation;

namespace Tasks.Application.MyTasks.Comands.CreateMyTask
{
    public class CreateMyTaskCommandValidator : AbstractValidator<CreateMyTaskCommand>
    {
        public CreateMyTaskCommandValidator()
        {
            RuleFor(command =>
                command.Title).NotEmpty().MaximumLength(250);
            RuleFor(command =>
                command.UserId).NotEqual(Guid.Empty);
        }
    }
}
