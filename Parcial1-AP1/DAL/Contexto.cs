using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Parcial1_AP1.Entidades;

namespace Parcial1_AP1.DAL.Scripts
{
    public class Contexto: DbContext
    {
        public DbSet<REvaluacion> REvaluacion { get; set; }
       


        public Contexto() : base("ConStr")
        {
            
        }

    }
}
