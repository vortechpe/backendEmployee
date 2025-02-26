using Employee.Application.Commands.Employee;
using Employee.Application.Queries;
using Employee.Domain.Intefaces;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeId = await _mediator.Send(command);

            // Construir la URL del recurso creado
            var location = $"{Request.Scheme}://{Request.Host}{Url.Action(nameof(GetById), new { id = employeeId })}";

            return Created(location, new { id = employeeId });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? searchTerm, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllEmployeesQuery { PageNumber = pageNumber, PageSize = pageSize, SearchTerm = searchTerm };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery { EmployeeId = id });
            return employee != null ? Ok(employee) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand { EmployeeId = id });
            return result ? NoContent() : NotFound();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
        {
            if (id != command.EmployeeId) return BadRequest();
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
    }
}
