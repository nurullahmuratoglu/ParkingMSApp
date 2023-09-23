using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using ParkingMSApp.Application.Dtos.Response;
using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Application.UnitOfWork;
using ParkingMSApp.Domain.Entities;
using entities = ParkingMSApp.Domain.Entities;

namespace ParkingMSApp.Application.Features.Commands.ParkningVehicle.CreateParkingVehicle
{
    public class CreateParkingVehicleCommandHandler : IRequestHandler<CreateParkingVehicleCommandRequest, ResponseDto<NoContentDto>>
    {
        private readonly IParkingVehicleRepository _parkingVehicleRepository;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;


        public CreateParkingVehicleCommandHandler(IParkingVehicleRepository parkingVehicleRepository, IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _parkingVehicleRepository = parkingVehicleRepository;
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;

        }

        public async Task<ResponseDto<NoContentDto>> Handle(CreateParkingVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            var mappedVehicle = DetermineClass(request);
            ParkingVehicle parkingVehicle = new()
            {
                EntryTime = DateTime.Now,
                Vehicles = mappedVehicle
            };
            await _parkingVehicleRepository.AddAsync(parkingVehicle);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }


        private entities.Vehicle DetermineClass(CreateParkingVehicleCommandRequest request)
        {
            entities.Vehicle mappedVehicle;

            if (request.AutomaticPilot && request.Price > 0)
            {
                mappedVehicle = _mapper.Map<Class1Vehicle>(request);
            }
            else if (request.TrunkCapacity > 0 && request.SpareTire)
            {
                mappedVehicle = _mapper.Map<Class2Vehicle>(request);
            }
            else
            {
                mappedVehicle = _mapper.Map<Class3Vehicle>(request);
            }
            return mappedVehicle;
        }

    }
}
