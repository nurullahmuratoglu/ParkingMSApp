using MediatR;
using ParkingMSApp.Application.Dtos.Car;
using ParkingMSApp.Application.Dtos.Response;

namespace ParkingMSApp.Application.Features.Queries.ParkingVehicle.GetByClassNameVehicle
{
    public class GetByClassNameVehicleQueryRequest : IRequest<ResponseDto<List<ParkingVehicleViewDto>>>
    {
        public string? ClassName { get; set; }
    }
}
