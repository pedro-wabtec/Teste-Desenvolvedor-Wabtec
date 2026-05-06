using teste_dev_wabtec.Api.DTOs;
using teste_dev_wabtec.Api.Models;

namespace teste_dev_wabtec.Api.Services;

public class TaskService : ITaskService
{
    private static readonly List<TaskItem> _tasks = new();
    private static int _nextId = 1;

    public IEnumerable<TaskResponse> GetAll(bool? isCompleted)
    {
        // TODO: implementar GET e filtro por status
        throw new NotImplementedException();
    }

    public TaskResponse Create(string title)
    {
        // TODO: implementar POST
        throw new NotImplementedException();
    }
}
