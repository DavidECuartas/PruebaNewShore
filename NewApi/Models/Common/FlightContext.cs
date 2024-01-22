namespace NewApi.Models.Response
{
    public class FlightContext
    {
        public string? ArrivalStation { get; set; }
        public string? DepartureStation { get; set; }
        public string? FlightCarrier { get; set; }
        public string? FlightNumber { get; set; }
        public double? Price { get; set; }
    }
}
