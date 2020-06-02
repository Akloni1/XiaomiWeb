using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.CRUDInterfaces
{
   public interface ICanAddEntity<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
    }
}
