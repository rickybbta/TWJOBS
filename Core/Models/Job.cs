namespace TWJOBS.Core.Models;

public class Job{
    public int id { get; set; }
    public string titulo { get; set; } = string.Empty;
    public decimal salario { get; set; }
    public string requerimentos { get; set; } = string.Empty;
}