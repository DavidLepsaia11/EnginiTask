using EnginiTask.Repository.Database;
using EnginiTask.Service.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EnginiTask.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
    where TEntity : class
    {
        private readonly EmployeesDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(EmployeesDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }

        public virtual TEntity Get(params object[] id) =>
              _dbSet.Find(id);

        public virtual IQueryable<TEntity> Set() =>
               _context.Set<TEntity>();
    }
}
