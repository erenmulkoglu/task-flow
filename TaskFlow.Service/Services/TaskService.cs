using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.DTOs.Task;
using TaskFlow.Core.Entities;
using TaskFlow.Core.Interfaces;

namespace TaskFlow.Service.Services
{
    public class TaskService : ITaskService
    {

        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto, int userId)
        {
            var task = new TaskItem
            {
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,
                DueDate = createTaskDto.DueDate,
                Status = createTaskDto.Status,
                Priority = createTaskDto.Priority,
                CategoryId = createTaskDto.CategoryId,
                UserId = userId,
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(task);
        }
        public async Task<bool> DeleteTaskAsync(int taskId, int userId)
        {
            var task = await _unitOfWork.Tasks.FirstOrDefaultAsync(
                t => t.Id == taskId && t.UserId == userId);

            if (task == null)
                return false;

            _unitOfWork.Tasks.Remove(task);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync(int userId)
        {
            var tasks = await _unitOfWork.Tasks.FindAsync(t => t.UserId == userId);
            return tasks.Select(MapToDto);
        }
        public async Task<TaskDto> GetTaskByIdAsync(int taskId, int userId)
        {
            var task = await _unitOfWork.Tasks.FirstOrDefaultAsync(
                t => t.Id == taskId && t.UserId == userId);

            if (task == null)
                throw new Exception("Task not found");

            return MapToDto(task);
        }
        public async Task<IEnumerable<TaskDto>> GetTasksByCategoryAsync(int categoryId, int userId)
        {
            var tasks = await _unitOfWork.Tasks.FindAsync(
                t => t.CategoryId == categoryId && t.UserId == userId);

            return tasks.Select(MapToDto);
        }
        public async Task<IEnumerable<TaskDto>> GetTasksByStatusAsync(int status, int userId)
        {
            var tasks = await _unitOfWork.Tasks.FindAsync(
                t => (int)t.Status == status && t.UserId == userId);

            return tasks.Select(MapToDto);
        }
        public async Task<TaskDto> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto, int userId)
        {
            var task = await _unitOfWork.Tasks.FirstOrDefaultAsync(
                t => t.Id == taskId && t.UserId == userId);

            if (task == null)
                throw new Exception("Task not found");

            if (!string.IsNullOrEmpty(updateTaskDto.Title))
                task.Title = updateTaskDto.Title;

            if (updateTaskDto.Description != null)
                task.Description = updateTaskDto.Description;

            if (updateTaskDto.DueDate.HasValue)
                task.DueDate = updateTaskDto.DueDate;

            if (updateTaskDto.Status.HasValue)
                task.Status = updateTaskDto.Status.Value;

            if (updateTaskDto.Priority.HasValue)
                task.Priority = updateTaskDto.Priority.Value;

            if (updateTaskDto.CategoryId.HasValue)
                task.CategoryId = updateTaskDto.CategoryId;

            task.UpdatedAt = DateTime.Now;

            _unitOfWork.Tasks.Update(task);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(task);
        }
        private TaskDto MapToDto(TaskItem task)
        {
            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Status = task.Status,
                Priority = task.Priority,
                CategoryId = task.CategoryId,
                CategoryName = task.Category?.Name,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt
            };
        }
    }
}
