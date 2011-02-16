using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.Model
{
    public class UnidadesMedidasRepositorio : IRepositorio
    {
        SICEDataContext db = new SICEDataContext();

        public IQueryable<object> ObtenerTodos()
        {
            return from unimed in db.UNIDADES_MEDIDAs
                   select unimed;
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from unimed in db.UNIDADES_MEDIDAs
                       where unimed.NOMBRE.Equals(nombre)
                       select unimed;
            }
            catch (InvalidCastException ex) 
            {
                return null;
            }
        }

        public void Borrar(object elemento)
        {
            UNIDADES_MEDIDA unimed = (UNIDADES_MEDIDA)elemento;
            //Borramos de tabla producto elementos relacionados con las unidades medidas
            db.PRODUCTOs.DeleteAllOnSubmit(unimed.PRODUCTOs);
            db.UNIDADES_MEDIDAs.DeleteOnSubmit(unimed); 
        }

        public void Agregar(object elemento)
        {
            UNIDADES_MEDIDA unimed = (UNIDADES_MEDIDA)elemento;
            db.UNIDADES_MEDIDAs.InsertOnSubmit(unimed);
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }


        public void Modificar(object elemento)
        {
            UNIDADES_MEDIDA newUnimed = (UNIDADES_MEDIDA)elemento;
            var oldUnimed = (from um in db.UNIDADES_MEDIDAs
                             where um.UNIDAD_ID == newUnimed.UNIDAD_ID
                             select um).Single();
            oldUnimed.NOMBRE = newUnimed.NOMBRE;
            oldUnimed.PRODUCTOs = newUnimed.PRODUCTOs;
            db.SubmitChanges();
        }


        public object ObtenerPorId(object elemento)
        {
            try
            {
                int id = Convert.ToInt16(elemento);
                return from um in db.UNIDADES_MEDIDAs
                       where um.UNIDAD_ID.Equals(id)
                       select um;
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }
    }
}