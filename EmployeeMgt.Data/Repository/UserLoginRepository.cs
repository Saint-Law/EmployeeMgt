using EmployeeMgt.Data.Interface;
using EmployeeMgt.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Data.Repository
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly EmpMgtContext context;

        public UserLoginRepository(EmpMgtContext _context)
        {
            context = _context;
        }
        public async Task<bool> Create(UserLogin entity)
        {
            await context.UserLogins.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(UserLogin entity)
        {
            context.UserLogins.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<UserLogin>> FindAll()
        {
            var userLogin = await context.UserLogins.ToListAsync();
            return userLogin;
        }

        public async Task<UserLogin> FindById(int id)
        {
            var userLogin = await context.UserLogins.FindAsync(id);
            return userLogin;
        }

        public async Task<bool> isExist(int id)
        {
            var exists = await context.UserLogins.AnyAsync(r => r.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(UserLogin entity)
        {
            context.UserLogins.Update(entity);
            return await Save();
        }

        public async Task<UserLogin> GetFirstOrDefault(Expression<Func<UserLogin, bool>> predicate)
        {
            return await context.UserLogins.FirstOrDefaultAsync(predicate);
        }

        public async Task<UserLogin> GetLastOrDefault(Expression<Func<UserLogin, bool>> predicate)
        {
            return await context.UserLogins.LastOrDefaultAsync(predicate);
        }

        public async Task<UserLogin> GetSingleOrDefault(Expression<Func<UserLogin, bool>> predicate)
        {
            return await context.UserLogins.SingleOrDefaultAsync(predicate);
        }
    }
}
