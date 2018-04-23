using System.Threading.Tasks;
using VEGA.Models;

namespace VEGA.Persistence
{
    public interface IVehicleRepository
    {
         Task<Vehicle> GetVehicle(int id);
    }
}