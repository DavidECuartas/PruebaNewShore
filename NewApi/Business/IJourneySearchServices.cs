using NewApi.Models;
using NewApi.Models.Response;

namespace NewApi.Business
{
    public interface IJourneySearchServices
    {
        public List<Journey> FindJourneys(Request request, List<Flight> flightsList);
    }
}
