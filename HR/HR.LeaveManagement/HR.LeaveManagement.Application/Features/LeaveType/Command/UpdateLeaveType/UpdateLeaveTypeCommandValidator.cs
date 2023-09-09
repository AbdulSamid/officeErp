using FluentValidation;
using HR.LeaveManagement.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType
{
	public class UpdateLeaveTypeCommandValidator :AbstractValidator<UpdateLeaveTypeCommand>
	{
		private readonly ILeaveTypeRepository _leaveType;

		public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveType)
        {
			_leaveType = leaveType;
			RuleFor(p => p.Id)
				.NotNull()
				.MustAsync(LeaveTypeMustExist);
			RuleFor(p => p.Name)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull()
				.MaximumLength(70).WithMessage("{PropertyName} can not exceed 70 characters");
			RuleFor(p => p.DefaultDays)
				.LessThan(100).WithMessage("{PropertyName} can not exceed 100")
				.GreaterThan(1).WithMessage("{PropertyName} can not be less than 1");
			RuleFor(q => q)
				.MustAsync(LeaveTypeNameUnique)
				.WithMessage("Leave type already exists");

		}

		private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
		{
			var leaveType = await _leaveType.GetByIdAsync(id);
			return leaveType != null;
		}

		private Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
		{
			return _leaveType.IsLeaveTypeUnique(command.Name);
		}
	}
}
