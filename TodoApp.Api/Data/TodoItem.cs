namespace TodoApp.Api.Data
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public bool IsCompleted  { get; set; }
        public DateTime CreatedAt  { get; set; }
    }
}
