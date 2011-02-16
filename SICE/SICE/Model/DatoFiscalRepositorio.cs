using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.Model
{
    public class DatoFiscalRepositorio : IRepositorio
    {
        SICEDataContext db = new SICEDataContext();
        public IQueryable<object> ObtenerTodos()
        {
            return from df in db.DATO_FISCALs
                   select df;
            
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string rfc = elemento.ToString();
                return from df in db.DATO_FISCALs
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
                return from df in db.DATO_FISCALs
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
            
            DATO_FISCAL df = (DATO_FISCAL)elemento;

            //Faltaria Borrar los datos que tienen relacion con tabla DATOS_FISCALES
            db.DATO_FISCALs.DeleteOnSubmit(df);
        }

        public void Agregar(object elemento)
        {
            DATO_FISCAL df = (DATO_FISCAL)elemento;
            db.DATO_FISCALs.InsertOnSubmit(df);
        }

        public void Modificar(object elemento)
        {
            DATO_FISCAL newDatfis = (DATO_FISCAL)elemento;
            var oldDatfis = (from df in db.DATO_FISCALs
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
