using System;
using FluentValidation;

namespace Tasks.Application.MyTasks.Queries.GetMyTasksList
{
    public class GetMyTaskListQueryValidator : AbstractValidator<GetMyTaskListQuery>
    {
        public GetMyTaskListQueryValidator()
        {
            RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        }
    }
}
