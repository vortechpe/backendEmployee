using Employee.Application.Exceptions;
using Employee.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Commands.Users
{
    class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _repository;
        private readonly IJwtService _jwtService;
        private readonly IPasswordService _passwordService;

        public LoginUserHandler(IUserRepository repository, IJwtService jwtService, IPasswordService passwordService)
        {
            _repository = repository;
            _jwtService = jwtService;
            _passwordService = passwordService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByUsernameAsync(request.UserDto.Username);
            if (user == null || !_passwordService.VerifyPassword(request.UserDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new UnauthorizedException("Usuario o contraseña incorrectos");
            }

            return _jwtService.GenerateToken(user);
        }
    }
}
