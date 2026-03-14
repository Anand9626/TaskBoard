using Xunit;
using Microsoft.EntityFrameworkCore;
using TaskBoard.API.Data;
using TaskBoard.API.Models;
using TaskBoard.API.Services;
using System;
using System.Threading.Tasks;

namespace TaskBoard.Tests
{
    public class TaskServiceTests
    {
        private TaskService GetService()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            var context = new AppDbContext(options);

            return new TaskService(context);
        }

        [Fact]
        public async Task AddTask_ShouldCreateTask()
        {
            var service = GetService();

            var task = new TaskItem
            {
                Name = "Test Task",
                Description = "Testing task creation",
                Deadline = DateTime.Now,
                ColumnId = 1
            };

            var result = await service.AddTask(task);

            Assert.NotNull(result);
            Assert.Equal("Test Task", result.Name);
        }

        [Fact]
        public async Task GetTasks_ShouldReturnTasks()
        {
            var service = GetService();

            await service.AddTask(new TaskItem
            {
                Name = "Task1",
                Description = "Testing get",
                Deadline = DateTime.Now,
                ColumnId = 1
            });

            var tasks = await service.GetTasks();

            Assert.NotEmpty(tasks);
        }

        [Fact]
        public async Task UpdateTask_ShouldUpdateTask()
        {
            var service = GetService();

            var task = await service.AddTask(new TaskItem
            {
                Name = "Old Name",
                Description = "Testing update",
                Deadline = DateTime.Now,
                ColumnId = 1
            });

            task.Name = "Updated Name";

            await service.UpdateTask(task);

            var tasks = await service.GetTasks();

            Assert.Equal("Updated Name", tasks[0].Name);
        }
    }
}