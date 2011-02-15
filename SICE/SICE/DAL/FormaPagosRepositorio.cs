using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.DAL
{
    public class FormaPagosRepositorio : IRepositorio
    {
        SICEDataContextDataContext db = new SICEDataContextDataContext();

        public IQueryable<object> ObtenerTodos()
        {
            return from forpag in db.FORMA_PAGOs
                   select forpag;
                       
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from forpag in db.FORMA_PAGOs
                       where forpag.NOMBRE.Equals(nombre)
                       select forpag;
                           
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }

        public void Borrar(object elemento)
        {
            FORMA_PAGO forpag = (FORMA_PAGO)elemento;

            
            //Borramos de tabla factura elementos relacionados con la forma de pago
            
            db.FACTURAs.DeleteAllOnSubmit(forpag.FACTURAs);
            db.FORMA_PAGOs.DeleteOnSubmit(forpag);

            
        }

        public void Agregar(object elemento)
        {
            FORMA_PAGO forpag = (FORMA_PAGO)elemento;
            db.FORMA_PAGOs.InsertOnSubmit(forpag);

            
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }


        public void Modificar(object elemento)
        {
            FORMA_PAGO newForpag = (FORMA_PAGO)elemento;

            var oldForpag = (from fp in db.FORMA_PAGOs
                             where fp.FORMA_PAGO_ID == newForpag.FORMA_PAGO_ID
                             select fp).Single();
            oldForpag.NOMBRE = newForpag.NOMBRE;
            // DESCRIPCION  es un campo inexistente aun, por eso se comenta
            //oldForpag.DESCRIPCION = newForpag.DESCRIPCION;
            db.SubmitChanges();

        }


        public object ObtenerPorId(object elemento)
        {
            try
            {
                int id = Convert.ToInt16(elemento);
                return from fp in db.FORMA_PAGOs
                       where fp.FORMA_PAGO_ID.Equals(id)
                       select fp;
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }
    }
}