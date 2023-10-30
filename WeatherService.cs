namespace OpenWeatherTest
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "fd2cdc10f73b25198b922a1f6cdb49c1"; // replace with your OpenWeatherMap API key

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetWeatherDataAsync(string city)
        {
            var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Cannot retrieve weather data");
                Console.WriteLine(response.ToString());
                Console.ReadLine();
            }

            return await response.Content.ReadAsStringAsync();
        }
    }


}
