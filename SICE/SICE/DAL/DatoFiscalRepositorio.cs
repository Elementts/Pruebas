using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.DAL
{
    public class DatoFiscalRepositorio : IRepositorio
    {
        SICEDataContextDataContext db = new SICEDataContextDataContext();
        public IQueryable<object> ObtenerTodos()
        {
            return from df in db.DATOS_FISCALEs
                   select df;
            
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string rfc = elemento.ToString();
                return from df in db.DATOS_FISCALEs
                       where df.RFC.Equals(rfc)
                       select rfc;
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
                return from df in db.DATOS_FISCALEs
                       where df.DATOS_FISCALES_ID.Equals(df)
                       select df;
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
            
        }

        public void Borrar(object elemento)
        {
            
            DATOS_FISCALE df = (DATOS_FISCALE)elemento;

            //Faltaria Borrar los datos que tienen relacion con tabla DATOS_FISCALES
            db.DATOS_FISCALEs.DeleteOnSubmit(df);
        }

        public void Agregar(object elemento)
        {
            DATOS_FISCALE df = (DATOS_FISCALE)elemento;
            db.DATOS_FISCALEs.InsertOnSubmit(df);
        }

        public void Modificar(object elemento)
        {
            DATOS_FISCALE newDatfis = (DATOS_FISCALE)elemento;
            var oldDatfis = (from df in db.DATOS_FISCALEs
                             where df.DATOS_FISCALES_ID == newDatfis.DATOS_FISCALES_ID
                             select df).Single();
            oldDatfis.RAZON_SOCIAL = newDatfis.RAZON_SOCIAL;
            oldDatfis.RFC = newDatfis.RFC;
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }
    }
}