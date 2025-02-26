using AutoMapper;
using Employee.Application.DTOs;
using Employee.Application.Exceptions;
using Employee.Domain.Entities;
using Employee.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Queries
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.EmployeeId);
            if (employee == null)
                throw new NotFoundException($"Empleado con ID {request.EmployeeId} no encontrado.");

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
         }
    }
}