namespace ApiTestEntraID.Domain.Entities;

public sealed class WorkTask
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public Guid AssignedUserId { get; set; }
}