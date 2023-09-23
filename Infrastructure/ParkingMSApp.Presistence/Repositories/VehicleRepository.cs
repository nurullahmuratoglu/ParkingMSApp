using Microsoft.EntityFrameworkCore;
using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Domain.Entities;
using ParkingMSApp.Presistence.Context;

namespace ParkingMSApp.Presistence.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Vehicle>> GetAllVehicle()
        {
            var query = _context.Vehicles.Where(v => v is Class1Vehicle || v is Class2Vehicle || v is Class3Vehicle);
           
            return await query.ToListAsync();
        }
    }
}
