using Accounting.Application.Common;
using Accounting.Application.Responses;
using Accounting.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accounting.Application.Mappers;
using Accounting.Domain.Entity;

namespace Accounting.Application.Handlers.CommanHandlers
{
    public class CreateUserHandler: IRequestHandler<LoginUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var UserEntity = UserMapper.Mapper.Map<User>(request);
            if (UserEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var user = new User
            {
                CreatedAt = DateTime.Today,
                UserName = UserEntity.UserName

            };


            await _userRepository.Create(user);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(null);
            return userResponse;
        }
    }
}
