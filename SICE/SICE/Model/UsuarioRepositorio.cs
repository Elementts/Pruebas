using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.Model
{
    public class UsuarioRepositorio : IRepositorio
    {
        SICEDataContext db = new SICEDataContext();

        public IQueryable<object> ObtenerTodos()
        {
            return from u in db.USUARIOs
                   select u;
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from u in db.USUARIOs
                       where u.NOMBRE.Equals(nombre)
                       select u;
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
                return from u in db.USUARIOs
                       where u.USUARIO_ID.Equals(id)
                       select u;
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }

        public void Borrar(object elemento)
        {
            USUARIO usu = (USUARIO)elemento;
            db.USUARIOs.DeleteOnSubmit(usu);
        }

        public void Agregar(object elemento)
        {
            USUARIO usu = (USUARIO)elemento;
            db.USUARIOs.InsertOnSubmit(usu);
            
        }

        public void Modificar(object elemento)
        {
            USUARIO newUsu = (USUARIO)elemento;
            var oldUsu = (from u in db.USUARIOs
                          where u.USUARIO_ID == newUsu.USUARIO_ID
                          select u).Single();
            oldUsu.FOTO = newUsu.FOTO;
            oldUsu.USERNAME = newUsu.USERNAME;
            oldUsu.PASSWORD = newUsu.PASSWORD;
            oldUsu.NOMBRE = newUsu.NOMBRE;
            oldUsu.APELLIDO_MATERNO = newUsu.APELLIDO_MATERNO;
            oldUsu.APELLIDO_PATERNO = newUsu.APELLIDO_PATERNO;
            oldUsu.ALIAS = newUsu.ALIAS;
            oldUsu.CARGO = newUsu.CARGO;
            oldUsu.EMPRESA = newUsu.EMPRESA;
            oldUsu.SKYPE = newUsu.SKYPE;
            oldUsu.MSN = newUsu.MSN;
            oldUsu.TELEFONO_PERSONAL = newUsu.TELEFONO_PERSONAL;
            oldUsu.CELULAR = newUsu.CELULAR;
            oldUsu.RADIO = newUsu.RADIO;
            oldUsu.CALLE = newUsu.CALLE;
            oldUsu.NUM_EXTERNO = newUsu.NUM_EXTERNO;
            oldUsu.NUM_INTERNO = newUsu.NUM_INTERNO;
            oldUsu.CODIGO_POSTAL = newUsu.CODIGO_POSTAL;
            oldUsu.COLONIA = newUsu.COLONIA;
            oldUsu.LOCALIDAD = newUsu.LOCALIDAD;
            oldUsu.MUNICIPIO = newUsu.MUNICIPIO;
            oldUsu.ESTADO = newUsu.ESTADO;
            oldUsu.PAIS = newUsu.PAIS;
            oldUsu.FECHA_NACIMIENTO = newUsu.FECHA_NACIMIENTO;
            oldUsu.EDAD = newUsu.EDAD;
            oldUsu.GENERO = newUsu.GENERO;
            oldUsu.ZONA = newUsu.ZONA;
            oldUsu.NUMERO_PLACAS = newUsu.NUMERO_PLACAS;
            oldUsu.TIPO_ID = newUsu.TIPO_ID;
            oldUsu.DATOS_FISCALES_ID = newUsu.DATOS_FISCALES_ID;
            

            db.SubmitChanges();
                     
            
            
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }
    }
}