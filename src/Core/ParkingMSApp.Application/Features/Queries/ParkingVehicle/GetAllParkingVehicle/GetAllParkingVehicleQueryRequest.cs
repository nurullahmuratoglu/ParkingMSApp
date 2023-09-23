using MediatR;
using ParkingMSApp.Application.Dtos.Car;
using ParkingMSApp.Application.Dtos.Response;

namespace ParkingMSApp.Application.Features.Queries.ParkingVehicle.GetAllParkingVehicle
{
    public class GetAllParkingVehicleQueryRequest:IRequest<ResponseDto<List<ParkingVehicleViewDto>>>
    {

    }
}
