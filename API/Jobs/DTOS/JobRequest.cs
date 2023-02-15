namespace TWJOBS.API.Jobs.DTOS;

public class JobRequest{
    public string titulo { get; set; } = string.Empty;
    public decimal salario { get; set; }
    public ICollection <string> requerimentos { get; set; } = new List<string>();
}