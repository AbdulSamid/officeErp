using FluentValidation;
using HR.LeaveManagement.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType
{
	public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
		{
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");
            RuleFor(p => p.DefaultDays)
                .LessThan(100).WithMessage("{PropertyName} cannot excced 100")
                .GreaterThan(1).WithMessage("{PropertyName} cannot be blank");
            RuleFor(q => q)
				.MustAsync(leaveTypeNameUnique)
				.WithMessage("Leave type already exist");
			_leaveTypeRepository = leaveTypeRepository;
		}

		private Task<bool> leaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
		{
			return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
		}
	}
}
