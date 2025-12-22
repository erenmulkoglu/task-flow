using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskFlow.Core.Entities;

namespace TaskFlow.Core.DTOs.Task
{
    public class CreateTaskDto
    {

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.Todo;

        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public int? CategoryId { get; set; }
    }
}
