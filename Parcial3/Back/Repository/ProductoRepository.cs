using Back.Data1;
using Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Repository
{
    public static class ProductoRepository
    {

        public static void RegistrarProducto(Producto nuevoProducto)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Productos.Add(nuevoProducto);
                context.SaveChanges();
            }
        }


    }
}
