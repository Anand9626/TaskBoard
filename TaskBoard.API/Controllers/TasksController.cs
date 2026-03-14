using Microsoft.AspNetCore.Mvc;
using TaskBoard.API.Models;
using TaskBoard.API.Services;

namespace TaskBoard.API.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _service.GetTasks());
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskItem task)
        {
            var result = await _service.AddTask(task);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(TaskItem task)
        {
            await _service.UpdateTask(task);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _service.DeleteTask(id);
            return Ok();
        }

        [HttpPut("move")]
        public async Task<IActionResult> MoveTask(int taskId, int columnId)
        {
            await _service.MoveTask(taskId, columnId);
            return Ok();
        }
    }
}