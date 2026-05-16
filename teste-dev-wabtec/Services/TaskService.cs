using teste_dev_wabtec.Api.DTOs;
using teste_dev_wabtec.Api.Models;

namespace teste_dev_wabtec.Api.Services;

public class TaskService : ITaskService
{
    private static readonly List<TaskItem> _tasks = new();
    private static int _nextId = 1;

    public IEnumerable<TaskResponse> GetAll(bool? isCompleted)
    {
        var queryTask = _tasks.AsQueryable();

        if (isCompleted.HasValue)
        {
            queryTask = queryTask.Where(t => t.IsCompleted == isCompleted.Value);
        }

        var taskResult = queryTask.Select(t => new TaskResponse
        {
            Id = t.Id,
            Title = t.Title,
            IsCompleted = t.IsCompleted
        }).ToList();

        return taskResult;
    }

    public TaskResponse Create(string title)
    {
        var task = new TaskItem
        {
            Id = _nextId,
            Title = title,
            IsCompleted = true
        };

        _nextId += 1;

        _tasks.Add(task);

        return new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            IsCompleted = task.IsCompleted
        };
    }
}
