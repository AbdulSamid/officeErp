using AutoMapper;
using HR.LeaveManagement.Application.Contract.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.DeleteLeaveType
{
	public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
	{
	
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
			
			_leaveTypeRepository = leaveTypeRepository;
		}
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			
			//retrieve domain entity
			var leaveTypeToDelete =await _leaveTypeRepository.GetByIdAsync(request.Id);
			//varify that record exist
			if(leaveTypeToDelete==null)
			{
			throw new NotFoundException(nameof(Domain.LeaveType),request.Id);
			}
			//remove from database
			await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
			//retun null i.e. Unit.Value
			return Unit.Value;
		}
	}
}
