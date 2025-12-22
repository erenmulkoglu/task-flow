using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFlow.Core.Entities
{
    public class TaskAttachment:BaseEntity
    {
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public long FileSize { get; set; }

        public string ContentType { get; set; }

        public int TaskId { get; set; }

        public TaskItem Task { get; set; }


    }
}
