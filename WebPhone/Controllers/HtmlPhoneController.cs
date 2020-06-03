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
    [Route("html/[controller]")]
    public class HtmlPhoneController : Controller
    {
        private IPhoneRepository _phoneRepository { get; set; }

        public HtmlPhoneController(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_phoneRepository.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            return View(_phoneRepository.Get(id));
        }

        [HttpGet("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Phone phone)
        {
            try
            {
                _phoneRepository.Add(phone);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("update/{id}")]
        public ActionResult Edit(int id)
        {
            return View(_phoneRepository.Get(id));
        }

        [HttpPost("update/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] Phone phone)
        {
            try
            {
                _phoneRepository.Update(phone);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
