using System.Net.Http.Headers;
using System.Net.Http.Json;
using WeatherApp;

var key = "insert key here";

Console.WriteLine("Enter in the city name: ");
var cityInput = Console.ReadLine();

cityInput = Uri.EscapeDataString(cityInput);

// HttpClient is intended to be instantiated only ONCE and reused throughout the application
using HttpClient client = new();

// Specify to the client that we are expecting a JSON back
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));

var firstLink = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={key}&q={cityInput}";

// Get JSON results and deserialize
var citySearch = await client.GetFromJsonAsync<List<Root>>(firstLink);

// Print results
foreach (Root root in citySearch)
{
    Console.WriteLine($"\nCity key: {root.Key}");
    Console.WriteLine($"{root.EnglishName}, {root.AdministrativeArea.EnglishName}, {root.PrimaryPostalCode}");
    Console.WriteLine($"Timezone: {root.TimeZone.Name}");
    Console.WriteLine($"Latitude: {root.GeoPosition.Latitude} Longitude: {root.GeoPosition.Longitude}");
}

Console.WriteLine("\nPlease enter city key to access weather:");
var cityKey = Console.ReadLine();
Console.WriteLine();

var secondLink = $"http://dataservice.accuweather.com/forecasts/v1/daily/5day/{cityKey}?apikey={key}";

var weatherResult = await client.GetFromJsonAsync<newRoot>(secondLink);

for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Date: {weatherResult.DailyForecasts[i].Date}");
    Console.WriteLine($"Maximum Temperature: {weatherResult.DailyForecasts[i].Temperature.Maximum.Value + weatherResult.DailyForecasts[i].Temperature.Maximum.Unit}");
    Console.WriteLine($"Minimum Temperature: {weatherResult.DailyForecasts[i].Temperature.Minimum.Value + weatherResult.DailyForecasts[i].Temperature.Minimum.Unit}\n");
}

