using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KristopherCreelSpyStore.DAL.EF;
using KristopherCreelSpyStore.DAL.Repos.Base;
using KristopherCreelSpyStore.Models.Entities;


namespace KristopherCreelSpyStore.DAL.Repos
{
    public class CategoryRepo : RepoBase<Category>
    {
        public CategoryRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public CategoryRepo()
        {
        }
        public override IEnumerable<Category> GetAll() => Table.OrderBy(x => x.CategoryName);
        public override IEnumerable<Category> GetRange(int skip, int take) => GetRange(Table.OrderBy(x => x.CategoryName), skip, take);

    }
}
