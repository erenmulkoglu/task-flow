using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFlow.Core.Entities
{
    public class User:BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<TaskItem>Tasks { get; set; }

    }
}
