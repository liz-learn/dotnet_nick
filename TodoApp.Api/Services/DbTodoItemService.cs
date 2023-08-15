using TodoApp.Api.Data;

namespace TodoApp.Api.Services;

public class DbTodoItemService : ITodoItemService
{
    private readonly ILogger<DbTodoItemService> _logger;
    private readonly ApplicationContext _context;

    public DbTodoItemService(ILogger<DbTodoItemService> logger, ApplicationContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IQueryable<TodoItem> GetAll()
    {
        _logger.LogInformation("Getting all todo items");
        return _context.TodoItems;
    }

    public TodoItem? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public int? Create(string description, bool isCompleted = false)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, string description, bool isCompleted)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Complete(int id)
    {
        throw new NotImplementedException();
    }
}