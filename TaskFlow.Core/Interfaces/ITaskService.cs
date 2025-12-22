using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.DTOs.Task;

namespace TaskFlow.Core.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasksAsync(int userId);
        Task<TaskDto> GetTaskByIdAsync(int taskId, int userId);
        Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto, int userId);
        Task<TaskDto> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto, int userId);
        Task<bool> DeleteTaskAsync(int taskId, int userId);
        Task<IEnumerable<TaskDto>> GetTasksByCategoryAsync(int categoryId, int userId);
        Task<IEnumerable<TaskDto>> GetTasksByStatusAsync(int status, int userId);

    }
}
