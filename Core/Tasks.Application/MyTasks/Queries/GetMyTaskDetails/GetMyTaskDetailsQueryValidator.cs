using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Tasks.Application.MyTasks.Queries.GetMyTaskDetails
{
    public class GetMyTaskDetailsQueryValidator : AbstractValidator<GetMyTaskDetailsQuery>
    {
        public GetMyTaskDetailsQueryValidator()
        {
            RuleFor(query => query.Id).NotEqual(Guid.Empty);
            RuleFor(query => query.UserId).NotEqual(Guid.Empty);

        }
    }
}
