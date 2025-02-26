using Employee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Queries.Master
{
    public record GetMasterQuery : IRequest<List<Afp>>;
    public record GetPositionQuery : IRequest<List<Position>>;
}
