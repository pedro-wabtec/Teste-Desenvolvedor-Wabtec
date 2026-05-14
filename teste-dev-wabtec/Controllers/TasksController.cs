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
    public ActionResult<IEnumerable<TaskResponse>> GetTasks([FromQuery] bool? isCompleted)
    {
        try
        {
            return StatusCode(200, _taskService.GetAll(isCompleted));
        }
        catch (ServiceException ex)
        {
            return StatusCode(500, new ProblemDetails
            {
                Title = "Internal server error",
                Detail = ex.Message,
                Status = 500
            });
        }
    }

    [HttpPost]
    public ActionResult<TaskResponse> CreateTask([FromBody] CreateTaskRequest request)
    {
        try
        {
            var created = _taskService.Create(request.Title);
            return StatusCode(201, created);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(400, new ProblemDetails
            {
                Title = "Bad request",
                Detail = ex.Message,
                Status = 400
            });
        }
        catch (ServiceException ex)
        {
            return StatusCode(500, new ProblemDetails
            {
                Title = "Internal server error",
                Detail = ex.Message,
                Status = 500
            });
        }
    }
}
