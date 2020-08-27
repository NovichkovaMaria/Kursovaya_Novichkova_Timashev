using BeautySalonDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonDatabase
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Server=(local)\SQLEXPRESS;Initial Catalog=BeautyShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Client> Clients { set; get; }

        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<OrderService> OrderServices { set; get; }

        public virtual DbSet<Payment> Payments { set; get; }

        public virtual DbSet<Service> Services { set; get; }
    }
}