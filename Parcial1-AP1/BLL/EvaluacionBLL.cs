using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Parcial1_AP1.Entidades;
using Parcial1_AP1.DAL;

using Parcial1_AP1.DAL.Scripts;
using System.Linq.Expressions;
//using EstudianteProyec.DAL;
//using EstudianteProyec.DAL.Scripts;

namespace Parcial1_AP1.BLL
{
    public class EvaluacionBLL
    {

        public static bool Guardar(REvaluacion estudiante)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.REvaluacion.Add(estudiante) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;


        }

        public static bool Modificar(REvaluacion estudiante)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(estudiante).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;


        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.REvaluacion.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;


        }

        public static REvaluacion Buscar(int id)
        {
            Contexto db = new Contexto();
            REvaluacion estudiante = new REvaluacion();
            try
            {
                estudiante = db.REvaluacion.FirstOrDefault(p => p.ID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return estudiante;

        }

        public static List<REvaluacion> Getlist(Expression<Func<REvaluacion, bool>> estudiante)
        {
            List<REvaluacion> Lista = new List<REvaluacion>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.REvaluacion.Where(estudiante).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;

        }
    }
}



