using teste_dev_wabtec.Api.DTOs;

namespace teste_dev_wabtec.Api.Services;

public interface ITaskService
{
    IEnumerable<TaskResponse> GetByStatus(bool? isCompleted);
    IEnumerable<TaskResponse> GetAll();
    TaskResponse Create(string title);
    TaskResponse? GetById(int id);
    TaskResponse? Update(int id, UpdateTaskRequest request);
}
