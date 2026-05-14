using System.ComponentModel.DataAnnotations;

namespace teste_dev_wabtec.Api.DTOs;

public class CreateTaskRequest
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(30, ErrorMessage = "Title cannot exceed 30 characters")]
    public string Title { get; set; } = string.Empty;
}
