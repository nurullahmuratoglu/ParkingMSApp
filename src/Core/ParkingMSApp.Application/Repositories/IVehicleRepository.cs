using ParkingMSApp.Domain.Entities;

namespace ParkingMSApp.Application.Repositories
{
    public interface IVehicleRepository:IGenericRepository<Vehicle>
    {
        Task<List<Vehicle>> GetAllVehicle();
    }
}
