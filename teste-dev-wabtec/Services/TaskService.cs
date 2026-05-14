using teste_dev_wabtec.Api.DTOs;
using teste_dev_wabtec.Api.Models;

namespace teste_dev_wabtec.Api.Services;

public class TaskService : ITaskService
{
    private static readonly List<TaskItem> _tasks = new();
    private static int _nextId = 1;

    public IEnumerable<TaskResponse> GetAll(bool? isCompleted)
    {
        var query = _tasks.AsEnumerable();
        if (isCompleted.HasValue)
            query = query.Where(t => t.IsCompleted == isCompleted.Value);
        return query.Select(TaskResponse.FromEntity).ToList();
    }

    public TaskResponse Create(string title)
    {
        var task = new TaskItem { Id = _nextId++, Title = title, IsCompleted = false };
        _tasks.Add(task);
        return TaskResponse.FromEntity(task);
    }

}
