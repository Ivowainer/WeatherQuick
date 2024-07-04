﻿using System.Text.Json;
using DotEnv.Core;
using WeatherQuick.DataAccess;

namespace WeatherQuick.Services;

public class WeatherRequestService
{
    private readonly IEnvReader reader;
    public WeatherRequestService(IEnvReader reader)
    {
        this.reader = reader;
    }
    
    public async Task<WeatherModel> GetWeatherModelCity(string location)
    {
        WeatherDataAccess weatherDataAccess = new WeatherDataAccess("localhost");
        weatherDataAccess.GetNameTest();
        
        var cl = new HttpClient();
        
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