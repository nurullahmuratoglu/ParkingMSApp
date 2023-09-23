using MediatR;
using Microsoft.AspNetCore.Http;
using ParkingMSApp.Application.Dtos.Response;
using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Application.UnitOfWork;

namespace ParkingMSApp.Application.Features.Commands.FixedFee.UpdateFixedFee
{
    public class UpdateFixedFeeCommandHandler : IRequestHandler<UpdateFixedFeeCommandRequest, ResponseDto<NoContentDto>>
    {
        private readonly IFixedFeeRepository _fixedFeeRepository;
        private readonly IUnitOfWorks _unitOfWorks;

        public UpdateFixedFeeCommandHandler(IFixedFeeRepository fixedFeeRepository, IUnitOfWorks unitOfWorks)
        {
            _fixedFeeRepository = fixedFeeRepository;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(UpdateFixedFeeCommandRequest request, CancellationToken cancellationToken)
        {
            var fixedFees = _fixedFeeRepository.GetAll().ToList();
            foreach (var fixedFee in fixedFees)
            {
                if (fixedFee.Id == 1)
                {
                    fixedFee.HourFee = request.Fee * 3;
                }
                else if (fixedFee.Id == 2)
                {
                    fixedFee.HourFee = request.Fee * 2;
                }
                else if (fixedFee.Id == 3)
                {
                    fixedFee.HourFee = request.Fee;
                }
                _fixedFeeRepository.Update(fixedFee);
            }
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
