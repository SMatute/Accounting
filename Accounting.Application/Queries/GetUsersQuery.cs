using Accounting.Application.Responses;
using Accounting.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.Queries
{
    public  class GetUsersQuery:IRequest<List<GetUserResponse>>
    {

        public GetUsersQuery(string filter)
        {
            Filter = filter;
        }

        public string Filter { get; set;}
    }
}
