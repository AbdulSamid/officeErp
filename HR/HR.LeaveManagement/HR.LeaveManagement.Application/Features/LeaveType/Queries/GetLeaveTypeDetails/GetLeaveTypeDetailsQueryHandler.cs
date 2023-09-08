using AutoMapper;
using HR.LeaveManagement.Application.Contract.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
	public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveType;

		public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveType)
        {
			_mapper = mapper;
			_leaveType = leaveType;
		}
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
		{
			//query database
			var leaveTypeDetail = await _leaveType.GetByIdAsync(request.Id);
			//verify that record exist
			if (leaveTypeDetail == null)
			{
				throw new NotFoundException(nameof(LeaveType),request.Id);
			}
			// convert data to DTO
			var data=_mapper.Map<LeaveTypeDetailsDto>(leaveTypeDetail);
			// retun DTO object
			return data;
		}
	}
}
