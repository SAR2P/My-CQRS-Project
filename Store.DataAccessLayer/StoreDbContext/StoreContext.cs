using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Entities.BuisnessEntities.Products.Entities;
using Store.Entities.BuisnessEntities.User.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.StoreDbContext
{
    public class StoreContext : IdentityDbContext<Users> 
    {
        public StoreContext(DbContextOptions<StoreContext> options): base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(item.ClrType).Property<string>("CreateBy").HasMaxLength(200);
                modelBuilder.Entity(item.ClrType).Property<string>("UpdateBy").HasMaxLength(200);
                modelBuilder.Entity(item.ClrType).Property<DateTime>("CreatedDateTime");
                modelBuilder.Entity(item.ClrType).Property<DateTime>("UpdateDateTime");
            }
        }

        public DbSet<Product> Products { get; set; }
    }
}
