using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioFecha
{
    public class Fecha
    {
        private int año = -1;
        private int mes;
        private int dia;

        public const int MESES_AÑO = 12;

        public static bool EsBisiesto(int año)
        {
            if(año % 4 != 0 || (año % 100 == 0 && año % 400 != 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Fecha() { }

        public Fecha(int año, int mes, int dia) {

            SetAño(año);
            SetMes(mes);
            SetDia(dia);
        }
        public Fecha(DateTime date)
        {
            SetAño(date.Year);
            SetMes(date.Month);
            SetDia(date.Day);
        }

        public Fecha(Fecha f) {
            SetAño(f.año);
            SetMes(f.mes);
            SetDia(f.dia);
        }

        public bool EsBisiesto()
        {
            return EsBisiesto(año);           
        }

        public void SetAño(int año)
        {
            if (año >= 0 && año < 3001)
            {
                this.año = año;
            }
            else
            {
                throw new FechaException("El año debe estar en el rango 0-3000.");
            }
        }

        public int GetAño()
        {
            return año;
        }

        public void SetMes(int mes)
        {
            if(año >= 0)
            {
                if(mes > 0 && mes <= MESES_AÑO)
                {
                    this.mes = mes;
                }
                else
                {
                    throw new FechaException("El mes debe estar en el rango 1-12.");
                }
            }
            else
            {
                throw new FechaException("El año debe estar definidido para definir el mes.");
            }
        }

        public int GetMes()
        {
            return mes;
        }

        public void SetDia(int dia)
        {
            int diasMes;
            if (año >= 0 && mes > 0 && mes <= MESES_AÑO)
            { 
                switch(mes)
                {
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        diasMes = 30; 
                        break;
                    case 2:
                        if (EsBisiesto(año))
                        {
                            diasMes = 29;
                        }
                        else
                        {
                            diasMes = 28;
                        }
                        break;
                    default:
                        diasMes = 31;
                        break;
                }
                if (dia > 0 && dia <= diasMes)
                {
                    this.dia = dia;
                }
                else
                {
                    throw new FechaException($"Debe ser un día del rango 1-{diasMes}");
                }
            }
            else
            {
                throw new FechaException("El año y el mes deben estar definididos para definir el día.");

            }
        }

        public int GetDia()
        {
            return dia;
        }

        public void Set(int año, int mes, int dia)
        {
            SetAño(año);
            SetMes(mes);
            SetDia(dia);
        }

        public void Set(Fecha f)
        {
            SetAño(f.año);
            SetMes(f.mes);
            SetDia(f.dia);
        }

        public override string ToString()
        {
            return $"{dia} / {mes} / {año}";
        }

        public override bool Equals(object obj)
        {
            if(this == obj)
            {
                return true;
            }
            if (obj is not Fecha f)
            {
                return false;
            }
            return dia == f.dia && mes == f.mes && año == f.año;
        }
        public override int GetHashCode() { return base.GetHashCode(); }

    }

}

