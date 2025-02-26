using Employee.Domain.Entities;
using Employee.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Queries.Master
{
    public class GetPositionHandler : IRequestHandler<GetPositionQuery, List<Position>>
    {
        private readonly IMasterRepository _repository;

        public GetPositionHandler(IMasterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Position>> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            return await _repository.getPosition();
        }
    }
}
