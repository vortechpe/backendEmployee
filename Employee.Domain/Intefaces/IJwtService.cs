using Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Intefaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token, out string username);
    }
}
