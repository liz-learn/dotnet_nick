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
        var target = _context.TodoItems.SingleOrDefault(x => x.Id == id);
        if (target is null)
            _logger.LogWarning("No toDo fetched: TodoId, {TodoId}, is invalid", id);
        return target;
    }

    public int? Create(string description, bool isCompleted = false)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            _logger.LogWarning("Empty descriptions not allowed");
            return null;
        }

        var todoItem = new TodoItem{
            Description = description,
            CreatedAt = DateTime.UtcNow,
            IsCompleted = isCompleted
        };
        _context.TodoItems.Add(todoItem);
        _context.SaveChanges();
        return todoItem.Id;
    }

    public void Update(int id, string description, bool isCompleted)
    {
        TodoItem? target = _context.TodoItems.SingleOrDefault(x => x.Id == id);
        if (target is null)
        {
            _logger.LogWarning("Invalid id, {TodoId}, therefore toDo will not be updated", id);
            return;
        }
        target.Description = description;
        target.IsCompleted = isCompleted;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        TodoItem? target = _context.TodoItems.SingleOrDefault(x => x.Id == id);
        if (target is null) {
            _logger.LogWarning("Invalid id, {TodoId}, therefore toDo will be deleted", id);
            return;
        }
        _context.TodoItems.Remove(target);
        _context.SaveChanges();
    }

    public void Complete(int id)
    {
        TodoItem? target = _context.TodoItems.SingleOrDefault(x => x.Id == id);
        if (target is null)
        {
            _logger.LogWarning("Invalid id, {TodoId}, therefore toDo will not be completed", id);
            return;
        }
        target.IsCompleted = true;
        _context.SaveChanges();
    }
}