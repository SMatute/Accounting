using Accounting.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.Queries
{
    public  class GetUsersQuery:IRequest<IEnumerable<User>>
    {
        public string Filter { get; set;}
    }
}
