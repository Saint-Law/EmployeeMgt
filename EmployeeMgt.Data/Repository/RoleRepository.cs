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
    public class RoleRepository : IRoleRepository
    {
        private readonly EmpMgtContext context;

        public RoleRepository(EmpMgtContext _context)
        {
            context = _context;
        }
        public async Task<bool> Create(Role entity)
        {
            await context.Roles.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Role entity)
        {
            context.Roles.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Role>> FindAll()
        {
            var roles = await context.Roles.ToListAsync();
            return roles;
        }

        public async Task<Role> FindById(int id)
        {
            var roles = await context.Roles.FindAsync(id);
            return roles;
        }

        public async Task<bool> isExist(int id)
        {
            var exists = await context.Roles.AnyAsync(q => q.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Role entity)
        {
            context.Roles.Update(entity);
            return await Save();
        }

        public async Task<Role> GetFirstOrDefault(Expression<Func<Role, bool>> predicate)
        {
            return await context.Roles.FirstOrDefaultAsync(predicate);
        }

        public async Task<Role> GetLastOrDefault(Expression<Func<Role, bool>> predicate)
        {
            return await context.Roles.LastOrDefaultAsync(predicate);
        }

        public async Task<Role> GetSingleOrDefault(Expression<Func<Role, bool>> predicate)
        {
            return await context.Roles.SingleOrDefaultAsync(predicate);
        }

    }
}
