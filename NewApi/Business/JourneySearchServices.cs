using NewApi.Models.Response;
using NewApi.Models;
using NewApi.Services;

namespace NewApi.Business
{
    public class JourneySearchServices:IJourneySearchServices
    {
        public List<Journey> FindJourneys (Request request,List<Flight> flightsList)
        {           
            
            var state = new SearchState
            {
                VisitedCities = new List<string> { request.Origin.ToUpper() },
                Journeys = new List<Journey>(),
                JourneyFlights = new List<Flight>(),
            };

            try
            {
                FindJourneyFlights(request.Origin.ToUpper(), request.Destination.ToUpper(),
                    flightsList, state);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar vuelos: {ex.Message}");
                return new List<Journey>();
            }


            return state.Journeys;
        }

        public List<Journey> FindJourneys()
        {
            throw new NotImplementedException();
        }

        private void FindJourneyFlights(string origin, string destination,
            List<Flight> flights, SearchState state)
        {
            if (origin == destination)
            {
                var journey = new Journey
                {
                    Flights = new List<Flight>(state.JourneyFlights),
                    Destination = destination,
                    Origin = state.JourneyFlights[0].Origin,
                    Price = state.JourneyFlights.Sum(flight => flight.Price ?? 0)
                };

                state.Journeys.Add(journey);
            }
            else
            {
                var filterFlights = flights.Where(flight =>
                    flight.Origin == origin &&
                    !state.VisitedCities.Contains(flight.Destination)).ToList();

                filterFlights.ForEach(flight =>
                {
                    state.VisitedCities.Add(flight.Destination);
                    state.JourneyFlights.Add(flight);
                    FindJourneyFlights(flight.Destination, destination, flights, state);

                });
            }

            if (state.JourneyFlights.Count > 0)
            {
                state.JourneyFlights.Remove(state.JourneyFlights.Last());
            }
            if (state.VisitedCities.Count > 0)
            {
                state.VisitedCities.Remove(state.VisitedCities.Last());
            }
        }
    }
}
