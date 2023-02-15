namespace TWJOBS.API.Common.DTOS;

public class ErrorResponse
{
    public int status { get; set; }
    public string error { get; set; } = string.Empty;
    public string cause { get; set; } = string.Empty;
    public string message { get; set; } = string.Empty;
    public DateTime timestamp { get; set; }
}
