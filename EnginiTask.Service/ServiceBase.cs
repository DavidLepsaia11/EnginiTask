using EnginiTask.Service.Interfaces.Repositories;
using EnginiTask.Service.Interfaces.Services;
using System.Linq.Expressions;

namespace EnginiTask.Service
{
    public abstract class ServiceBase<TEntity, TRepository> : IQueryService<TEntity>
    where TEntity : class
    where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository _repository;

        protected ServiceBase(TRepository repository) =>
            _repository = repository;

        public virtual TEntity Get(params object[] id) =>
            _repository.Get(id);

        public virtual IQueryable<TEntity> Set() =>
            _repository.Set();
        
    }
}
