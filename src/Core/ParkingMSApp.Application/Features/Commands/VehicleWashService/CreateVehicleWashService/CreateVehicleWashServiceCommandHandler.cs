using MediatR;
using Microsoft.AspNetCore.Http;
using ParkingMSApp.Application.Dtos.Response;
using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Application.UnitOfWork;
using entities = ParkingMSApp.Domain.Entities;

namespace ParkingMSApp.Application.Features.Commands.VehicleWashService.CreateVehicleWashService
{
    public class CreateVehicleWashServiceCommandHandler : IRequestHandler<CreateVehicleWashServiceCommentRequest, ResponseDto<NoContentDto>>
    {
        private readonly IVehicleWashServiceRepository _vehicleWashServiceRepository;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IParkingVehicleRepository _parkingVehicleRepository;

        public CreateVehicleWashServiceCommandHandler(IVehicleWashServiceRepository vehicleWashServiceRepository, IUnitOfWorks unitOfWorks, IParkingVehicleRepository parkingVehicleRepository)
        {
            _vehicleWashServiceRepository = vehicleWashServiceRepository;
            _unitOfWorks = unitOfWorks;
            _parkingVehicleRepository = parkingVehicleRepository;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(CreateVehicleWashServiceCommentRequest request, CancellationToken cancellationToken)
        {
            var washService = await _vehicleWashServiceRepository.AnyAsync(x => x.ParkingVehicleId == request.ParkingVehicleId);
            if (washService)
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, "bu araç daha önce yıkama hizmetinden faydalanmış");
            }

            var parkingVehicle = await _parkingVehicleRepository.GetByIdWithVehicleAsync(request.ParkingVehicleId);
            if (parkingVehicle == null)
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, "Otoparkta olmayan araç bu hizmetten faydalanamaz");

            }
            if (parkingVehicle.Vehicles.VehicleClass == "Class1")
            {
                entities.VehicleWashService vehicleWashService = new()
                {
                    ParkingVehicleId = request.ParkingVehicleId,
                    CreatedDate = DateTime.Now
                };
                await _vehicleWashServiceRepository.AddAsync(vehicleWashService);
                await _unitOfWorks.CommitAsync();
                return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);

            }

            return ResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Sadece 1. sınıf arabalar bu hizmetten faydalanabilirler");
        }
    }
}
