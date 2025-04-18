﻿using EventProject.Application.Exceptions;
using EventProject.Application.ResponseModels;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace EventProject.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {

            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var message = new List<string> { ex.Message };
            switch (ex)
            {

                case BadRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case DeleteFailedException:
                    statusCode = HttpStatusCode.Conflict;
                    break;
                case RateLimitException:
                    statusCode = HttpStatusCode.TooManyRequests;
                    break;
                case ValidationException validationException:
                    await WriteValidationExceptions(context, validationException, HttpStatusCode.BadRequest);
                    return;//breakde ola biler

                default:
                  
                    break;
            }
            await WriteError(context, statusCode, message);

        }

    }

    private static async Task WriteValidationExceptions(HttpContext context, ValidationException validationException, HttpStatusCode badRequest)
    {

        context.Response.Clear();
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)badRequest;
        var validationErrors = validationException.Errors.Select(e => new { field = e.PropertyName, message = e.ErrorMessage });

        var json = JsonSerializer.Serialize(new { validatonErrors = validationErrors });
        await context.Response.WriteAsync(json);
    }

    private static async Task WriteError(HttpContext context, HttpStatusCode statusCode, List<string> message)
    {
        context.Response.Clear();
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        var json = JsonSerializer.Serialize(new BaseResponseModel(message));
        await context.Response.WriteAsync(json);


    }
}



//private readonly RequestDelegate _next;

//    public CorsMiddleware(RequestDelegate next)

//    {

//        _next = next;

//    }

//    public async Task Invoke(HttpContext context)

//    {

//        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

//        // context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");

//        context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Accept-Encoding, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name , Authorization");

//        context.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");

//        if (context.Request.Method == "OPTIONS")

//        {

//            context.Response.StatusCode = (int)HttpStatusCode.OK;

//            await context.Response.WriteAsync(string.Empty);

//        } // New Code Ends here

//        await _next(context);

//    }


