
using Microsoft.AspNetCore.Mvc;
using Prometheus;
using System.Diagnostics;

namespace observabilityapp.Controllers;



[ApiController]
[Route("welcome")]
public class ObservabilityController : ControllerBase
{
    public readonly Counter IterationCount;

    // We measure a histogram of the absolute difference between the winner and loser.
    private readonly Histogram WelcomeDuration;

    //private readonly Summary WelcomeSizeSummary;

    public ObservabilityController()
    {
        IterationCount = Metrics.CreateCounter("http_welcome_requets_received_total", "Total number of requests serviced by Welcome API.", new CounterConfiguration
        {
            LabelNames = new[] { "path", "method", "status" }
        });
        WelcomeDuration = Metrics.CreateHistogram("http_welcome_duration_seconds", "The duration in seconds between the response to a request.", new HistogramConfiguration
        {
            // We divide measurements in 10 buckets of $100 each, up to $1000.
            //Buckets = Histogram.LinearBuckets(start: 100, width: 100, count: 10)
            Buckets = Histogram.ExponentialBuckets(0.01, 2, 10),
            LabelNames = new[] { "status_code", "method", "action" }
        });

    }
    [HttpGet(Name = "welcome")]
    public String Get()
    {
        // Status Code.
        var statusCode = 200;

        // Path of the request
        var path = HttpContext.Request.Path.Value.ToString();

        // Method call during the request.
        var method = HttpContext.Request.Method.ToString();

        // We finished one iteration of the service's work.
        IterationCount.Labels(path, method, statusCode.ToString()).Inc();

        //RegisterResponseTime(200, "GET", Stopwatch.StartNew().Elapsed);
        WelcomeDuration.Labels(statusCode.ToString(), method, path).Observe(Stopwatch.StartNew().Elapsed.TotalSeconds);

        return "Welcome For Custom Metrics Demo";
    }

}