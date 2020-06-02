using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhone.Entities;

namespace WebPhone.DataAccess
{
    interface IPhoneRepository
    {
        IReadOnlyList<Phone> GetAll();
        Phone Get(int id);
        void Add(Phone phone);
        void Update(Phone phone);
        IReadOnlyList<Phone> GetPhoneByName(string name);
    }
}
