using MediatR;
using ParkingMSApp.Application.Dtos.CalculateHorsePower;
using ParkingMSApp.Application.Dtos.Response;

namespace ParkingMSApp.Application.Features.Queries.MotorPower.CalculateHorsePower
{
    public class CalculateHorsePowerQueryRequest : IRequest<ResponseDto<CalculateHorsePowerViewDto>>
    {
        public decimal MotorPowerKW { get; set; }
    }
}
