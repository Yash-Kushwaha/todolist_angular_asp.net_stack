using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ToDoItems> ToDoLists { get; set; }
    }
}
