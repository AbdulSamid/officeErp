using AutoMapper;
using HR.LeaveManagement.Application.Contract.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public GetLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
			_mapper = mapper;
			_leaveTypeRepository = leaveTypeRepository;
		}
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
		{
			//query database
			var leaveTypes = await _leaveTypeRepository.GetAsync();
			//convert data object to DTO object
			var data= _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
			//return list of DTO objects
			return data;
		}
	}
}
