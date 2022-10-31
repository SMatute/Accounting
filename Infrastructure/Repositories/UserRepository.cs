using Accounting.Domain.Entity;
using Accounting.Domain.Repositories;
using Accounting.Infrastructure.Persistence;
using Accounting.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;



namespace Accounting.Infrastructure.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext applicationDBContext): base(applicationDBContext) { }
       
        public async Task<List<User>> GetUserByName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return await _applicationDBContext.Users.ToListAsync();
            }
            return await _applicationDBContext.Users.Where(x => x.UserName == username).ToListAsync();
        }

        public async Task Create(User user)
        {
           await _applicationDBContext.AddAsync(user);
        }

    }
}
