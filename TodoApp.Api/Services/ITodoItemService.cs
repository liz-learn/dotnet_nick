using TodoApp.Api.Data;

namespace TodoApp.Api.Services
{
    public interface ITodoItemService
    {
        IQueryable<TodoItem> GetAll();

        TodoItem? GetById(int id);

        int? Create(string description, bool isCompleted = false);

        void Update(int id, string description, bool isCompleted);

        void Delete(int id);

        void Complete(int id);
    }
}
