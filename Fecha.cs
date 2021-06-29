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

        private const int MESES_AÑO = 12;

        public static bool esBisiesto(int año)
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

            setAño(año);
            setMes(mes);
            setDia(dia);
        }
        public Fecha(DateTime date)
        {
            setAño(date.Year);
            setMes(date.Month);
            setDia(date.Day);
        }

        public Fecha(Fecha f) {
            setAño(f.año);
            setMes(f.mes);
            setDia(f.dia);
        }

        public bool esBisiesto()
        {
            return esBisiesto(año);           
        }

        public void setAño(int año)
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

        public int getAño()
        {
            return año;
        }

        public void setMes(int mes)
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

        public int getMes()
        {
            return mes;
        }

        public void setDia(int dia)
        {
            int diasMes;
            if (año >= 0 && mes > 0 && mes < MESES_AÑO)
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
                        if (esBisiesto(año))
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

        public int getDia()
        {
            return dia;
        }

        public void set(int año, int mes, int dia)
        {
            setAño(año);
            setMes(mes);
            setDia(dia);
        }

        public void set(Fecha f)
        {
            setAño(f.año);
            setMes(f.mes);
            setDia(f.dia);
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
            Fecha f = obj as Fecha;
            if(f is null)
            {
                return false;
            }
            return dia == f.dia && mes == f.mes && año == f.año;
        }

    }

}

