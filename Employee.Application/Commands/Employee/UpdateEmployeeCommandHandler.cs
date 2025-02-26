using Employee.Application.Exceptions;
using Employee.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Employee.Application.Commands.Employee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateEmployeeCommandHandler(IEmployeeRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst("userId")?.Value;

            var employee = await _repository.GetByIdAsync(request.EmployeeId);
            if (employee == null) throw new NotFoundException($"Empleado con ID {request.EmployeeId} no encontrado.");

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.DateOfBirth = request.DateOfBirth;
            employee.HireDate = request.HireDate;
            employee.documentoNumber = request.documentoNumber;
            employee.Salary = request.Salary;
            employee.PositionId = request.PositionId;
            employee.UpdatedAt = DateTime.UtcNow;
            employee.AfpId = request.AfpId;
            employee.UpdatedBy = int.Parse(userId);

            await _repository.UpdateAsync(employee);
            return true;
        }
    }
}
