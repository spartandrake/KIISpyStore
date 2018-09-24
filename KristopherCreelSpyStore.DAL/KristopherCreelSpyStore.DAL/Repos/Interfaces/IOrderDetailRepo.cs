using System;
using System.Collections.Generic;
using System.Text;
using KristopherCreelSpyStore.DAL.Repos.Base;
using KristopherCreelSpyStore.Models.Entities;
using KristopherCreelSpyStore.Models.ViewModels;

namespace KristopherCreelSpyStore.DAL.Repos.Interfaces
{
    public interface IOrderDetailRepo : IRepo<OrderDetail>
    {
        IEnumerable<OrderDetailWithProductInfo> GetCustomersOrdersWithDetails(int customerId);
        IEnumerable<OrderDetailWithProductInfo> GetSingleOrderWithDetails(int orderId);
    }
}
