using FluentValidation;
using TWJOBS.API.Jobs.DTOS;
using TWJOBS.API.Jobs.Validators;

namespace TWJOBS.Core.Config;

public static class ValidatorsConfig{
    public static void RegisterValidators(this IServiceCollection services){
        services.AddScoped<IValidator<JobRequest>, JobRequestValidator>();
    }
}