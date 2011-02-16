using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.Model
{
    public class TipoUsuarioRepositorio : IRepositorio
    {

        SICEDataContext db = new SICEDataContext();

        public IQueryable<object> ObtenerTodos()
        {
            return from tipusu in db.TIPO_USUARIOs
                   select tipusu;
          
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from tipusu in db.TIPO_USUARIOs
                       where tipusu.NOMBRE.Equals(nombre)
                       select tipusu;
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
                return from tipusu in db.TIPO_USUARIOs
                       where tipusu.TIPO_ID.Equals(id)
                       select tipusu;
                       
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }

        public void Borrar(object elemento)
        {
            TIPO_USUARIO tu = (TIPO_USUARIO)elemento;
            // Haria falta borrar elementos relacionados con la tabla tipo_usuarios

            db.TIPO_USUARIOs.DeleteOnSubmit(tu);
            
            
            
        }

        public void Agregar(object elemento)
        {
            TIPO_USUARIO tu = (TIPO_USUARIO)elemento;
            db.TIPO_USUARIOs.InsertOnSubmit(tu);
        }

        public void Modificar(object elemento)
        {
            TIPO_USUARIO newTipusu = (TIPO_USUARIO)elemento;
            var oldTipusu = (from tu in db.TIPO_USUARIOs
                             where tu.TIPO_ID == newTipusu.TIPO_ID
                             select tu).Single();
            oldTipusu.NOMBRE = newTipusu.NOMBRE;
            oldTipusu.DESCRIPCION = newTipusu.DESCRIPCION;
            db.SubmitChanges();

            
            
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }
    }
}