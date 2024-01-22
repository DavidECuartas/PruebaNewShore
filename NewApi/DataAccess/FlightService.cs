using Microsoft.Extensions.Options;
using NewApi.Models;
using NewApi.Models.Response;
using System.Text.Json;
using NewApi.Models.Common;

namespace NewApi.Services
{
    public class FlightService:IFlightService
    {

        private readonly HttpClient _httpClient;
        private  string _url;
        public FlightService(HttpClient httpClient, IOptions<ExternalServicesOptions> options)
        {
            _httpClient = httpClient;
            _url = options.Value.FlightServiceUrl;
        }
        public async Task<List<Flight>> Get()       
        {
            
            var apiResponse = await _httpClient.GetAsync(_url);

            if (apiResponse.IsSuccessStatusCode)
            {
                var content = await apiResponse.Content.ReadAsStringAsync();
                List<FlightContext> flights =
                    JsonSerializer.Deserialize<List<FlightContext>>(content,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });


                return MapApiToFlightModel(flights);
            }
            else
            {
                Console.WriteLine($"Error: {apiResponse.StatusCode}");
                return new List<Flight>();
            }            
                  

        }

        public List<Flight> MapApiToFlightModel(List<FlightContext> apiFlights)
        {
            return apiFlights?.ConvertAll(apiFlight => new Flight
            {
                Origin = apiFlight.DepartureStation,
                Destination = apiFlight.ArrivalStation,
                Price = apiFlight.Price,
                Transport = new Transport
                {
                    FlightCarrier = apiFlight.FlightCarrier,
                    FlightNumber = apiFlight.FlightNumber
                }
            });
        }


    }
}
