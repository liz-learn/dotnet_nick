using System.ComponentModel.DataAnnotations;

namespace TodoApp.Api.Models;

public class TodoItemViewModel
{
    [Required]
    [MinLength(3, ErrorMessage = "Your todo item must be at least 3 characters.")]
    public string Description { get; set; } = null!;
    public bool IsCompleted { get; set; }
}
