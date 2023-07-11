using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Data;
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
}
