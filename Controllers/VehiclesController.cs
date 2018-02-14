using Microsoft.AspNetCore.Mvc;
using VEGA.Models;

namespace VEGA.Controllers
{
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        [HttpPost]
        public IActionResult CreateVehicle(Vehicle vehicle)
        {
            return Ok(vehicle);
        }
    }
}