namespace WeatherQuick;

public class WetaherModel
{
    public string resolvedAddress { get; set; }
    public string address { get; set; }
    public string description { get; set; }
    public decimal temp { get; set; }
    public decimal feelslike { get; set; }
    public decimal humidity { get; set; }
    public decimal precipprob { get; set; }
}