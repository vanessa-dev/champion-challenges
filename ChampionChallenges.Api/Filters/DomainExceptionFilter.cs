using ChampionChallenges.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChampionChallenges.Api.Filters;

public class DomainExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not DomainException ex) return;

        var errors = ex.Errors?.Any() == true
            ? ex.Errors
            : [ex.Message];

        context.Result = new BadRequestObjectResult(new
        {
            message = ex.Message,
            errors
        });

        context.ExceptionHandled = true;
    } 
}