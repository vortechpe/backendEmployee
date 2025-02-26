using Employee.Application.Commands.Employee;
using Employee.Domain.Intefaces;
using Employee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Application.Exceptions;
using Microsoft.AspNetCore.Http;


namespace Employee.Application.Commands.Employee
{

    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateEmployeeHandler(IEmployeeRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst("userId")?.Value;
            var employee = await _repository.GetByDocumentNumber(request.documentoNumber);
            if (employee != null)
            {
                throw new ConflictException($"Empleado con número de documento {request.documentoNumber} ya existe.");
            }
            var employeeCreate = new Employees
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                documentoNumber = request.documentoNumber,
                HireDate = request.HireDate,
                Salary = request.Salary,
                PositionId = request.PositionId,
                UpdatedAt = DateTime.UtcNow,
                AfpId = request.AfpId,
                CreatedBy = int.Parse(userId),
                IsActive = true
            };

            await _repository.AddAsync(employeeCreate);
            return employeeCreate.EmployeeId;
        }
    }
}
