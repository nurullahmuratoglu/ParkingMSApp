using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ParkingMSApp.Application.Dtos.ParkingVehicle;
using ParkingMSApp.Application.Dtos.Response;
using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Application.UnitOfWork;

namespace ParkingMSApp.Application.Features.Commands.ParkningVehicle.ExitParking
{
    public class ExitParkingCommandHandler : IRequestHandler<ExitParkingCommandRequest, ResponseDto<ExitParkingViewDto>>
    {
        private readonly IParkingVehicleRepository _parkingVehicleRepository;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IFixedFeeRepository _fixedFeeRepository;

        public ExitParkingCommandHandler(IParkingVehicleRepository parkingVehicleRepository, IUnitOfWorks unitOfWorks, IMapper mapper, IFixedFeeRepository fixedFeeRepository)
        {
            _parkingVehicleRepository = parkingVehicleRepository;
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _fixedFeeRepository = fixedFeeRepository;
        }

        public async Task<ResponseDto<ExitParkingViewDto>> Handle(ExitParkingCommandRequest request, CancellationToken cancellationToken)
        {

            bool result = int.TryParse(request.ParkingVehicleId, out int parkingVehicleId);

            if (!result)
            {
                return ResponseDto<ExitParkingViewDto>.Fail(StatusCodes.Status200OK,"lütfen geçerli bir ıd giriniz");
            }



            var parkingVehicle = await _parkingVehicleRepository.GetByIdWithVehicleAsync(parkingVehicleId);
            var vehicleClass = await _parkingVehicleRepository.GetAll().Include(x => x.Vehicles).Where(x => x.Id == parkingVehicleId).Select(x => x.Vehicles.VehicleClass).FirstOrDefaultAsync();
            var fixedFee = await _fixedFeeRepository.GetAll().FirstOrDefaultAsync(x => x.VehicleClass == vehicleClass);
            parkingVehicle.ExitTime = DateTime.Now;
            parkingVehicle.HourFee = fixedFee.HourFee;
            TimeSpan hoursDifference = (TimeSpan)(parkingVehicle.ExitTime - parkingVehicle.EntryTime);
            parkingVehicle.HoursParked = hoursDifference.ToString("ddd\\.hh\\:mm\\:ss");

            parkingVehicle.TotalFee = ((int)hoursDifference.TotalHours + 1) * parkingVehicle.HourFee;
            await _unitOfWorks.CommitAsync();

            var exitParkingDto = _mapper.Map<ExitParkingViewDto>(parkingVehicle);
            return ResponseDto<ExitParkingViewDto>.Success(StatusCodes.Status200OK, exitParkingDto);
        }
    }
}
