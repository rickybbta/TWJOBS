using TWJOBS.API.Common.DTOS;

namespace TWJOBS.API.Jobs.DTOS;

public class JobSummaryResponse: ResourceResponse{
    public int id { get; set; }
    public string titulo { get; set; } = string.Empty;
}