namespace WeatherQuick;

public class WeatherModel
{
    public string Name { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    public string LocalTime { get; set; }
    public double Temp { get; set; }
    public double Precip { get; set; }
    public double Humidity { get; set; }
    public double FeelsLike { get; set; }
}