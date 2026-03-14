using Microsoft.EntityFrameworkCore;
using TaskBoard.API.Models;

namespace TaskBoard.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }

        public DbSet<BoardColumn> Columns { get; set; }
    }
}