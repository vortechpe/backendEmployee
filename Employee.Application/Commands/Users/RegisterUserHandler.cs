using Employee.Application.Exceptions;
using Employee.Domain.Entities;
using Employee.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Commands.Users
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordService _passwordService;
        public RegisterUserHandler(IUserRepository repository, IPasswordService passwordService)
        {
            _repository = repository;
            _passwordService = passwordService;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _repository.GetByUsernameAsync(request.UserDto.Username);
            if(userExist != null) throw new ConflictException($"Empleado con número de documento {request.UserDto.Username} ya existe.");
            var salt = _passwordService.GenerateSalt();
            var hash = _passwordService.HashPassword(request.UserDto.Password, salt);

            var user = new User
            {
                Username = request.UserDto.Username,
                PasswordHash = hash,
                PasswordSalt = salt,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            };

            await _repository.CreateAsync(user);
            return user.Id;
        }
    }
}
