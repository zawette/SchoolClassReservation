using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Salles.Commands;
using Application.Salles.DTO;
using Application.Salles.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SchoolClassReservation.Controllers
{
    [Route("api/Salles")]
    [ApiController]
    public class SalleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalleDto>>> GetAllSalles()
        {
            var query = new GetAllSallesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalleDto>> GetSalle([FromRoute] Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetSalleQuery() { Id = id });
                return Ok(result);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> CreateSalle([FromBody] CreateSalleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return NoContent(); // TEMPORARY
            }
            catch (DupplicateUniqueFieldException e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalle(Guid id, [FromBody] UpdateSalleCommand command)
        {
            try
            {
                command.Id = id;
                var result = await _mediator.Send(command);
                return NoContent();
            }
            catch (DupplicateUniqueFieldException e)
            {
                return BadRequest(e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalle([FromRoute] Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteSalleCommand() { Id = id });
                return NoContent();
            }
            catch (FieldUsedInReservationException e)
            {
                return BadRequest(e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }


        }
    }
}
