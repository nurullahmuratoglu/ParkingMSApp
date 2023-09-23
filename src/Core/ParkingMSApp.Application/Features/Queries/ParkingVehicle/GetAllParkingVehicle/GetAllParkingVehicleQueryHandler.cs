using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ParkingMSApp.Application.Dtos.Car;
using ParkingMSApp.Application.Dtos.Response;
using ParkingMSApp.Application.Repositories;

namespace ParkingMSApp.Application.Features.Queries.ParkingVehicle.GetAllParkingVehicle
{
    public class GetAllParkingVehicleQueryHandler : IRequestHandler<GetAllParkingVehicleQueryRequest, ResponseDto<List<ParkingVehicleViewDto>>>
    {
        private readonly IParkingVehicleRepository _parkingVehicleRepository;
        private readonly IMapper _mapper;

        public GetAllParkingVehicleQueryHandler(IMapper mapper, IParkingVehicleRepository parkingVehicleRepository)
        {
            _mapper = mapper;
            _parkingVehicleRepository = parkingVehicleRepository;
        }

        public async Task<ResponseDto<List<ParkingVehicleViewDto>>> Handle(GetAllParkingVehicleQueryRequest request, CancellationToken cancellationToken)
        {
            var parkingVehicle = await _parkingVehicleRepository.GetAll().Where(x => x.ExitTime == null).Include(x => x.Vehicles).ToListAsync();

            
            var parkingVehicleDto = _mapper.Map<List<ParkingVehicleViewDto>>(parkingVehicle);

            return ResponseDto<List<ParkingVehicleViewDto>>.Success(StatusCodes.Status200OK, parkingVehicleDto);
        }
    }
}
