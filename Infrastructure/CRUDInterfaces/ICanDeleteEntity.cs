using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.CRUDInterfaces
{
   public interface ICanDeleteEntity<TEntity> where TEntity : class
    {
        void Remove(TEntity entity);
    }
}
