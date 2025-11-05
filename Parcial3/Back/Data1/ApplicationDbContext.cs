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

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaProducto> VentaProductos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=JUANI\\SQLEXPRESS04;Database=TiendaDbParcial3;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }



    }
}
