using teste_dev_wabtec.Api.Models;

namespace teste_dev_wabtec.Api.DTOs;

public class TaskResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }

    public TaskResponse(int id, string title, bool isCompleted)
    {
        Id = id;
        Title = title;
        IsCompleted = isCompleted;
    }

    public static TaskResponse FromEntity(TaskItem t) =>
        new(t.Id, t.Title, t.IsCompleted);

}
