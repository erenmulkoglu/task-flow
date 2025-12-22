using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFlow.Core.Entities
{
    public class TaskItem: BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public TaskStatus Status { get; set; }

        public TaskPriority Priority { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<TaskAttachment> Attachments { get; set; }
    }

        public enum TaskStatus
        {
        Todo = 0,
        InProgress = 1,
        Completed = 2,
        Canceled = 3
        }
    public enum TaskPriority
    {
        Low = 0,
        Medium = 1,
        Hight = 2,
        Urgent = 3
    }
}
