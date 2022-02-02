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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpMgtContext context;

        public EmployeeRepository(EmpMgtContext _context)
        {
            context = _context;
        }
        public async Task<bool> Create(Employee entity)
        {
            await context.Employees.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Employee entity)
        {
            context.Employees.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Employee>> FindAll()
        {
            var user = await context.Employees.ToListAsync();
            return user;
        }

        public async Task<Employee> FindById(int id)
        {
            var user = await context.Employees.FindAsync(id);
            return user;
        }

        public async Task<bool> isExist(int id)
        {
            var exists = await context.Employees.AnyAsync(q => q.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Employee entity)
        {
            context.Employees.Update(entity);
            return await Save();
        }

        public async Task<Employee> GetFirstOrDefault(Expression<Func<Employee, bool>> predicate)
        {
            return await context.Employees.FirstOrDefaultAsync(predicate);
        }

        public async Task<Employee> GetLastOrDefault(Expression<Func<Employee, bool>> predicate)
        {
            return await context.Employees.LastOrDefaultAsync(predicate);
        }

        public async Task<Employee> GetSingleOrDefault(Expression<Func<Employee, bool>> predicate)
        {
            return await context.Employees.SingleOrDefaultAsync(predicate);
        }

    }
}
