using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Shared.Models;
using ToDo.ApiService.Services;
using ToDo.Shared.Interfaces;

namespace ToDo.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
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
        public ActionResult Post([FromBody] string name)
        {
            return _todoService.AddTask(name) is TodoItem newItem
                ? CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem)
                : BadRequest("Failed to add task.");
        }

        [HttpPut]
        public ActionResult Put([FromBody] int id)
        {
            var updatedItem = _todoService.UpdateTask(id);
            if (updatedItem == null)
            {
                return NotFound();
            }
            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _todoService.DeleteTask(id);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
