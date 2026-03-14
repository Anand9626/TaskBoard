using Microsoft.EntityFrameworkCore;
using TaskBoard.API.Data;
using TaskBoard.API.Models;

namespace TaskBoard.API.Services
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetTasks()
        {
            return await _context.Tasks
                .OrderByDescending(t => t.IsFavorite)
                .ThenBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<TaskItem> AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task UpdateTask(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task MoveTask(int taskId, int columnId)
        {
            var task = await _context.Tasks.FindAsync(taskId);

            if (task != null)
            {
                task.ColumnId = columnId;
                await _context.SaveChangesAsync();
            }
        }
    }
}