
using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace observabilityapp.Controllers;



[ApiController]
[Route("welcome")]
public class WelcomeObservabilityController : ControllerBase
{
    public readonly Counter IterationCount;

    public WelcomeObservabilityController()
    {
        IterationCount = Metrics.CreateCounter("ei_welcome_totals_calls", "Number of call to the Welcome method .");
    }
    [HttpGet(Name = "welcome")]
    public String Get()
    {

        // We finished one iteration of the service's work.
        IterationCount.Inc();
        return "Welcome to EI Custom Metrics";
    }
}