using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPhone.DataAccess.CRUDInterfaces
{
  public  interface ICanGetEntity<TEntity> where TEntity : class
    {
        TEntity Get(int id);
    }
}
