using MediatR;
using ParkingMSApp.Application.Dtos.Response;

namespace ParkingMSApp.Application.Features.Commands.TireChangeService.CreateTireChangeService
{
    public class CreateTireChangeServiceCommandRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public int ParkingVehicleId { get; set; }
    }
}
