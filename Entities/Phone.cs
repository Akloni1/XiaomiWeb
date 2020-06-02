using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Phone : AuditableEntity
    {
        public string Name { set; get; }
        public string ShorDesc { set; get; }
        public string LongDesc { set; get; }
        public ushort Price { set; get; }



        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }

        public Phone(int shopId, string name, string shorDesc, string longDesc, ushort price)
        {
            ShopId = shopId;
            Name = name;
            ShorDesc = shorDesc;
            LongDesc = longDesc;
            Price = price;
        }

        public Phone()
        {

        }
    }
}
