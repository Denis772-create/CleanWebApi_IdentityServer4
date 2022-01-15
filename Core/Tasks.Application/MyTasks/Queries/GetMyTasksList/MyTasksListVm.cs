using System.Collections.Generic;

namespace Tasks.Application.MyTasks.Queries.GetMyTasksList
{
    public class MyTasksListVm
    {
        public IList<MyTaskLookupDto> MyTasks { get; set; }

    }
}
