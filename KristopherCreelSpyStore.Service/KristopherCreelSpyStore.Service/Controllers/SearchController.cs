using KristopherCreelSpyStore.DAL.Repos.Interfaces;
using KristopherCreelSpyStore.Models.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KristopherCreelSpyStore.Service.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private IProductRepo Repo { get; set; }
        public SearchController(IProductRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("{searchString}", Name = "SearchProducts")]
        public IEnumerable<ProductAndCategoryBase> Search(string searchString) => Repo.Search(searchString);
        //http://localhost:8477/api/search/pursuade%20anyone
    }
}
