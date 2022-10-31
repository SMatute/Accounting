using Accounting.Application.Common;
using Accounting.Application.Mappers;
using Accounting.Application.Queries;
using Accounting.Application.Responses;
using Accounting.Domain.Entity;
using Accounting.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Accounting.Application.Handlers.CommanHandlers
{
    public  class GetUserHandler: IRequestHandler<GetUsersQuery,List<GetUserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetUserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
           var response = await _userRepository.GetUserByName(request.Filter);

            return response.Select(p => new GetUserResponse
            {
                UserName = p.UserName,
                CreatedAt = p.CreatedAt,
                IsActive = p.IsActive,
                UpdatedAt = p.UpdatedAt
            }).ToList();
            
            
        }

        
    }
}
