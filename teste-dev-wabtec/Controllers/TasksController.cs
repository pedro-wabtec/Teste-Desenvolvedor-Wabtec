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

    public IActionResult GetTasks([FromQuery] bool? isCompleted)
    {
        // TODO: implementar Controller GetTasks
        throw new NotImplementedException();
    }

    public IActionResult CreateTask([FromBody] CreateTaskRequest request)
    {
        // TODO: implementar Controller CreateTask
        throw new NotImplementedException();
    }
}
