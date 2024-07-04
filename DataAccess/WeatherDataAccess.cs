using System.Text.Json;
using StackExchange.Redis;

namespace WeatherQuick.DataAccess;

public class WeatherDataAccess
{
       private readonly ConnectionMultiplexer _redis;

       public WeatherDataAccess(string connectionString)
       {
              _redis = ConnectionMultiplexer.Connect(connectionString);
       }

       public void SetWeatherCacheCity(WeatherModel weather, string city)
       {
              IDatabase db = _redis.GetDatabase();

              try
              {
                     string weatherJson = JsonSerializer.Serialize(weather);
                     db.StringSet(city, weatherJson);
              }
              catch (Exception e)
              {
                     Console.WriteLine(e);
                     throw;
              }
       }
       
       public WeatherModel? GetWeatherCacheCity(string location)
       {
              IDatabase db = _redis.GetDatabase();
              
              try
              {
                     var weatherJson = db.StringGet(location);
                     if (weatherJson.IsNullOrEmpty)
                            return null;

                     WeatherModel weatherModel = JsonSerializer.Deserialize<WeatherModel>(weatherJson);

                     return weatherModel;
              }
              catch (Exception e)
              {
                     Console.WriteLine(e);

                     return null;
              }
       }
       
       
}