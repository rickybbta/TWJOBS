namespace TWJOBS.API.Common.DTOS;

public class ValidationErrorResponse: ErrorResponse{
    public IDictionary<string, string[]>? errors { get; set; }
}