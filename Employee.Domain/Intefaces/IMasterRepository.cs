using Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Intefaces
{
    public interface IMasterRepository
    {
        Task<List<Afp>> getAfp();
        Task<List<Position>> getPosition();
    }
}
