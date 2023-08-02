using Common.Entity;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infra
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetByIdAsync(long id, List<string>? includes);
        Task<T?> InsertAsync(T entity);
        Task<bool> InsertUpdate(T entity);
        Task<bool> DeleteBulk(Expression<Func<T, bool>> WhereCondition);
    }
}
