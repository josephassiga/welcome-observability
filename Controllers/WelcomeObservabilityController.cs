
using Microsoft.AspNetCore.Mvc;

namespace observabilityapp.Controllers;

[ApiController]
[Route("welcome")]
public class WelcomeObservabilityController : ControllerBase
{
     [HttpGet(Name = "welcome")]
    public String Get()
    {
       return "Welcome to EI Custom Metrics";
    }
}