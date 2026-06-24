using System.Net;
using System.Text.Json;
using ChampionChallenges.Domain.Exceptions;

namespace ChampionChallenges.Api.Middlewares;

/// <summary>
/// Middleware global de exceções: captura qualquer exceção não tratada que
/// suba pela pipeline, registra no log e devolve uma resposta JSON padronizada,
/// evitando vazar stack trace para o cliente.
/// </summary>
public class GlobalExceptionMiddleware(
    RequestDelegate next,
    ILogger<GlobalExceptionMiddleware> logger,
    IHostEnvironment environment)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (DomainException ex)
        {
            // Erros de regra de negócio -> 400 Bad Request
            logger.LogWarning(ex, "Erro de domínio: {Message}", ex.Message);

            var errors = ex.Errors.Any() ? ex.Errors : [ex.Message];
            await WriteResponseAsync(context, HttpStatusCode.BadRequest, ex.Message, errors);
        }
        catch (Exception ex)
        {
            // Qualquer outra exceção inesperada -> 500 Internal Server Error
            logger.LogError(ex, "Erro não tratado ao processar {Method} {Path}",
                context.Request.Method, context.Request.Path);

            // Em produção nunca expomos detalhe interno (pode vazar info sensível,
            // ex.: erro do banco). Fora de produção, ajudamos no debug surfaceando
            // os erros reais — incluindo todos quando é uma AggregateException.
            IEnumerable<string> errors = environment.IsProduction()
                ? ["Internal Server Error"]
                : ex is AggregateException aggregate && aggregate.InnerExceptions.Any()
                    ? aggregate.InnerExceptions.Select(inner => inner.Message)
                    : [ex.Message];

            await WriteResponseAsync(
                context,
                HttpStatusCode.InternalServerError,
                "Ocorreu um erro inesperado. Tente novamente mais tarde.",
                errors);
        }
    }

    private static async Task WriteResponseAsync(
        HttpContext context,
        HttpStatusCode statusCode,
        string message,
        IEnumerable<string> errors)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var payload = JsonSerializer.Serialize(new
        {
            statusCode = (int)statusCode,
            message,
            errors
        });

        await context.Response.WriteAsync(payload);
    }
}