using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhone.DataAccess.CRUDInterfaces;
using WebPhone.Entities;

namespace WebPhone.DataAccess
{
    interface IShopRepository : ICanAddEntity<Shop>, ICanUpdateEntity<Shop>, ICanGetEntity<Shop>
    {
        IReadOnlyList<Shop> GetShopByStreet(string street);
    }
}
