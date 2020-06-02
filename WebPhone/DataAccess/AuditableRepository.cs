using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhone.Entities;

namespace WebPhone.DataAccess
{
    public abstract class AuditableRepository<TEntity> : Repository<TEntity> where TEntity : AuditableEntity
    {
        public AuditableRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public override void Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            base.Add(entity);
            SaveChanges();
        }

        public override void Update(TEntity entity)
        {
            entity.ModifiedAt = DateTime.Now;
            base.Update(entity);
            SaveChanges();
        }
    }
}
