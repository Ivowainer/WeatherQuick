using DotEnv.Core;
using Microsoft.AspNetCore.Mvc;

namespace WeatherQuick.Controllers;

[Route("api/[controller]")]
public class WeatherController : Controller
{
    [HttpGet]
    public string Get()
    {
        var reader = new EnvReader();
        string value = reader["API_URL"];

        return value;
    }
}