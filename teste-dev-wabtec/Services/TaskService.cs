using AutoMapper;
using teste_dev_wabtec.Api.DTOs;
using teste_dev_wabtec.Api.Models;

namespace teste_dev_wabtec.Api.Services;

public class TaskService : ITaskService
{
    private static readonly List<TaskItem> _tasks = new()
    {
        new() { Id = 1, Title = "Configurar ambiente de desenvolvimento", IsCompleted = true },
        new() { Id = 2, Title = "Revisar documentação da API", IsCompleted = false },
        new() { Id = 3, Title = "Implementar endpoints de tarefas", IsCompleted = true },
    };

    private static int _nextId = 4;
    private readonly IMapper _mapper;

    public TaskService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<TaskResponse> GetAll(bool? isCompleted)
    {
        var tasks = isCompleted.HasValue
            ? _tasks.Where(t => t.IsCompleted == isCompleted.Value)
            : _tasks;

        return _mapper.Map<IEnumerable<TaskResponse>>(tasks);
    }

    public TaskResponse Create(string title)
    {
        var task = new TaskItem
        {
            Id = _nextId++,
            Title = title,
            IsCompleted = false
        };

        _tasks.Add(task);

        return _mapper.Map<TaskResponse>(task);
    }
}
