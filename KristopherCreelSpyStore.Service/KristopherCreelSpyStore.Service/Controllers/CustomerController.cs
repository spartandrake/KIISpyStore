using KristopherCreelSpyStore.DAL.Repos.Interfaces;
using KristopherCreelSpyStore.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KristopherCreelSpyStore.Service.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerRepo Repo { get; set; }
        public CustomerController(ICustomerRepo repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public IEnumerable<Customer> Get() => Repo.GetAll();

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = Repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
