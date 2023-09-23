using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Domain.Entities;
using ParkingMSApp.Presistence.Context;

namespace ParkingMSApp.Presistence.Repositories
{
    public class FixedFeeRepository : GenericRepository<FixedFee>, IFixedFeeRepository
    {
        public FixedFeeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
