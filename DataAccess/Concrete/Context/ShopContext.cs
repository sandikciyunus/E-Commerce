using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Context
{
    public class ShopContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-EBEN970\SQLEXPRESS01;Database=ShopDb;integrated security=true");
        //    //optionsBuilder.UseSqlServer(@"Server=77.245.159.10\MSSQLSERVER2016;Database=sandikciyu_eticaret;user id=eticaret;password=kx997&jK;integrated security=true");
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}
