using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioFecha
{
    public class PruebaFecha
    {
        public static int MAX_FECHAS = 1000;
        public static int GetRandom(int min, int max)
        {
            var aleatorio = new Random();
            return aleatorio.Next(min, max);
            
        }

        public static void Main()
        {
            int anho;
            int mes;
            int dia;
            
            for (int i = 0; i < MAX_FECHAS; i++)
            {
                anho = GetRandom(1, 3001);
                mes = GetRandom(1, 13);
                dia = GetRandom(1, 32);

                Console.WriteLine($"\n Fecha {i}: {dia} / {mes} / {anho}");
                try
                    {
                        Fecha f = new Fecha(anho, mes, dia);
                        Console.WriteLine("Fecha correcta: " + f);
                    }
                catch (Exception e)
                    {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("EXCEPTION: " + e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            //var ff = new Fecha(2000,2,44);
            //Console.WriteLine(ff);
        }
    }
}
