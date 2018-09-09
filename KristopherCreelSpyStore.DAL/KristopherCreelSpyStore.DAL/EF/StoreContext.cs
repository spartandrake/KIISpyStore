﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using KristopherCreelSpyStore.Models.Entities;

namespace KristopherCreelSpyStore.DAL.EF
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {
        }
        public StoreContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SpyStore;Trusted_Connection=True;MultipleActiveResultSets=true;", 
                    options => options.EnableRetryOnFailure()
                    //options => options.ExecutionStrategy(c=> new MyExecutionStrategy(c))
                    );
            }
        }
        public DbSet<Category> Categories { get; set; }
    }
}
