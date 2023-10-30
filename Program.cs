using Newtonsoft.Json;

namespace OpenWeatherTest
{

    class Program
    {
        static async Task Main(string[] args)
        {
            var weatherService = new WeatherService();
            Console.WriteLine("Enter a city: ");

            var city = Console.ReadLine();

            string json = await weatherService.GetWeatherDataAsync(city);
            WeatherResponse weatherData = JsonConvert.DeserializeObject<WeatherResponse>(json);

            Console.WriteLine($"City: {weatherData.name}");
            Console.WriteLine($"Coordinates: {weatherData.coord.lat}, {weatherData.coord.lon}");
            Console.WriteLine($"Weather: {weatherData.weather[0].main}");
            Console.WriteLine($"Sunrise: {UnixTimeStampToDateTime(weatherData.sys.sunrise)}");
            Console.WriteLine($"Sunset: {UnixTimeStampToDateTime(weatherData.sys.sunset)}");
            Console.WriteLine($"Country: {weatherData.sys.country}");
        }

        static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}