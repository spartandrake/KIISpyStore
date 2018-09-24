using System;
using System.Collections.Generic;
using System.Text;
using KristopherCreelSpyStore.DAL.Repos.Base;
using KristopherCreelSpyStore.Models.Entities;
using KristopherCreelSpyStore.Models.ViewModels.Base;

namespace KristopherCreelSpyStore.DAL.Repos.Interfaces
{
    public interface IProductRepo : IRepo<Product>
    {
        IEnumerable<ProductAndCategoryBase> Search(string searchString);
        IEnumerable<ProductAndCategoryBase> GetAllWithCategoryName();
        IEnumerable<ProductAndCategoryBase> GetProductsForCategory(int id);
        IEnumerable<ProductAndCategoryBase> GetFeaturedWithCategoryName();
        ProductAndCategoryBase GetOneWithCategoryName(int id);
    }
}
