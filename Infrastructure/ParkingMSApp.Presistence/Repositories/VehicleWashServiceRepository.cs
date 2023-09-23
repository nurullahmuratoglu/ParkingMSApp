using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Domain.Entities;
using ParkingMSApp.Presistence.Context;

namespace ParkingMSApp.Presistence.Repositories
{
    public class VehicleWashServiceRepository : GenericRepository<VehicleWashService> ,IVehicleWashServiceRepository
    {
        public VehicleWashServiceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
