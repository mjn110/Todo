using Todo.Shared.Models;
using ToDo.Shared.Wrappers;


namespace ToDo.Web.MockApis
{
    public class MockTodoApi : TodoApi
    {
        public MockTodoApi() : base(new HttpClient()) { }

        private List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem { },
            };

        // Uncommented and fixed methods for functionality
        public override async Task<List<TodoItem>> GetTasks()
        {
            return await Task.FromResult(items);
        }

        public override async Task<string> AddTask(string name)
        {
            var newItem = new TodoItem { Id = items.Count + 1, Name = name, IsCompleted = false };
            items.Add(newItem);
            return await Task.FromResult(newItem.Name);
        }
    }
}
