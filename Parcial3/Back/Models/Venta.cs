using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Models
{
    public class Venta
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public List<VentaProducto> ProductosVendidos { get; set; } = new List<VentaProducto>();
    }

}
