using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<PurchaseRequestItem> PurchaseRequestItems { get; set; }
        public DbSet<Quatation> Quatations { get; set; }
        public DbSet<SpecificationCategory> SpecificationCategories { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Specification> Specification { get; set; }

        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<UserPerchaseRequest> UserPerchaseRequests { get; set; }
    }
}

//**************