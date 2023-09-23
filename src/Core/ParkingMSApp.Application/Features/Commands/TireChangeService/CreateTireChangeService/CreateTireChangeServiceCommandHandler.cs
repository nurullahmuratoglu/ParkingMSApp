using MediatR;
using Microsoft.AspNetCore.Http;
using ParkingMSApp.Application.Dtos.Response;
using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Application.UnitOfWork;
using entities = ParkingMSApp.Domain.Entities;

namespace ParkingMSApp.Application.Features.Commands.TireChangeService.CreateTireChangeService
{
    public class CreateTireChangeServiceCommandHandler : IRequestHandler<CreateTireChangeServiceCommandRequest, ResponseDto<NoContentDto>>
    {
        private readonly ITireChangeServiceRepository _tireChangeServiceRepository;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IParkingVehicleRepository _parkingVehicleRepository;

        public CreateTireChangeServiceCommandHandler(ITireChangeServiceRepository tireChangeServiceRepository, IUnitOfWorks unitOfWorks, IParkingVehicleRepository parkingVehicleRepository)
        {
            _tireChangeServiceRepository = tireChangeServiceRepository;
            _unitOfWorks = unitOfWorks;
            _parkingVehicleRepository = parkingVehicleRepository;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(CreateTireChangeServiceCommandRequest request, CancellationToken cancellationToken)
        {
            var washService = await _tireChangeServiceRepository.AnyAsync(x => x.ParkingVehicleId == request.ParkingVehicleId);
            if (washService)
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, "bu araç daha önce lastik değiştirme hizmetinden faydalanmış");
            }

            var parkingVehicle = await _parkingVehicleRepository.GetByIdWithVehicleAsync(request.ParkingVehicleId);
            if (parkingVehicle == null)
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, "Otoparkta olmayan araç bu hizmetten faydalanamaz");

            }
            if (parkingVehicle.Vehicles.VehicleClass == "Class2")
            {
                entities.TireChangeService tireChangeService = new()
                {
                    ParkingVehicleId = request.ParkingVehicleId,
                    CreatedDate = DateTime.Now
                };
                await _tireChangeServiceRepository.AddAsync(tireChangeService);
                await _unitOfWorks.CommitAsync();
                return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);

            }

            return ResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Sadece 2. sınıf arabalar bu hizmetten faydalanabilirler");
        }
    }
}
