using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Instructors.Commands;
using Application.Instructors.DTO;
using Application.Instructors.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolClassReservation.Controllers
{
    [Route("api/Instructors")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstructorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorDto>>> GetAllInstructors()
        {
            var query = new GetAllInstructorsQuery();
            var result= await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorDto>> GetInstructor([FromRoute] Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetInstructorQuery() { Id = id });
                return Ok(result);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateInstructor([FromBody] CreateInstructorCommand command)
        {
            var result = await _mediator.Send(command);
            return NoContent(); // TEMPORARY
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(Guid id, [FromBody] UpdateInstructorCommand command)
        {
            try
            {
                command.Id = id;
                var result = await _mediator.Send(command);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor([FromRoute] Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteInstructorCommand() { Id = id });
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }

        }
    }
}
