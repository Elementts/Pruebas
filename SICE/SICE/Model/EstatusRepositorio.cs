using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.Model
    
{
    public class EstatusRepositorio : IRepositorio
    {
        SICEDataContext db = new SICEDataContext();
        public IQueryable<object> ObtenerTodos()
        {
            return from est in db.ESTADOs
                   select est;
            
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from est in db.ESTADOs
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
                return from e in db.ESTADOs
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
            ESTADO est = (ESTADO)elemento;
            //
            db.ESTADOs.DeleteOnSubmit(est);
        }

        public void Agregar(object elemento)
        {
            ESTADO est = (ESTADO)elemento;
            db.ESTADOs.InsertOnSubmit(est);
        }

        public void Modificar(object elemento)
        {
            ESTADO newEst = (ESTADO)elemento;
            var oldEst = (from e in db.ESTADOs
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