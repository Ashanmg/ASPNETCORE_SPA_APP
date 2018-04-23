using System.Collections.Generic;
using System.Threading.Tasks;
using VEGA.Models;

namespace VEGA.Persistence
{
    public interface IVehicleRepository
    {
         Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
         Task<IEnumerable<Vehicle>> GetAllVehicles();
         void Add(Vehicle vehicle);
         void Remove(Vehicle vehicle);
    }
}