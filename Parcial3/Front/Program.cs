using Back;

namespace Front
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


        }

        public static int PedirEntero(string mensaje)
        {

            int num;
            Console.WriteLine(mensaje);
            while (int.TryParse(Console.ReadLine(), out num) == false)
            {

                Console.WriteLine("Valor incorrecto, ingreselo nuevamente:");

            }

            return num;

        }

        public static DateTime PedirFecha(string mensaje)
        {
            DateTime fecha;
            Console.WriteLine(mensaje);
            string input = Console.ReadLine();

            while (DateTime.TryParseExact(input, "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out fecha) == false)
            {
                Console.WriteLine("Fecha inválida, ingrese nuevamente (dd/MM/yyyy):");
                input = Console.ReadLine();
            }

            return fecha;
        }

        //Se usa: DateTime fechaViaje = PedirFecha("Ingrese la fecha del viaje (dd/MM/yyyy):");
        //Console.WriteLine("Fecha ingresada: " + fechaViaje.ToShortDateString());

        public static string IngresarString(string mensaje)
        {

            Console.WriteLine(mensaje);
            string palabra = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(palabra) == true)
            {

                Console.WriteLine("Valor incorrecto, ingreselo nuevamente:");
                palabra = Console.ReadLine();

            }

            return palabra;

        }

    }
}
