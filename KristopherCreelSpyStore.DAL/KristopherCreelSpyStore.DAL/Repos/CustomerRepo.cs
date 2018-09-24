using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KristopherCreelSpyStore.DAL.EF;
using KristopherCreelSpyStore.DAL.Repos.Base;
using KristopherCreelSpyStore.DAL.Repos.Interfaces;
using KristopherCreelSpyStore.Models.Entities;

namespace KristopherCreelSpyStore.DAL.Repos
{
    public class CustomerRepo : RepoBase<Customer>, ICustomerRepo
    {
        public CustomerRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public CustomerRepo() : base()
        {
        }

        public override IEnumerable<Customer> GetAll()
            => Table.OrderBy(x => x.FullName);

        public override IEnumerable<Customer> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.FullName), skip, take);
    }
}
