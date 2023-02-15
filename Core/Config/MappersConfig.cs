using TWJOBS.API.Jobs.Mappers;

namespace TWJOBS.Core.Config;

public static class MappersConfig{
    public static void RegisterMappers(this IServiceCollection services){
        services.AddScoped<IJobMapper, JobMapper>();
    }
}