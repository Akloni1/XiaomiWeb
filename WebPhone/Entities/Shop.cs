using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPhone.Entities
{
    public class Shop : AuditableEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }


       
        [NotMapped]

        public string Address =>
            this.City + " " + this.Street + " " + this.House;


       
        [JsonIgnore]
        public virtual ICollection<Phone> Phones { get; set; }


        public Shop(string city, string street, int house)
        {
            City = city;
            Street = street;
            House = house;

        }

        public Shop()
        {

        }

    }
}
