using Shared.Models;

namespace ToDo.Web
{
    public class TodoApi(HttpClient httpClient)
    {

        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<TodoItem>> GetTasks()
        {
            return await httpClient.GetFromJsonAsync<List<TodoItem>>("api/todo");
        }

        public async Task<string> GetTask(int id)
        {
            var item = await _httpClient.GetFromJsonAsync<TodoItem>($"api/todo/{id}");
            return item?.Name ?? string.Empty;
        }

        public async Task<string> AddTask(string name)
        {
            var response = await _httpClient.PostAsJsonAsync("api/todo", name);
            var item = await response.Content.ReadFromJsonAsync<TodoItem>();
            return item?.Name ?? string.Empty;
        }

        public async Task<string> UpdateTask(int id, string name)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/todo/{id}", name);
            var item = await response.Content.ReadFromJsonAsync<TodoItem>();
            if (item != null)
            {
                item.Name = name;
                return item.Name;
            }
            return string.Empty;
        }
    }
}
