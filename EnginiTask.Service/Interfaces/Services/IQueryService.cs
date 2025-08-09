using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnginiTask.Service.Interfaces.Services
{
    public interface IQueryService<TEntity>
    {
        TEntity Get(params object[] id);
        IQueryable<TEntity> Set();
    }
}
