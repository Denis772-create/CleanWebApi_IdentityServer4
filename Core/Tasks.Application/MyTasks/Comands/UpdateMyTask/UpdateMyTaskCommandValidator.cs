using System;
using FluentValidation;

namespace Tasks.Application.MyTasks.Comands.UpdateMyTask
{
    public class UpdateMyTaskCommandValidator : AbstractValidator<UpdateMyTaskCommand>
    {
        public UpdateMyTaskCommandValidator()
        {
            RuleFor(command => command.UserId).NotEqual(Guid.Empty);
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
            RuleFor(command => command.Title)
                .NotEmpty().MaximumLength(250);

        }
    }
}
