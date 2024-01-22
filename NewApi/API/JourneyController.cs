using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewApi.Business;
using NewApi.Models;
using NewApi.Models.Response;
using NewApi.Services;

namespace NewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IJourneySearchServices _journeyServices;

        public JourneyController(IFlightService flightService, IJourneySearchServices journeyServices)
        {
            _flightService = flightService;
            _journeyServices = journeyServices;
        }

        [HttpGet]

        public async Task<List<Journey>> Get([FromQuery] Request request ) 
        {
            var flightsList = await _flightService.Get();

            var journeys = _journeyServices.FindJourneys(request, flightsList);
            

            return journeys;

        }

        
    }
}
