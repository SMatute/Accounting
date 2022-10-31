using Accounting.Application.Responses;
using MediatR;

namespace Accounting.Application.Common
{
    public class LoginUserCommand: IRequest<UserResponse>
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}
