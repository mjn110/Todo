using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Shared.Models;

namespace ToDo.Shared.Interfaces
{
    public interface ITodoService
    {
        List<TodoItem> GetTasks();
        TodoItem? GetTask(int id);
        TodoItem AddTask(string name);
        TodoItem? UpdateTask(int id);
        bool DeleteTask(int id);
    }
}
