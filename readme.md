# WeatherQuick

WeatherQuick is a C# project that uses .NET Core to provide an API that returns weather information for a specific location. The weather information is obtained from an external API and is stored in a Redis database for faster access on future requests. 

[IDEA]("https://roadmap.sh/backend/project-ideas")
![img.png](https://assets.roadmap.sh/guest/weather-api-f8i1q.png)

## Project Structure

The project is divided into several parts:

- **Controllers**: Contains the `WeatherController`, which handles HTTP requests to the API. The controller uses the `WeatherRequestService` to get the weather information.

- **Services**: Contains the `WeatherRequestService`, which is responsible for getting the weather information. It first tries to get the information from the Redis database. If the information is not in the database, it makes a request to the external API and stores the response in Redis.

- **DataAccess**: Contains the `WeatherDataAccess` class, which handles the Redis database operations. It can store and retrieve `WeatherModel` objects in the database.

## Usage

To get the weather information for a location, make a GET request to `/api/weather/{location}`, where `{location}` is the location for which you want to get the weather information.

## Dependencies

- **DotEnv.Core**: Used to read environment variables [(open source project)]("https://github.com/MrDave1999/dotenv.core").
- **StackExchange.Redis**: Used to interact with the Redis database.
- **System.Text.Json**: Used to serialize and deserialize JSON objects.
