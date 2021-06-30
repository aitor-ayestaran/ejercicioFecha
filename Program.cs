using System;

namespace ejercicioFecha
{
    class Program
    {
        static void Mainn(string[] args)
        {
            var f = new Fecha();
            f.Set(2020, 2, 29);
            var f2 = new Fecha(2020, 2, 29);

            Console.WriteLine(f.Equals(f2));

            var f3 = new Fecha(DateTime.Now);
            Console.WriteLine(f3);
        }
    }
}
