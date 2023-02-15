using TWJOBS.API.Common.DTOS;

namespace TWJOBS.API.Jobs.DTOS;

public class JobDetailResponse: ResourceResponse{
    public int id { get; set; }
    public string titulo { get; set; } = string.Empty;
    public decimal salario { get; set; }
    public ICollection <string> requerimentos { get; set; } = new List<string>();
}