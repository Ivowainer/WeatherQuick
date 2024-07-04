using StackExchange.Redis;

namespace WeatherQuick.DataAccess;

public class WeatherDataAccess
{
       private readonly ConnectionMultiplexer _redis;

       public WeatherDataAccess(string connectionString)
       {
              _redis = ConnectionMultiplexer.Connect(connectionString);
       }
       
       public void GetNameTest()
       {
              IDatabase db = _redis.GetDatabase();

              try
              {
                     db.StringSet("name", "John Doe");

                     Console.WriteLine(db.StringGet("name"));
              }
              catch (Exception e)
              {
                     Console.WriteLine(e);
                     throw;
              }

       }
       
       
}