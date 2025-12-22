using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.Entities;
using TaskFlow.Core.Interfaces;
using TaskFlow.Data.Context;

namespace TaskFlow.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<User> Users { get; private set; }
        public IRepository<TaskItem> Tasks { get; private set; }
        public IRepository<Category> Categories { get; private set; }
        public IRepository<TaskAttachment> TaskAttachment { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Users = new Repository<User>(_context);
            Tasks = new Repository<TaskItem>(_context);
            Categories = new Repository<Category>(_context);
            TaskAttachment = new Repository<TaskAttachment>(_context);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
