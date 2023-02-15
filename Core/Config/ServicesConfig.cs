using TWJOBS.API.Jobs.Services;

namespace TWJOBS.Core.Config;

public static class ServicesConfig{
    public static void RegisterServices(this IServiceCollection services){
        services.AddScoped<IJobService, JobService>();
    }
}