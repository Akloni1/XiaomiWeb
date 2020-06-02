using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Infrastructure
{
    public class PhoneRepository : AuditableRepository<Phone>, IPhoneRepository
    {
       
            private readonly AppDbContext _dbContext;
            public PhoneRepository(AppDbContext dbContext) : base(dbContext)
            {
                _dbContext = dbContext;
            }

            public override Phone Get(int id)
            {
                return _dbContext.Phones.Include(b => b.Shop).FirstOrDefault(b => b.Id == id);
            }


            public IReadOnlyList<Phone> GetAll()
            {
                return _dbContext.Phones.Include(b => b.Shop).ToList();
            }

            public IReadOnlyList<Phone> GetPhoneByName(string name)
            {
                return _dbContext.Phones.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
            }
    }
}