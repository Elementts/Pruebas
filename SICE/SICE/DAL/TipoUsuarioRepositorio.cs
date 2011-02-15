using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.DAL
{
    public class TipoUsuarioRepositorio : IRepositorio
    {
        DataClassesSICEDataContext db = new DataClassesSICEDataContext();

        public IQueryable<object> ObtenerTodos()
        {
            return from tipusu in db.TIPO_USUARIOS
                   select tipusu;
          
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from tipusu in db.TIPO_USUARIOS
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
                return from tipusu in db.TIPO_USUARIOS
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
            TIPO_USUARIOS tu = (TIPO_USUARIOS)elemento;
            // Haria falta borrar elementos relacionados con la tabla tipo_usuarios

            db.TIPO_USUARIOS.DeleteOnSubmit(tu);
            
            
            
        }

        public void Agregar(object elemento)
        {
            TIPO_USUARIOS tu = (TIPO_USUARIOS)elemento;
            db.TIPO_USUARIOS.InsertOnSubmit(tu);
        }

        public void Modificar(object elemento)
        {
            TIPO_USUARIOS newTipusu = (TIPO_USUARIOS)elemento;
            var oldTipusu = (from tu in db.TIPO_USUARIOS
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