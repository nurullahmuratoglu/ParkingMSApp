using ParkingMSApp.Domain.Entities;

namespace ParkingMSApp.Application.Repositories
{
    public interface IParkingVehicleRepository:IGenericRepository<ParkingVehicle>
    {
       Task<ParkingVehicle> GetByIdWithVehicleAsync(int id);
    }
}
