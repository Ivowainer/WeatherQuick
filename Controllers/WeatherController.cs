using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using DotEnv.Core;
using WeatherQuick.Services;

namespace WeatherQuick.Controllers;

[Route("api/[controller]")]
public class WeatherController : Controller
{
    [HttpGet("{location}")]
    public async Task<IActionResult> GetWeather(string location)
    {
        try
        {
            WeatherRequestService weatherRequestService = new WeatherRequestService();

            WeatherModel weather = await weatherRequestService.GetWeatherModelCity(location);
            
            return Ok(weather);

        } catch(Exception exception) {
            Console.WriteLine("Exception Hit------------");
            Console.WriteLine(exception);

            return StatusCode(500, "Internal server error");
        }
    }
}