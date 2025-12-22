using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFlow.Core.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<TaskItem> Tasks { get; set; }
    }
}
