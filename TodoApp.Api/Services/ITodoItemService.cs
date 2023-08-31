using TodoApp.Api.Data;
using TodoApp.Api.DTOs;

namespace TodoApp.Api.Services
{
    public interface ITodoItemService
    {
        IQueryable<TodoItemDto> GetAll();

        TodoItemDto? GetById(int id);

        int? Create(string description, bool isCompleted = false);

        void Update(int id, string description, bool isCompleted);

        void Delete(int id);

        void Complete(int id);
    }
}
