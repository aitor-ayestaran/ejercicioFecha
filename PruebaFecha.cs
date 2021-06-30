using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioFecha
{
    public class PruebaFecha
    {
        public static int MAX_FECHAS = 100;
        public static int GetRandom(int min, int max)
        {
            var aleatorio = new Random();
            return aleatorio.Next(min, max);
            
        }

        public static void Main(String[] args)
        {
            int año;
            int mes;
            int dia;
            
            for (int i = 0; i < MAX_FECHAS; i++)
            {
                año = GetRandom(1, 2021);
                mes = GetRandom(1, 13);
                dia = GetRandom(1, 31);

                Console.WriteLine($"{año} / {mes} / {dia}");
                try
                    {
                        Fecha f = new Fecha(año, mes, dia);
                        Console.WriteLine("Fecha correcta: " + f);
                    }
                catch (Exception e)
                    {
                        Console.WriteLine("EXCEPTION: " + e.Message);
                    }
            }
            var ff = new Fecha(2000,2,44);
            Console.WriteLine(ff);
        }
    }
}
