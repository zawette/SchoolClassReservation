using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Reservations.Commands;
using Application.Reservations.DTO;
using Application.Reservations.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SchoolClassReservation.Controllers
{
    [Route("api/Reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ReservationController> logger;

        public ReservationController(IMediator mediator,ILogger<ReservationController> logger)
        {
            _mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetAllReservations()
        {
            var query = new GetAllReservationsQuery();
            var result= await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetReservation([FromRoute]Guid id)
        {
            try
            {
                var query = new GetReservationQuery() { Id = id };
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (EntityNotFoundException e)
            {
                logger.LogError(e.Message);
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return NoContent(); // TEMPORARY
            }
            catch (ClassRoomAlreadyReservedAtThatTimePeriodException e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            catch (InstructorAlreadyAssignedAtThatTimePeriodException e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation([FromRoute]Guid id, [FromBody] UpdateReservationCommand command)
        {
            try
            {
                command.Id = id;
                var result = await _mediator.Send(command);
                return NoContent();
            }
            catch (ClassRoomAlreadyReservedAtThatTimePeriodException e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            catch (InstructorAlreadyAssignedAtThatTimePeriodException e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            catch (EntityNotFoundException e)
            {
                logger.LogError(e.Message);
                return NotFound(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation([FromRoute]Guid id)
        {
            try
            {
                var command = new DeleteReservationCommand() { Id = id };
                var result = await _mediator.Send(command);
                return NoContent();

            }
            catch (EntityNotFoundException e)
            {
                logger.LogError(e.Message);
                return NotFound(e.Message);
            }

        }
    }
}
