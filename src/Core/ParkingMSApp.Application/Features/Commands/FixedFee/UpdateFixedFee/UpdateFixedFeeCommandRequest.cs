using MediatR;
using ParkingMSApp.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMSApp.Application.Features.Commands.FixedFee.UpdateFixedFee
{
    public class UpdateFixedFeeCommandRequest:IRequest<ResponseDto<NoContentDto>>
    {
        public int Fee { get; set; }
    }
}
