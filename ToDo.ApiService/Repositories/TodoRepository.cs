using Todo.Shared.Models;
using ToDo.Shared.Interfaces;

namespace ToDo.ApiService.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly List<TodoItem> _items = new();

        public async Task<List<TodoItem>> GetTasks()
        {
            //Wrap the result in Task.FromResult to return a Task
            return await Task.FromResult(_items);
        }

        public async Task<TodoItem?> GetTask(int id)
        {
            //Wrap the result in Task.FromResult to return a Task
            return await Task.FromResult(_items.FirstOrDefault(i => i.Id == id));
        }

        public Task<TodoItem> AddTask(TodoItem item)
        {
            _items.Add(item);
            return Task.FromResult(item);
        }

        public async Task<TodoItem?> UpdateTask(int id)
        {
            var existingItem = GetTask(id).Result;
            if (existingItem != null)
            {
                existingItem.IsCompleted = !existingItem.IsCompleted;
                return await Task.FromResult(existingItem);
            }
            return null;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
