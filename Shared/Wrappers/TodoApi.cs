using System.Net.Http.Json;
using Todo.Shared.Models;

namespace ToDo.Shared.Wrappers
{
    public class TodoApi
    {
        private readonly HttpClient _httpClient;

        public TodoApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public virtual async Task<List<TodoItem>> GetTasks()
        {
            Console.WriteLine("Reached here in TodoApi");

            var result = await _httpClient.GetFromJsonAsync<List<TodoItem>>("api/todo");
            if (result != null)
            {
                return result;
            }
            return new List<TodoItem>(); // Handle potential null values
        }

        public async Task<string> GetTask(int id)
        {
            var item = await _httpClient.GetFromJsonAsync<TodoItem>($"api/todo/{id}");
            return item?.Name ?? string.Empty; // Handle potential null values
        }

        public virtual async Task<string> AddTask(string name)
        {
            var response = await _httpClient.PostAsJsonAsync("api/todo", name);
            var item = await response.Content.ReadFromJsonAsync<TodoItem>();
            return item?.Name ?? string.Empty; // Handle potential null values
        }

        public async Task<TodoItem?> UpdateTask(int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/todo", id);
            var item = await response.Content.ReadFromJsonAsync<TodoItem>();
            if (item != null)
            {
                return item;
            }
            return null; // Handle potential null values
        }

        public async Task<bool> DeleteTask(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/todo/{id}");
            return response.IsSuccessStatusCode; // Simplified return
        }
    }
}
