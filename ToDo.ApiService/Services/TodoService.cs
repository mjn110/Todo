using Todo.Shared.Models;
using ToDo.Shared.Interfaces;

namespace ToDo.ApiService.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<TodoItem> _items = new();
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public List<TodoItem> GetTasks()
        {
            return _todoRepository.GetTasks().Result;
        }

        public TodoItem? GetTask(int id)
        {
            return _todoRepository.GetTask(id)?.Result;
        }

        public TodoItem AddTask(string name)
        {
            var newItem = new TodoItem
            {
                Id = GetTasks().Count,
                Name = name,
                IsCompleted = false
            };
            _todoRepository.AddTask(newItem);
            return newItem;
        }

        public TodoItem? UpdateTask(int id)
        {
            var item = _todoRepository.UpdateTask(id)?.Result;
            return item;
        }

        public bool DeleteTask(int id)
        {
            var result = _todoRepository.DeleteTask(id)?.Result ?? false;
            return result;
        }
    }
}
