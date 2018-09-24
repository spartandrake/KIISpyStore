using System;
using System.Collections.Generic;
using System.Text;
using KristopherCreelSpyStore.DAL.Repos.Base;
using KristopherCreelSpyStore.Models.Entities;
using KristopherCreelSpyStore.Models.ViewModels;

namespace KristopherCreelSpyStore.DAL.Repos.Interfaces
{
    public interface IShoppingCartRepo : IRepo<ShoppingCartRecord>
    {
        CartRecordWithProductInfo GetShoppingCartRecord(int customerId, int productId);
        IEnumerable<CartRecordWithProductInfo> GetShoppingCartRecords(int customerId);
        int Purchase(int customerId);
        ShoppingCartRecord Find(int customerId, int productId);
        int Update(ShoppingCartRecord entity, int? quantityInStock, bool persist = true);
        int Add(ShoppingCartRecord entity, int? quantityInStock, bool persist = true);
    }
}
