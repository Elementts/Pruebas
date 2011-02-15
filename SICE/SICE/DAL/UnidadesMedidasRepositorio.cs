using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.DAL
{
    public class UnidadesMedidasRepositorio : IRepositorio
    {
        DataClassesSICEDataContext db = new DataClassesSICEDataContext();

        public IQueryable<object> ObtenerTodos()
        {
            return from unimed in db.UNIDADES_MEDIDAS
                   select unimed;
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from unimed in db.UNIDADES_MEDIDAS
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
            UNIDADES_MEDIDAS unimed = (UNIDADES_MEDIDAS)elemento;
            //Borramos de tabla producto elementos relacionados con las unidades medidas
            db.PRODUCTOS.DeleteAllOnSubmit(unimed.PRODUCTOS);
            db.UNIDADES_MEDIDAS.DeleteOnSubmit(unimed); 
        }

        public void Agregar(object elemento)
        {
            UNIDADES_MEDIDAS unimed = (UNIDADES_MEDIDAS)elemento;
            db.UNIDADES_MEDIDAS.InsertOnSubmit(unimed);
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }


        public void Modificar(object elemento)
        {
            UNIDADES_MEDIDAS newUnimed = (UNIDADES_MEDIDAS)elemento;
            var oldUnimed = (from um in db.UNIDADES_MEDIDAS
                             where um.UNIDAD_ID == newUnimed.UNIDAD_ID
                             select um).Single();
            oldUnimed.NOMBRE = newUnimed.NOMBRE;
            oldUnimed.PRODUCTOS = newUnimed.PRODUCTOS;
            db.SubmitChanges();
        }


        public object ObtenerPorId(object elemento)
        {
            try
            {
                int id = Convert.ToInt16(elemento);
                return from um in db.UNIDADES_MEDIDAS
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