using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        this.logger = logger;
    }

    [AllowAnonymous]
    [Route("Error")]
    public IActionResult Error()
    {
        var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        logger.LogError($"The Path {exceptionHandlerPathFeature?.Path} " +
            $"Threw an Exception {exceptionHandlerPathFeature?.Error}");

        return View("Error");
    }
}
