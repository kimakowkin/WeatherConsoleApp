namespace OpenWeatherTest
{
    public class WeatherResponse
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public Sys sys { get; set; }
        public string name { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public string main { get; set; }
    }

    public class Sys
    {
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

}
