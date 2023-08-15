namespace TodoApp.Api.DTOs;

public class TodoItemDto
{
    public string Description { get; set; } = null!;
    public bool IsComplete { get; set;  }
}