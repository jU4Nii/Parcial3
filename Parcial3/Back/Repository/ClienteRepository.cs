using Back.Data1;
using Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Repository
{
    public static class ClienteRepository
    {

        public static void RegistrarCliente(Cliente nuevoCliente)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Clientes.Add(nuevoCliente);
                context.SaveChanges();
            }
        }

    }
}
