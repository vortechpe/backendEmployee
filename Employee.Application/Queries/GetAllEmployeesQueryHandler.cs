using AutoMapper;
using Employee.Application.DTOs;
using Employee.Domain.Common;
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
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, PagedResult<EmployeeDto>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }

        public async Task<PagedResult<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = _repository.GetAllAsync(request.PageNumber, request.PageSize, request.SearchTerm);
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees.Result.Items);

            return new PagedResult<EmployeeDto>(
                employeeDtos,
                employees.Result.TotalCount,
                employees.Result.PageNumber,
                employees.Result.PageSize
            );
        }

    }
}
