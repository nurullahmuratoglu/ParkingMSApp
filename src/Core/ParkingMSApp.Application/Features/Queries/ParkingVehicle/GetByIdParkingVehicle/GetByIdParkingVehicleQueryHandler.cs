using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using ParkingMSApp.Application.Dtos.Car;
using ParkingMSApp.Application.Dtos.Response;
using ParkingMSApp.Application.Repositories;

namespace ParkingMSApp.Application.Features.Queries.ParkingVehicle.GetByIdParkingVehicle
{
    public class GetByIdParkingVehicleQueryHandler : IRequestHandler<GetByIdParkingVehicleQueryRequest, ResponseDto<ParkingVehicleViewDto>>
    {
        private readonly IParkingVehicleRepository _parkingVehicleRepository;
        private readonly IMapper _mapper;

        public GetByIdParkingVehicleQueryHandler(IParkingVehicleRepository parkingVehicleRepository, IMapper mapper)
        {
            _parkingVehicleRepository = parkingVehicleRepository;
            _mapper = mapper;
        }

       
        public async Task<ResponseDto<ParkingVehicleViewDto>> Handle(GetByIdParkingVehicleQueryRequest request, CancellationToken cancellationToken)
        {
            var parkingVehicle = await _parkingVehicleRepository.GetByIdWithVehicleAsync(request.Id);
            var parkingVehicleDto = _mapper.Map<ParkingVehicleViewDto>(parkingVehicle);
            return ResponseDto<ParkingVehicleViewDto>.Success(StatusCodes.Status200OK, parkingVehicleDto);
        }
    }
}
