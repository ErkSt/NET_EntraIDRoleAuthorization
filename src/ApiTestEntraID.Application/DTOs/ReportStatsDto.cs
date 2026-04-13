namespace ApiTestEntraID.Application.DTOs;

public sealed class ReportStatsDto
{
    public int TotalTasks { get; set; }
    public int OpenTasks { get; set; }
    public int ClosedTasks { get; set; }
}