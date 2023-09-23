using MediatR;
using ParkingMSApp.Application.Dtos.Response;

namespace ParkingMSApp.Application.Features.Commands.VehicleWashService.CreateVehicleWashService
{
    public class CreateVehicleWashServiceCommentRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public int ParkingVehicleId { get; set; }
    }
}
