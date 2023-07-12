using TodoApp.Api.Data;

namespace TodoApp.Api.Services
{
    public class TodoItemService : ITodoItemService
    {
        private static List<TodoItem> _todoItems = new()
        {
            new TodoItem {Id = 1, Description = "Feed cats breakfast"},
            new TodoItem {Id = 2, Description = "Feed cats dinner"}
        };

        public void Complete(int id)
        {
            var target = _todoItems.SingleOrDefault(x => x.Id == id);
            if (target == null)
                return;
            target.IsCompleted = true;
        }

        public int? Create(string description, bool isCompleted = false)
        {
            if (string.IsNullOrWhiteSpace(description))
                return null;
            var id = _todoItems.Max(x => x.Id + 1);
            var todoItem = new TodoItem{
                Id = id,
                Description = description,
                CreatedAt = DateTime.UtcNow,
                IsCompleted = isCompleted
            };
            _todoItems.Add(todoItem);
            return id;
        }

        public void Delete(int id)
        {
            TodoItem? target = _todoItems.SingleOrDefault(x => x.Id == id);
            if (target is null)
                return;
            _todoItems.Remove(target);
        }

        public IQueryable<TodoItem> GetAll()
        {
            return _todoItems.AsQueryable();
        }

        public TodoItem? GetById(int id)
        {
            return _todoItems.SingleOrDefault(x => x.Id == id);
        }

        public void Update(int id, string description, bool isCompleted)
        {
            TodoItem? target = _todoItems.SingleOrDefault(x => x.Id == id);
            if (target is null)
                return;
            target.Description = description;
            target.IsCompleted = isCompleted;
        }
    }
}
