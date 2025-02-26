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
    public class GetAFPsHandler : IRequestHandler<GetMasterQuery, List<Afp>>
    {
        private readonly IMasterRepository _repository;

        public GetAFPsHandler(IMasterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Afp>> Handle(GetMasterQuery request, CancellationToken cancellationToken)
        {
            return await _repository.getAfp();
        }
    }

}
