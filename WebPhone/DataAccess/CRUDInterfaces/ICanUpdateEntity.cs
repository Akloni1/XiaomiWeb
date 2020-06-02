using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPhone.DataAccess.CRUDInterfaces
{
    public interface ICanUpdateEntity<TEntity> where TEntity : class
    {
        void Update(TEntity entity);
    }
}
