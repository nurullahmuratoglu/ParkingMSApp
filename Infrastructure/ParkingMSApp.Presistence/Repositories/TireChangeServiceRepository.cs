using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Domain.Entities;
using ParkingMSApp.Presistence.Context;

namespace ParkingMSApp.Presistence.Repositories
{
    public class TireChangeServiceRepository : GenericRepository<TireChangeService>, ITireChangeServiceRepository
    {
        public TireChangeServiceRepository(AppDbContext context) : base(context)
        {

        }
    }
}
