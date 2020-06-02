using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Infrastructure
{
    public class ShopRepository : AuditableRepository<Shop>, IShopRepository
    {
        private readonly AppDbContext _dbContext;
        public ShopRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IReadOnlyList<Shop> GetShopByStreet(string street)
        {
            return _dbContext.Shops.Where(x => x.Street.ToLower().Contains(street.ToLower())).ToList();
        }
    }
}
