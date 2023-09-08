using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.Contract.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType
{
	public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveType;

		public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveType)
        {
			_mapper = mapper;
			_leaveType = leaveType;
		}
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//validate incoming data
			var validator = new CreateLeaveTypeCommandValidator(_leaveType);
			var validationResult=await validator.ValidateAsync(request);
			if(validationResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Request", validationResult);
			}
			// if valid convert to domain entity object
			var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
			// add to database
			await _leaveType.CreateAsync(leaveTypeToCreate);
			//return record id
			return leaveTypeToCreate.Id;
		}
	}
}
