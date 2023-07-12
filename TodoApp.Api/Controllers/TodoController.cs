using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Data;
using TodoApp.Api.Models;
using TodoApp.Api.Services;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoItemService _todoItemService;

    public TodoController(ITodoItemService todoItemService)
    {
        _todoItemService = todoItemService;
    }

    [HttpGet(Name = nameof(GetAllTodos))]
    public ActionResult<IEnumerable<TodoItem>> GetAllTodos()
    {
        return Ok(_todoItemService.GetAll());
    }
    
    [HttpGet("{id:int}", Name = nameof(GetTodoById))]
    public ActionResult<TodoItem> GetTodoById(int id)
    {
        var todo = _todoItemService.GetById(id);
        if (todo is null)
            return NotFound();
        return Ok(todo);
    }

    [HttpPost(Name = nameof(CreateTodoItem))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateTodoItem([FromBody] CreateTodoItemViewModel model)
    {
        var createdId = _todoItemService.Create(model.Description, model.IsCompleted);
        if (createdId is null)
            ModelState.AddModelError(nameof(model.Description), "Todo description is required");
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return CreatedAtRoute(nameof(GetTodoById), new { id = createdId!.Value }, null);
    }
    
    [HttpPut("{id:int}", Name = nameof(UpdateTodoItem))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateTodoItem(int id, [FromBody] UpdateTodoItemViewModel model)
    {
        _todoItemService.Update(id, model.Description, model.IsCompleted);
        return NoContent();
    }
}
