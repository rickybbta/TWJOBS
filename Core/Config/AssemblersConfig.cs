using TWJOBS.API.Common.Assemblers;
using TWJOBS.API.Jobs.Assemblers;
using TWJOBS.API.Jobs.DTOS;

namespace TWJOBS.Core.Config;

public static class AssemblersConfig{
    public static void RegisterAssemblers(this IServiceCollection services){
        services.AddScoped<IAssembler<JobSummaryResponse>, JobSummaryAssembler>();
        services.AddScoped<IAssembler<JobDetailResponse>, JobDetailAssembler>();
        services.AddScoped<IPagedAssembler<JobSummaryResponse>, JobSummaryPagedAssembler>();
    }
}