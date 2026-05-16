using Microsoft.AspNetCore.Mvc;
using teste_dev_wabtec.Api.DTOs;
using teste_dev_wabtec.Api.Services;

namespace teste_dev_wabtec.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public IActionResult GetTasks([FromQuery] bool? isCompleted)
    {
        var tasks = _taskService.GetAll(isCompleted);
        return Ok(tasks);
    }

    [HttpPost]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult CreateTask([FromBody] CreateTaskRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return BadRequest("Task title is required.");
        }

        var createdTaskResponse = _taskService.Create(request.Title);

        return StatusCode(201, createdTaskResponse);
    }
}
