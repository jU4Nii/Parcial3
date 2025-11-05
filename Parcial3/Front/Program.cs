using Back;
using Back.Data1;
using Back.Models;
using Back.Repository;

namespace Front
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("Elija qué opción desea realizar:");
                Console.WriteLine("1. Registrar un nuevo producto");
                Console.WriteLine("2. Registrar un nuevo cliente");
                Console.WriteLine("3. Registrar una nueva venta");
                Console.WriteLine("4. Mostrar un reporte de ventas por cliente");
                Console.WriteLine("5. Salir");
                

                opcion = PedirEntero("Opción:");

                switch (opcion)
                {
                    case 1:
                        {
                            string nombre = IngresarString("Ingrese nombre del producto:");
                            decimal precio = PedirDecimal("Ingrese precio:");
                            int stock = PedirEntero("Ingrese stock:");

                            var producto = new Producto { Nombre = nombre, Precio = precio, Stock = stock };
                            ProductoRepository.RegistrarProducto(producto);

                            Console.WriteLine("Producto registrado correctamente.");
                            Console.WriteLine("Presione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                            
                        }

                    case 2:
                        {
                            string nombre = IngresarString("Ingrese nombre del cliente:");
                            string apellido = IngresarString("Ingrese apellido:");
                            string telefono = IngresarString("Ingrese teléfono:");

                            var cliente = new Cliente { Nombre = nombre, Apellido = apellido, Telefono = telefono };
                            ClienteRepository.RegistrarCliente(cliente);

                            Console.WriteLine("Cliente registrado correctamente.");
                            Console.WriteLine("Presione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }

                    case 3:
                        {
                            Cliente clienteValido = null;

                            
                            while (clienteValido == null)
                            {
                                int clienteId = PedirEntero("Ingrese ID del cliente:");
                                using (var context = new ApplicationDbContext())
                                {
                                    clienteValido = context.Clientes.Find(clienteId);
                                }

                                if (clienteValido == null)
                                {
                                    Console.WriteLine("Cliente no encontrado. Intente nuevamente.");
                                }
                                else
                                {
                                    Console.WriteLine($"Cliente encontrado: {clienteValido.Nombre} {clienteValido.Apellido}");
                                }
                            }

                            List<ProductoVenta> productos = new List<ProductoVenta>();
                            string continuar;

                            do
                            {
                                Producto productoValido = null;

                                
                                while (productoValido == null)
                                {
                                    int productoId = PedirEntero("Ingrese ID del producto:");
                                    using (var context = new ApplicationDbContext())
                                    {
                                        productoValido = context.Productos.Find(productoId);
                                    }

                                    if (productoValido == null)
                                    {
                                        Console.WriteLine("Producto no encontrado. Intente nuevamente.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Producto encontrado: {productoValido.Nombre} (Stock: {productoValido.Stock})");

                                        int cantidad = 0;
                                        bool cantidadValida = false;

                                       
                                        while (!cantidadValida)
                                        {
                                            cantidad = PedirEntero("Ingrese cantidad:");

                                            if (cantidad <= 0)
                                            {
                                                Console.WriteLine("La cantidad debe ser mayor a 0.");
                                            }
                                            else if (cantidad > productoValido.Stock)
                                            {
                                                Console.WriteLine($"Stock insuficiente. Disponible: {productoValido.Stock}. Ingrese otra cantidad.");
                                            }
                                            else
                                            {
                                                cantidadValida = true;
                                            }
                                        }

                                        productos.Add(new ProductoVenta
                                        {
                                            ProductoId = productoValido.Id,
                                            Cantidad = cantidad
                                        });
                                    }
                                }

                                continuar = IngresarString("¿Desea agregar otro producto? (s/n):");

                            } while (continuar.ToLower() == "s");

                            
                            VentaRepository.RegistrarVenta(clienteValido.Id, productos);
                            Console.WriteLine("Venta registrada correctamente.");
                            Console.WriteLine("Presione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }


                    case 4:
                        VentaRepository.MostrarReporteVentasPorCliente();
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("Usted salió del programa.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

                Console.WriteLine(); 
            }
            while (opcion != 5);
        }

      

        public static int PedirEntero(string mensaje)
        {
            int num;
            Console.WriteLine(mensaje);
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Valor incorrecto, ingreselo nuevamente:");
            }
            return num;
        }

        public static decimal PedirDecimal(string mensaje)
        {
            decimal num;
            Console.WriteLine(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Valor incorrecto, ingreselo nuevamente:");
            }
            return num;
        }

        public static string IngresarString(string mensaje)
        {
            Console.WriteLine(mensaje);
            string palabra = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(palabra))
            {
                Console.WriteLine("Valor incorrecto, ingreselo nuevamente:");
                palabra = Console.ReadLine();
            }
            return palabra;
        }
    }
}
