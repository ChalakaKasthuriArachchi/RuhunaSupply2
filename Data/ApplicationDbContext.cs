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
        public DbSet<Category1> Category1 { get; set; }
        public DbSet<Category2> Category2 { get; set; }
        public DbSet<Category3> Category3 { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<PurchaseRequestItem> PurchaseRequestItems { get; set; }
        public DbSet<Quatation> Quatations { get; set; }
        public DbSet<SpecificationCategory> SpecificationCategories { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Specification> Specification { get; set; }

        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<UserPurchaseRequest> UserPurchaseRequests { get; set; }

        public DbSet<QuatationItem> QuatationItems { get; set; }

        public DbSet<UserName> UserNames { get; set; }

        public DbSet<PurchaseRequestItemSpecification> PurchaseRequestItemSpecifications { get; set; }

        public DbSet<QuatationItemSpecification> QuatationItemSpecifications { get; set; }
       

        public DbSet<Category1> Category1s { get; set; }
        public DbSet<Category2> Category2s { get; set; }
        public DbSet<Category3> Category3s { get; set; }

    }
}

//**************