using teste_dev_wabtec.Api.DTOs;
using teste_dev_wabtec.Api.Models;

namespace teste_dev_wabtec.Api.Services;

public class TaskService : ITaskService
{
    private static readonly List<TaskItem> _tasks = new();
    private static int _nextId = 1;

    public IEnumerable<TaskResponse> GetByStatus(bool? isCompleted)
    {
        return _tasks
            .Where(t => !isCompleted.HasValue || t.IsCompleted == isCompleted.Value)
            .Select(t => new TaskResponse
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted
            });
    }
    public IEnumerable<TaskResponse> GetAll()
    {
        return _tasks.Select(t => new TaskResponse
        {
            Id = t.Id,
            Title = t.Title,
            IsCompleted = t.IsCompleted
        });
    }

    public TaskResponse Create(string title)
    {
        TaskItem task = new TaskItem
        {
            Id = _nextId++,
            Title = title,
            IsCompleted = false
        };

        _tasks.Add(task);

        return new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            IsCompleted = task.IsCompleted
        };
    }

    public TaskResponse? Update(int id, UpdateTaskRequest request)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return null;
        }

        if(!string.IsNullOrEmpty(request.Title))
            task.Title = request.Title;
        task.IsCompleted = request.IsCompleted;

        return new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            IsCompleted = task.IsCompleted
        };
    }

    public TaskResponse? GetById(int id)
    {
        return _tasks
       .Where(t => t.Id == id)
       .Select(t => new TaskResponse
       {
           Id = t.Id,
           Title = t.Title,
           IsCompleted = t.IsCompleted
       })
       .FirstOrDefault();
    }
}
