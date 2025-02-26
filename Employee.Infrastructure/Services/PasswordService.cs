using Employee.Domain.Intefaces;
using Employee.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public string GenerateSalt() => PasswordHelper.GenerateSalt();
        public string HashPassword(string password, string salt) => PasswordHelper.HashPassword(password, salt);
        public bool VerifyPassword(string password, string hash, string salt) => PasswordHelper.VerifyPassword(password, hash, salt);
    }
}
