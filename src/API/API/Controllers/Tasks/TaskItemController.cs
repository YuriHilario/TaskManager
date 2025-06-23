using API.DTOs.Tasks;
using API.Interfaces.Services;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskService _taskService;


        public TaskItemController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/TaskItem
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetAll()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        // GET: api/TaskItem/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // POST: api/TaskItem
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                Status = dto.Status
            };

            await _taskService.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }


        // PUT: api/TaskItem/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateTaskDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID da URL e do corpo não correspondem.");

            var task = new TaskItem
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                Status = dto.Status
            };

            var success = await _taskService.UpdateTaskAsync(task);
            if (!success)
                return NotFound();

            return NoContent();
        }


        // DELETE: api/TaskItem/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _taskService.DeleteTaskAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
