using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Entities;
using Infrastructure;

namespace WebPhone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private IPhoneRepository _phoneRepository { get; set; }

        public PhoneController(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        [HttpGet]
        public IEnumerable<Phone> Get()
        {
            return _phoneRepository.GetAll();
        }


        [HttpGet("{id}")]
        public Phone Get(int id)
        {
            return _phoneRepository.Get(id);
        }


        [HttpPost]
        public ActionResult Post([FromBody] Phone phone)
        {
            _phoneRepository.Add(phone);
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Phone phone)
        {
            _phoneRepository.Update(phone);
            return Ok();
        }
    }
}
