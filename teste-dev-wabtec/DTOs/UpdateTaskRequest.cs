namespace teste_dev_wabtec.Api.DTOs;

public class UpdateTaskRequest
{
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}