using System;
using System.Collections.Generic;
using System.Text;
using KristopherCreelSpyStore.DAL.Repos.Base;
using KristopherCreelSpyStore.Models.Entities;
using KristopherCreelSpyStore.Models.ViewModels;

namespace KristopherCreelSpyStore.DAL.Repos.Interfaces
{
    public interface IOrderRepo : IRepo<Order>
    {
        IEnumerable<Order> GetOrderHistory(int customerId);
        OrderWithDetailsAndProductInfo GetOneWithDetails(int customerId, int orderId);
    }
}
