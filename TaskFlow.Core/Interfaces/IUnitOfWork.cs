using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.Entities;

namespace TaskFlow.Core.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<TaskItem> Tasks { get; }
        IRepository<Category>Categories { get; }
        IRepository<TaskAttachment> TaskAttachment { get; }

        Task<int> SaveChangesAsync();
    }
}
