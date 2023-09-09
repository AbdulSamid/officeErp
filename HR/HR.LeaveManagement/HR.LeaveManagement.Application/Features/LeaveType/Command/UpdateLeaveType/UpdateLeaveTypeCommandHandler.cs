using AutoMapper;
using HR.LeaveManagement.Application.Contract.Logging;
using HR.LeaveManagement.Application.Contract.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType
{
	public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveType;
		private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

		public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveType, IAppLogger<UpdateLeaveTypeCommandHandler> logger)
        {
			_mapper = mapper;
			_leaveType = leaveType;
			_logger = logger;
		}
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//validate incoming data
			var validator=new UpdateLeaveTypeCommandValidator(_leaveType);
			var validationResult = await validator.ValidateAsync(request);
			if(validationResult.Errors.Any())
			{
				_logger.LogWarning("Validation Error in Update Request for {0} - {1}",nameof(LeaveType), request.Id);
				throw new BadRequestException("Invalid Leave Type", validationResult);
			}
			//if valid convert to domain entity
			var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);
			//update data base
			await _leaveType.UpdateAsync(leaveTypeToUpdate);
			//return null
			return Unit.Value;
		}
	}
}
