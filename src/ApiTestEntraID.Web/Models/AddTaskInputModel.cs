using System.ComponentModel.DataAnnotations;

namespace ApiTestEntraID.Web.Models;

public sealed class AddTaskInputModel
{
    [Required]
    public DateTime Date { get; set; } = DateTime.UtcNow.Date;

    [Required]
    [StringLength(200)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public Guid AssignedUserId { get; set; }
}