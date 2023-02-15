using TWJOBS.Core.Repositories.Jobs;

namespace TWJOBS.Core.Config;

public static class RepositoriesConfig{
    public static void RegisterRepositories(this IServiceCollection services){
        services.AddScoped<IJobRepository, JobRepository>();
    }
}