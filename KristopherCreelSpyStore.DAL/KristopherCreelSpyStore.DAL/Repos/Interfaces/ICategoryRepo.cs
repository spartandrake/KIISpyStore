using System;
using System.Collections.Generic;
using System.Text;
using KristopherCreelSpyStore.DAL.Repos.Base;
using KristopherCreelSpyStore.Models.Entities;

namespace KristopherCreelSpyStore.DAL.Repos.Interfaces
{
    public interface ICategoryRepo : IRepo<Category>
    {
        IEnumerable<Category> GetAllWithProducts();
        Category GetOneWithProducts(int? id);
    }
}
