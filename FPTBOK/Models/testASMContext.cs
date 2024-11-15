using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FPTBOK.Models;

namespace FPTBOK.Models
{
    public partial class testASMContext : IdentityDbContext
    {
        public testASMContext()
        {
        }

        public testASMContext(DbContextOptions<testASMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Cart> Carts {get;set;} = null!;
        public virtual DbSet<Order> Orders { get; set; }
         public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:MyConnect");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<FPTBOK.Models.Order>? Order { get; set; }

        public DbSet<FPTBOK.Models.OrderDetail>? OrderDetail { get; set; }
    }
}
