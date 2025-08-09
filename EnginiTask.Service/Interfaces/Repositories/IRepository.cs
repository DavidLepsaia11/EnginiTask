using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnginiTask.Service.Interfaces.Repositories
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        TEntity Get(params object[] id);
        IQueryable<TEntity> Set();
    }
}
