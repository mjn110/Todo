using Todo.Shared.Models;

namespace ToDo.Web.Interfaces
{
    public interface ITodoApi
    {
        Task<List<TodoItem>> GetTasks();
        Task<string> GetTask(int id);
        Task<string> AddTask(string name);
        Task<TodoItem?> UpdateTask(int id);
        Task<bool> DeleteTask(int id);
    }
}
