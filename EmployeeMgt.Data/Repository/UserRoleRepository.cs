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
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly EmpMgtContext context;

        public UserRoleRepository(EmpMgtContext _context)
        {
            context = _context;
        }
        public async Task<bool> Create(UserRole entity)
        {
            await context.UserRoles.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(UserRole entity)
        {
            context.UserRoles.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<UserRole>> FindAll()
        {
            var userRole = await context.UserRoles.ToListAsync();
            return userRole;
        }

        public async Task<UserRole> FindById(int id)
        {
            var userRole = await context.UserRoles.FindAsync(id);
            return userRole;
        }

        public async Task<bool> isExist(int id)
        {
            var exists = await context.UserRoles.AnyAsync(q => q.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(UserRole entity)
        {
            context.UserRoles.Update(entity);
            return await Save();
        }

        public async Task<UserRole> GetFirstOrDefault(Expression<Func<UserRole, bool>> predicate)
        {
            return await context.UserRoles.FirstOrDefaultAsync(predicate);
        }

        public async Task<UserRole> GetLastOrDefault(Expression<Func<UserRole, bool>> predicate)
        {
            return await context.UserRoles.LastOrDefaultAsync(predicate);
        }

        public async Task<UserRole> GetSingleOrDefault(Expression<Func<UserRole, bool>> predicate)
        {
            return await context.UserRoles.SingleOrDefaultAsync(predicate);
        }

    }
}
