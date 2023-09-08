using AutoMapper;
using HR.LeaveManagement.Application.Contract.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType
{
	public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveType;

		public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveType)
        {
			_mapper = mapper;
			_leaveType = leaveType;
		}
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//validate incoming data
			var validator=new UpdateLeaveTypeCommandValidator(_leaveType);
			var validationResult = await validator.ValidateAsync(request);
			if(validationResult.Errors.Any())
			{
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
