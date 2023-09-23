using Microsoft.EntityFrameworkCore;
using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Domain.Entities;
using ParkingMSApp.Presistence.Context;

namespace ParkingMSApp.Presistence.Repositories
{
    internal class ParkingVehicleRepository : GenericRepository<ParkingVehicle>, IParkingVehicleRepository
    {
        public ParkingVehicleRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<ParkingVehicle> GetByIdWithVehicleAsync(int id)
        {
            return await _context.ParkingVehicles.Where(x=>x.ExitTime==null).Include(x => x.Vehicles).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
