using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.DAL
    
{
    public class EstatusRepositorio : IRepositorio
    {
        SICEDataContextDataContext db = new SICEDataContextDataContext();
        public IQueryable<object> ObtenerTodos()
        {
            return from est in db.ESTATUS
                   select est;
            
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from est in db.ESTATUS
                       where est.NOMBRE.Equals(nombre)
                       select est;
                       
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }

        public object ObtenerPorId(object elemento)
        {
            try
            {
                int id = Convert.ToInt16(elemento);
                return from e in db.ESTATUS
                       where e.ESTATUS_ID.Equals(id)
                       select e;
            }
            catch (InvalidCastException ex)
            {
                return null;
            }

        }

        public void Borrar(object elemento)
        {
            ESTATUS est = (ESTATUS)elemento;
            //
            db.ESTATUS.DeleteOnSubmit(est);
        }

        public void Agregar(object elemento)
        {
            ESTATUS est = (ESTATUS)elemento;
            db.ESTATUS.InsertOnSubmit(est);
        }

        public void Modificar(object elemento)
        {
            ESTATUS newEst = (ESTATUS)elemento;
            var oldEst = (from e in db.ESTATUS
                          where e.ESTATUS_ID == newEst.ESTATUS_ID
                          select e).Single();
            oldEst.NOMBRE = newEst.NOMBRE;
            db.SubmitChanges();
            

            
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }
    }
}