using Microsoft.EntityFrameworkCore;

namespace TodoApp.Api.Data;

public class ApplicationContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    
    public ApplicationContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity <TodoItem>() //EntityTypeBuilder<TodoItem>
            .HasData(new TodoItem { Id = 1, CreatedAt = DateTime.MinValue, Description = "First db todo" },
                new TodoItem { Id = 2, CreatedAt = DateTime.MinValue, Description = "Second db todo" });
    }
}
