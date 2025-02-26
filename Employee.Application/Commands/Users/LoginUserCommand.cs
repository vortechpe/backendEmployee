using Employee.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Commands.Users
{
    public class LoginUserCommand : IRequest<string>
    {
        public LoginUserDto UserDto { get; set; }
    }
}
