using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkDemoFdr16Prjct1
{
    public class NorthwindContext:DbContext
    {
        //miras aldıktan sonra override yazıp içerideki metotlara ulaşabiliriz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; }


    }
}
