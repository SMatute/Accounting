using Accounting.Domain.Repositories.Base;
using Accounting.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDBContext _applicationDBContext;

        public Repository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _applicationDBContext.Set<T>().AddAsync(entity);
            await _applicationDBContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _applicationDBContext.Set<T>().Remove(entity);
            await _applicationDBContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _applicationDBContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {   
           return await _applicationDBContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
