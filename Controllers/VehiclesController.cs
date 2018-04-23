using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VEGA.Controllers.Resources;
using VEGA.Models;
using VEGA.Persistence;

namespace VEGA.Controllers
{
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IUnitOfWork unitOfWork;
        public VehiclesController(IMapper mapper, IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.vehicleRepository = vehicleRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
<<<<<<< HEAD

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicleRepository.Add(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await vehicleRepository.GetVehicle(vehicle.Id);
=======
                
            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
>>>>>>> 0b1eecf4c2d6af9b1184171f9e4a83071ed5af4b

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await vehicleRepository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();
<<<<<<< HEAD
=======
            
            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
>>>>>>> 0b1eecf4c2d6af9b1184171f9e4a83071ed5af4b

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);

            await unitOfWork.CompleteAsync();
            vehicle = await vehicleRepository.GetVehicle(vehicle.Id);
            
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await vehicleRepository.GetVehicle(id, includeRelated: false);

            if (vehicle == null)
                return NotFound();

            vehicleRepository.Remove(vehicle);
            await unitOfWork.CompleteAsync();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
<<<<<<< HEAD
            var vehicle = await vehicleRepository.GetVehicle(id);
=======
            var vehicle = await context.Vehicles
            .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
            .Include(v => v.Model)
                .ThenInclude(v => v.Make)
            .SingleOrDefaultAsync(v => v.Id == id);
>>>>>>> 0b1eecf4c2d6af9b1184171f9e4a83071ed5af4b

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(vehicleResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await vehicleRepository.GetAllVehicles();
            return Ok(vehicles);
        }
    }
}