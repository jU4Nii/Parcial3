using Back.Data1;
using Back.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Repository
{
    public static class VentaRepository
    {
        public static void RegistrarVenta(int clienteId, List<ProductoVenta> productos)
        {
            using (var context = new ApplicationDbContext())
            {
                var venta = new Venta
                {
                    ClienteId = clienteId,
                    Fecha = DateTime.Now,
                    Total = 0
                };

                context.Ventas.Add(venta);

                foreach (var i in productos)
                {
                    var producto = context.Productos.Find(i.ProductoId);

                    producto.Stock -= i.Cantidad;
                    venta.Total += producto.Precio * i.Cantidad;

                    venta.ProductosVendidos.Add(new VentaProducto
                    {
                        ProductoId = producto.Id,
                        Cantidad = i.Cantidad
                    });
                }

                context.SaveChanges();
            }
        }


        public static void MostrarReporteVentasPorCliente()
        {
            using (var context = new ApplicationDbContext())
            {
                var ventas = context.Ventas.Include(v => v.Cliente).ToList();

                var clientes = ventas.Select(v => v.Cliente).Distinct();

                Console.WriteLine("Reporte de Ventas por Cliente");

                foreach (var cliente in clientes)
                {
                    var ventasCliente = ventas.Where(v => v.ClienteId == cliente.Id);
                    var cantidad = ventasCliente.Count();
                    var total = ventasCliente.Sum(v => v.Total);

                    Console.WriteLine($"Cliente: {cliente.Nombre} {cliente.Apellido}");
                    Console.WriteLine($"Ventas realizadas: {cantidad}");
                    Console.WriteLine($"Total gastado: ${total}");
                    Console.WriteLine("-----------------------------------");
                }
            }
        }


    }

}
