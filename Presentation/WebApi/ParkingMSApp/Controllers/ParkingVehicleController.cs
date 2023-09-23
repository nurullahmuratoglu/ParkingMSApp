using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingMSApp.Application.Dtos.Car;
using ParkingMSApp.Application.Dtos.Response;
using ParkingMSApp.Application.Features.Commands.FixedFee.UpdateFixedFee;
using ParkingMSApp.Application.Features.Commands.ParkningVehicle.CreateParkingVehicle;
using ParkingMSApp.Application.Features.Commands.ParkningVehicle.ExitParking;
using ParkingMSApp.Application.Features.Commands.TireChangeService.CreateTireChangeService;
using ParkingMSApp.Application.Features.Commands.VehicleWashService.CreateVehicleWashService;
using ParkingMSApp.Application.Features.Queries.MotorPower.CalculateHorsePower;
using ParkingMSApp.Application.Features.Queries.ParkingVehicle.GetAllParkingVehicle;
using ParkingMSApp.Application.Features.Queries.ParkingVehicle.GetByClassNameVehicle;
using ParkingMSApp.Application.Features.Queries.ParkingVehicle.GetByIdParkingVehicle;

namespace ParkingMSApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingVehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkingVehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> SaveParkingVehicle(CreateParkingVehicleCommandRequest request)
        {
            return Ok(await _mediator.Send(request));

        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> ExitParking([FromQuery] ExitParkingCommandRequest request)
        {
            return Ok(await _mediator.Send(request));

        }
        [HttpGet]
        public async Task<ResponseDto<List<ParkingVehicleViewDto>>> GetParkingVehicle()
        {
            return await _mediator.Send(new GetAllParkingVehicleQueryRequest());
        }
        [HttpGet("Id")]
        public async Task<ResponseDto<ParkingVehicleViewDto>> GetByIdParkingVehicle([FromQuery] GetByIdParkingVehicleQueryRequest request)
        {
            return await _mediator.Send(request);
        }        
        [HttpGet("ClassName")]
        public async Task<ResponseDto<List<ParkingVehicleViewDto>>> GetClassNameParkingVehicle([FromQuery] GetByClassNameVehicleQueryRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> VehicleWashService([FromQuery] CreateVehicleWashServiceCommentRequest request)
        {
            return Ok(await _mediator.Send(request));

        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> TireChangeService([FromQuery] CreateTireChangeServiceCommandRequest request)
        {
            return Ok(await _mediator.Send(request));

        }
        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> CalculateHorsePower([FromQuery] CalculateHorsePowerQueryRequest request)
        {
            return Ok(await _mediator.Send(request));

        }


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> ChangeFixedFee([FromQuery] UpdateFixedFeeCommandRequest request)
        {
            return Ok(await _mediator.Send(request));

        }

    }
}
