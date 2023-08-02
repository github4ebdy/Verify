using EFCore.BulkExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Common.Entity;

 
 
using System.Data;
using System.Linq.Expressions;
 

namespace Common.Infra
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MainContext context;
        private readonly DbSet<T> entities;
        //private readonly ICurrentSession currentSession;
        //private readonly IAuditService Auditlog;
        public Repository(MainContext context)
        {
            this.context = context;
            entities = context.Set<T>();
            //this.currentSession = currentSession;
            //this.Auditlog = Auditlog;
        }


        public async Task<T?> InsertAsync(T entity)
        {
            
            await entities.AddAsync(entity);
            if ((await SaveChangesAsync()) > 0)
            {
                 
                return entity;
            }
             
            return null;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
        public async Task<bool> InsertUpdate(T entity)
        {

            return await InsertUpdate(new List<T> { entity });
        }

        public async Task<bool> InsertUpdate(List<T> entity)
        {
            var bulkconfig = new BulkConfig
            {
           
                DoNotUpdateIfTimeStampChanged = true,

                IncludeGraph = true,
                SetOutputIdentity= true,
                PreserveInsertOrder = true,

            };

            

            await context.BulkInsertOrUpdateAsync(entity, bulkconfig);

            await SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetByIdAsync(long id, List<string>? includes)
        {
            var returnData = entities.Where(s => s.Id == id );
            if (includes != null)
            {
                foreach (var item in includes)
                {

                    await returnData.Include(item).LoadAsync();
                }
            }
            return await returnData.ToListAsync();
        }
        public async Task<bool> DeleteBulk(Expression<Func<T, bool>> WhereCondition)
        {
            var entitylist = (await FindAsync(WhereCondition)).ToList();

            entities.Where(WhereCondition)
            .ExecuteUpdate(p =>
             p.SetProperty(x => x.IsDeleted, x => true)
            );

            await SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var returnData = entities.AsQueryable();
            returnData = returnData.Where(x => !x.IsDeleted);
            returnData = returnData.Where(predicate);
            return await returnData.ToListAsync();
        }


    }
}
