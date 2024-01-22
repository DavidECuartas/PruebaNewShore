using NewApi.Models;
using NewApi.Models.Response;

namespace NewApi.Services
{
    public interface IFlightService
    {
        public Task<List<Flight>> Get();
    }
}
