using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioFecha
{
    public class Fecha
    {
        private int anho = -1;
        private int mes;
        private int dia;

        public const int MESES_ANHO = 12;

        public static bool EsBisiesto(int anho)
        {
            if(anho % 4 != 0 || (anho % 100 == 0 && anho % 400 != 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Fecha() { }

        public Fecha(int anho, int mes, int dia) {

            SetAnho(anho);
            SetMes(mes);
            SetDia(dia);
        }
        public Fecha(DateTime date)
        {
            SetAnho(date.Year);
            SetMes(date.Month);
            SetDia(date.Day);
        }

        public Fecha(Fecha f) {
            SetAnho(f.anho);
            SetMes(f.mes);
            SetDia(f.dia);
        }

        public bool EsBisiesto()
        {
            return EsBisiesto(anho);           
        }

        public void SetAnho(int anho)
        {
            if (anho >= 0 && anho < 3001)
            {
                this.anho = anho;
            }
            else
            {
                throw new FechaException("El anho debe estar en el rango 0-3000.");
            }
        }

        public int GetAnho()
        {
            return anho;
        }

        public void SetMes(int mes)
        {
            if(anho >= 0)
            {
                if(mes > 0 && mes <= MESES_ANHO)
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
                throw new FechaException("El anho debe estar definidido para definir el mes.");
            }
        }

        public int GetMes()
        {
            return mes;
        }

        public void SetDia(int dia)
        {
            int diasMes;
            if (anho >= 0 && mes > 0 && mes <= MESES_ANHO)
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
                        if (EsBisiesto(anho))
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
                throw new FechaException("El anho y el mes deben estar definididos para definir el día.");

            }
        }

        public int GetDia()
        {
            return dia;
        }

        public void Set(int anho, int mes, int dia)
        {
            SetAnho(anho);
            SetMes(mes);
            SetDia(dia);
        }

        public void Set(Fecha f)
        {
            SetAnho(f.anho);
            SetMes(f.mes);
            SetDia(f.dia);
        }

        public override string ToString()
        {
            return $"{dia} / {mes} / {anho}";
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
            return dia == f.dia && mes == f.mes && anho == f.anho;
        }
        public override int GetHashCode() {
            return anho.GetHashCode() ^ mes.GetHashCode() ^ dia.GetHashCode();

            //return base.GetHashCode();
        }

    }

    }

