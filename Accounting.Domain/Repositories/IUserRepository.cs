using Accounting.Domain.Entity;
using Accounting.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<IEnumerable<User>> GetUserByName(string name);

        Task Create(User user);
    }
}
