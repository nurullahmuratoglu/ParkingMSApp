using MediatR;
using Microsoft.AspNetCore.Http;
using ParkingMSApp.Application.Dtos.CalculateHorsePower;
using ParkingMSApp.Application.Dtos.Response;

namespace ParkingMSApp.Application.Features.Queries.MotorPower.CalculateHorsePower
{
    public class CalculateHorsePowerQueryHandler : IRequestHandler<CalculateHorsePowerQueryRequest, ResponseDto<CalculateHorsePowerViewDto>>
    {
        public async Task<ResponseDto<CalculateHorsePowerViewDto>> Handle(CalculateHorsePowerQueryRequest request, CancellationToken cancellationToken)
        {
            CalculateHorsePowerViewDto calculateHorsePower = new() { HorsePower = request.MotorPowerKW * 1.314m };


            return ResponseDto<CalculateHorsePowerViewDto>.Success(StatusCodes.Status200OK, calculateHorsePower);
        }
    }
}
