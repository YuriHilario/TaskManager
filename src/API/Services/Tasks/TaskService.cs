using API.Interfaces.Repositories;
using API.Interfaces.Services;
using API.Models;

namespace API.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateTaskAsync(TaskItem task)
        {
            await _repository.AddAsync(task);
        }

        public async Task<bool> UpdateTaskAsync(TaskItem task)
        {
            var existing = await _repository.GetByIdAsync(task.id);
            if (existing == null)
                return false;

            existing.title = task.title;
            existing.description = task.description;
            existing.priority = task.priority;
            existing.status = task.status;

            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null)
                return false;

            await _repository.DeleteAsync(task);
            return true;
        }
    }
}
