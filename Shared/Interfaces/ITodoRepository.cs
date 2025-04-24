using Todo.Shared.Models;

namespace ToDo.Shared.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetTasks();
        Task<TodoItem>? GetTask(int id);
        Task<TodoItem> AddTask(TodoItem item);
        Task<TodoItem>? UpdateTask(int id);
        Task<bool> DeleteTask(int id);
    }
}
