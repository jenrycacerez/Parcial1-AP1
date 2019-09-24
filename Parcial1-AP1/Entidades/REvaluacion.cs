using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parcial1_AP1.Entidades
{
    public class REvaluacion
    {
            [key]
            public int ID { get; set; }

            public DateTime Fecha { get; set; }

           
            public string Estudiante { get; set; }
           
        
            public decimal Calificacion { get; set; }
            

            public int Valor { get; set; }
            public int Logrado { get; set; }
            public int Perdido{ get; set; }
            
            public int Pronostico { get; set; }

            public REvaluacion()
            {
                ID = 0;
               
                Estudiante = string.Empty;
               
                Fecha = DateTime.Now;

                Calificacion = 0;

                Valor = 0;

                Logrado = 0;

                Perdido = 0;

                Pronostico = 0;







        }





        }
    }





