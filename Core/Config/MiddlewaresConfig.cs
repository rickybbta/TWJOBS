using TWJOBS.Core.Middlewares;

namespace TWJOBS.Core.Config;

public static class MiddlewaresConfig{
    public static void RegisterMiddlewares(this WebApplication app){
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}