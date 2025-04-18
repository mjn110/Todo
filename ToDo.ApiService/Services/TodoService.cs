using Shared.Models;

namespace ToDo.ApiService.Services
{
    public class TodoService
    {
        private readonly List<TodoItem> _items = new();

        public List<TodoItem> GetTasks()
        {
            return _items;
        }

        public TodoItem? GetTask(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public TodoItem AddTask(string name)
        {
            var newItem = new TodoItem
            {
                Id = _items.Count + 1,
                Name = name,
                IsCompleted = false
            };
            _items.Add(newItem);
            return newItem;
        }

        public TodoItem? UpdateTask(int id, string name)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Name = name;
                return item;
            }
            return null;
        }
    }
}
