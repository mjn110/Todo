using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using ToDo.ApiService.Services;

namespace ToDo.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;
        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> Get()
        {
            var items = _todoService.GetTasks();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var item = _todoService.GetTask(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public ActionResult Add([FromBody] string name)
        {
            return _todoService.AddTask(name) is TodoItem newItem
                ? CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem)
                : BadRequest("Failed to add task.");
        }
    }
}
