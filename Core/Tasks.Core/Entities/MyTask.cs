using System;

namespace Tasks.Domain.Entities
{
    public class MyTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public Guid UserId { get; set; }

    }
}
