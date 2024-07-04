using System.Text.Json;
using DotEnv.Core;

namespace WeatherQuick.Services;

public class WeatherRequestService
{
    /*public readonly string location;
    public WeatherRequestService(string _location)
    {
        _location = location;
    }*/
    
    public async Task<WeatherModel> GetWeatherModelCity(string location)
    {
        var cl = new HttpClient();
            
        var reader = new EnvReader();
        string key = reader.GetStringValue("API_KEY");
    
        string baseUrl = $"http://api.weatherapi.com/v1/current.json?key={key}&q={location}&aqi=no";

        var res = await cl.GetAsync(baseUrl);

        string jsonResponse = await res.Content.ReadAsStringAsync();
        ExternalWeatherResponse? weatherData = JsonSerializer.Deserialize<ExternalWeatherResponse>(jsonResponse);

        WeatherModel weatherModel = new WeatherModel
        {
            FeelsLike = weatherData.current.feelslike_c,
            Precip = weatherData.current.precip_mm,
            Temp = weatherData.current.temp_c,
            Humidity = weatherData.current.humidity,
            Name = weatherData.location.name,
            Region = weatherData.location.region,
            LocalTime = weatherData.location.localtime,
            Country = weatherData.location.country,
        };

        return weatherModel;
    }
}