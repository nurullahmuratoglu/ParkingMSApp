using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ParkingMSApp.Application.Dtos.Car;
using ParkingMSApp.Application.Dtos.Response;
using ParkingMSApp.Application.Repositories;

namespace ParkingMSApp.Application.Features.Queries.ParkingVehicle.GetByClassNameVehicle
{
    public class GetByClassNameVehicleQueryHandler : IRequestHandler<GetByClassNameVehicleQueryRequest, ResponseDto<List<ParkingVehicleViewDto>>>
    {
        private readonly IParkingVehicleRepository _parkingVehicleRepository;
        private readonly IMapper _mapper;

        public GetByClassNameVehicleQueryHandler(IParkingVehicleRepository parkingVehicleRepository, IMapper mapper)
        {
            _parkingVehicleRepository = parkingVehicleRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<ParkingVehicleViewDto>>> Handle(GetByClassNameVehicleQueryRequest request, CancellationToken cancellationToken)
        {
            var parkingVehicle = await _parkingVehicleRepository
                .GetAll()
                .Where(x => x.ExitTime == null)
                .Include(x => x.Vehicles)
                .Where(x => x.Vehicles.VehicleClass == request.ClassName)
                .ToListAsync();
            var parkingVehicleDto = _mapper.Map<List<ParkingVehicleViewDto>>(parkingVehicle);

            return ResponseDto<List<ParkingVehicleViewDto>>.Success(StatusCodes.Status200OK, parkingVehicleDto);
        }
    }
}
