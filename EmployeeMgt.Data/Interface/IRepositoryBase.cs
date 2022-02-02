using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Data.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<ICollection<T>> FindAll();
        Task<T> FindById(int id);
        Task<bool> isExist(int id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> GetLastOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleOrDefault(Expression<Func<T, bool>> predicate);
        Task<bool> Save();
    }
}
