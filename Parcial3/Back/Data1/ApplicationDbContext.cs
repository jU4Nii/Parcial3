using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Back.Models;

namespace Back.Data1
{
    public class ApplicationDbContext : DbContext
    {



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=PruebaEF;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }



    }
}
