using teste_dev_wabtec.Api.DTOs;

namespace teste_dev_wabtec.Api.Services;

public interface ITaskService
{
    IEnumerable<TaskResponse> GetAll(bool? isCompleted);
    TaskResponse Create(string title);
}
