
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
        IterationCount = Metrics.CreateCounter("ei_totals_call", "Number of iterations that the sample service has ever executed.");
    }
    [HttpGet(Name = "welcome")]
    public String Get()
    {

        // We finished one iteration of the service's work.
        IterationCount.Inc();
        return "Welcome to EI Custom Metrics";
    }
}