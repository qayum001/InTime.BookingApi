using InTime.Booking.Application.Common.Enum;
using InTime.Booking.Application.DTOs.Schedule;
using InTime.Booking.Application.Features.Schedule.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InTime.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("v1/shcedule/{type}")]
        public async Task<ActionResult<ScheduleDto>> GetSchedule(
            [Required] ScheduleType type,
            [Required] Guid id,
            [Required] DateTime dateFrom,
            [Required] DateTime dateTo)
        {
            var result = await _mediator.Send(new GetScheduleQuery(type, id, dateFrom, dateTo));

            return Ok(result);
        }
    }
}