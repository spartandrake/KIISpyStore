﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KristopherCreelSpyStore.DAL.Repos.Interfaces;
using KristopherCreelSpyStore.Models.ViewModels.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KristopherCreelSpyStore.Service.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoryRepo Repo { get; set; }
        private IProductRepo ProductRepo { get; set; }

        public CategoryController(ICategoryRepo repo, IProductRepo productRepo)
        {
            Repo = repo;
            ProductRepo = productRepo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Repo.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = Repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Json(item);
        }

        [HttpGet("{categoryId}/products")]
        public IEnumerable<ProductAndCategoryBase> GetProductsForCategory(int categoryId) => ProductRepo.GetProductsForCategory(categoryId).ToList();
    }
}
