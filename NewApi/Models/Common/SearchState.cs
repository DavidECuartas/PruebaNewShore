namespace NewApi.Models.Response
{
    public class SearchState
    {
        public List<string> VisitedCities { get; set; }
        public List<Journey> Journeys { get; set; } 
        public List<Flight> JourneyFlights { get; set; }
    }
}
