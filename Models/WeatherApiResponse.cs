namespace WeatherQuick;

public record ExternalWeatherResponse(Location location, Current current);
public record Location(string name, string region, string country, string localtime);
public record Current(double temp_c, double precip_mm, double humidity, double feelslike_c);
