﻿using HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Command.DeleteLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveTypeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LeaveTypeController(IMediator mediator)
		{
			this._mediator = mediator;
		}
        // GET: api/<LeaveTypeController>
        [HttpGet]
		public async Task<List<LeaveTypeDto>> Get()
		{
			var leaveTypes = await _mediator.Send(new GetLeaveTypeQuery());
			return leaveTypes;
		}

		// GET api/<LeaveTypeController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<LeaveTypeDetailsDto>> Get(int id)
		{
			var leaveType=await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
			return Ok(leaveType);
		}

		// POST api/<LeaveTypeController>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Post(CreateLeaveTypeCommand leaveType)
		{
			var response = await _mediator.Send(leaveType);
			return CreatedAtAction(nameof(Get),new {id=response});
		}

		// PUT api/<LeaveTypeController>/5
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Put(UpdateLeaveTypeCommand leaveType)
		{
			await _mediator.Send(leaveType);
			return NoContent();
		}

		// DELETE api/<LeaveTypeController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(int id)
		{
			var command=new DeleteLeaveTypeCommand { Id=id};
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
