using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.Core.Services;

namespace Weather.Api.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        //GET: /api/location/city/search?keyword
        [HttpGet, Route("city/search")]
        public async Task<IActionResult> SearchCities(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return BadRequest();

            var result = await locationService.SearchCities(keyword);

            if (result == null)
                return NotFound();

            return new JsonResult(result);
        }
    }
}