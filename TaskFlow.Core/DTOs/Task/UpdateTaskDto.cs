using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using TaskFlow.Core.Entities;

namespace TaskFlow.Core.DTOs.Task
{
    public class UpdateTaskDto
    {

        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskStatus? Status { get; set; }
        public TaskPriority? Priority { get; set; }
        public int? CategoryId { get; set; }
    }
}
