using Employee.Application.Exceptions;
using Employee.Domain.Entities;
using Employee.Domain.Intefaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Commands.Employee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteEmployeeCommandHandler(IEmployeeRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst("userId")?.Value;
            var employee = await _repository.GetByIdAsync(request.EmployeeId);
            if (employee == null)
                throw new NotFoundException($"Empleado con ID {request.EmployeeId} no encontrado.");
            employee.IsActive = false;
            employee.UpdatedAt = DateTime.UtcNow;
            employee.UpdatedBy = int.Parse(userId);
            await _repository.DeleteAsync(employee);
            return true;
        }
    }
}
