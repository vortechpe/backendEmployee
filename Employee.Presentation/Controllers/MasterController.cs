using Employee.Application.Queries;
using Employee.Application.Queries.Master;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MasterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("afps")]
        public async Task<IActionResult> GetAfp()
        {
            
            var result = await _mediator.Send(new GetMasterQuery());

            return Ok(result);
        }
        [HttpGet("positions")]
        public async Task<IActionResult> GetPosition()
        {
            var result = await _mediator.Send(new GetPositionQuery());

            return Ok(result);
        }
    }
}
