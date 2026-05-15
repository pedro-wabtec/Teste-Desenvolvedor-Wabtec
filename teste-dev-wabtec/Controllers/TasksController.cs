using Microsoft.AspNetCore.Mvc;
using teste_dev_wabtec.Api.DTOs;
using teste_dev_wabtec.Api.Services;
using static System.Net.WebRequestMethods;

namespace teste_dev_wabtec.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController(ITaskService taskService) : ControllerBase
{
    private readonly ITaskService _taskService = taskService;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TaskResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetTasks()
    {
        try
        {
            var tasks = _taskService.GetAll();
            if (!tasks.Any())
            {
                return NoContent();
            }
            return Ok(tasks);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error occurred while fetching tasks." });
        }
    }

    [HttpGet("status")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public IActionResult GetTasks([FromQuery] bool? isCompleted)
    {
        try
        {
            if (!isCompleted.HasValue)
            {
                return BadRequest(new { message = "The 'isCompleted' parameter is required." });
            }

            var tasks = _taskService.GetByStatus(isCompleted);

            if (!tasks.Any())
            {
                return NoContent();
            }

            return Ok(tasks);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error occurred while fetching tasks." });
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult CreateTask([FromBody] CreateTaskRequest request)
    {
        try
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid request body." });
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest(new { message = "Task title is required." });
            }

            var createdTask = _taskService.Create(request.Title);

            return StatusCode(StatusCodes.Status201Created, createdTask);
        }
        catch
        {

            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error occurred while creating the task." });
        }
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<TaskResponse> Update(int id, [FromBody] UpdateTaskRequest request)
    {
        try
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid request body." });
            }

            var existingTask = _taskService.GetById(id);

            if (existingTask == null)
            {
                return NotFound(new { message = $"Task with id {id} was not found." });
            }

            var updatedTask = _taskService.Update(id, request);

            return Ok(updatedTask);
        }
        catch
        {

            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error occurred while updating the task." });
        }
    }
}
