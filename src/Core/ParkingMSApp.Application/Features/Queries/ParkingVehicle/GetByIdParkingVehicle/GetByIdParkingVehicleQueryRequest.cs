using MediatR;
using ParkingMSApp.Application.Dtos.Car;
using ParkingMSApp.Application.Dtos.Response;

namespace ParkingMSApp.Application.Features.Queries.ParkingVehicle.GetByIdParkingVehicle
{
    public class GetByIdParkingVehicleQueryRequest:IRequest<ResponseDto<ParkingVehicleViewDto>>
    {
        public int Id { get; set; }
    }
}
