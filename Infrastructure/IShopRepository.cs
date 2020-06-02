using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.CRUDInterfaces;
using Entities;

namespace Infrastructure
{
    public interface IShopRepository : ICanAddEntity<Shop>, ICanUpdateEntity<Shop>, ICanGetEntity<Shop>
    {
        IReadOnlyList<Shop> GetShopByStreet(string street);
    }
}
