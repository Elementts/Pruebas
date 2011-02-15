using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.DAL
{
    public class CategoriaRepositorio : IRepositorio
    {
        SICEDataContextDataContext db = new SICEDataContextDataContext();
        

        public IQueryable<object> ObtenerTodos()
        {
            return from cat in db.CATEGORIAs
                   select cat;
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from cat in db.CATEGORIAs
                       where cat.NOMBRE.Equals(nombre)
                       select cat;
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }

        public void Borrar(object elemento)
        {
            CATEGORIA cat = (CATEGORIA)elemento;

            
            //Borramos de tabla producto elementos relacionados con la de categoria
            
            db.PRODUCTOs.DeleteAllOnSubmit(cat.PRODUCTOs);
            db.CATEGORIAs.DeleteOnSubmit(cat);
            
            
        }

        public void Agregar(object elemento)
        {
            CATEGORIA cat = (CATEGORIA)elemento;
            db.CATEGORIAs.InsertOnSubmit(cat);
            
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }


        public void Modificar(object elemento)
        {
            CATEGORIA newCat = (CATEGORIA)elemento;
            var oldCat = (from c in db.CATEGORIAs
                          where c.CATEGORIA_ID == newCat.CATEGORIA_ID
                          select c).Single();
            oldCat.NOMBRE = newCat.NOMBRE;
            // DESCRIPCION ES UN CAMPO QUE FALTA DE AGREGAR POR ESO SE COMENTA
            //oldCat.DESCRIPCION = newCat.DESCRIPCION;
            db.SubmitChanges();
        }


       


        public object ObtenerPorId(object elemento)
        {
            try
            {
                int id = Convert.ToInt16(elemento);
                return from cat in db.CATEGORIAs
                       where cat.CATEGORIA_ID.Equals(id)
                       select cat;
            }
            catch (InvalidCastException ex)
            {
                return null;
            }

        }
    }
}