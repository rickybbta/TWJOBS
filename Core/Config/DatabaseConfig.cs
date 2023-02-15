using System.Xml.Serialization;
using TWJOBS.Core.Data.Contexts;

namespace TWJOBS.Core.Config;

public static class DatabaseConfig{
    public static void RegisterDatabase(this IServiceCollection services){
        services.AddDbContext<TwJobsDbContext>();
    }
}