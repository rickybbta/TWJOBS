using System.Text.Json;
using FluentValidation;
using Swashbuckle.AspNetCore.SwaggerGen;
using TWJOBS.API.Common.DTOS;
using TWJOBS.Core.Exceptions;

namespace TWJOBS.Core.Middlewares;

public class ExceptionHandlerMiddleware{
    private readonly RequestDelegate _next;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    public ExceptionHandlerMiddleware(RequestDelegate next){
        _next = next;
        _jsonSerializerOptions = new JsonSerializerOptions{
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
    public async Task Invoke(HttpContext context){
        try{
            await _next(context);
        } catch (ModelNotFoundException e) {
            await handleModelNotFoundExceptionAsync(context, e);
        } catch (ValidationException e) {
            await handleValidationExceptionAsync(context, e);
        }
    }

    private Task handleValidationExceptionAsync(HttpContext context, ValidationException e){
        var body = new ValidationErrorResponse()
        {
            status = 400,
            error = "Bad Request",
            cause = e.GetType().Name,
            message = "Validation Error",
            timestamp = DateTime.Now,
            errors = e.Errors.GroupBy(vf => vf.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(vf => vf.ErrorMessage).ToArray())
        };
        context.Response.StatusCode = body.status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
    }

    private Task handleModelNotFoundExceptionAsync(HttpContext context, ModelNotFoundException e){
        var body = new ErrorResponse {
            status = 404,
            error = "Not Found",
            cause = e.GetType().Name,
            message = e.Message,
            timestamp = DateTime.Now
        };
        context.Response.StatusCode = body.status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
    }
}