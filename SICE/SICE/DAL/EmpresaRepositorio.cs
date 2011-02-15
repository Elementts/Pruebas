using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.DAL
{
    public class EmpresaRepositorio : IRepositorio
    {
        SICEDataContextDataContext db = new SICEDataContextDataContext();

        public IQueryable<object> ObtenerTodos()
        {
            return from emp in db.EMPRESAs
                   select emp;

        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string cedula = elemento.ToString();
                return from emp in db.EMPRESAs
                       where emp.CEDULA.Equals(cedula)
                       select emp;
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
                return from emp in db.EMPRESAs
                       where emp.EMPRESA_ID.Equals(id)
                       select emp;
                       
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }

        public void Borrar(object elemento)
        {
            EMPRESA emp = (EMPRESA)elemento;
            // faltaria agregar linea de codigo q borre las relaciones de esta tabla (EMPRESA) con las demas
            db.EMPRESAs.DeleteOnSubmit(emp);
        }

        public void Agregar(object elemento)
        {
            EMPRESA emp = (EMPRESA)elemento;
            db.EMPRESAs.InsertOnSubmit(emp);
        }

        public void Modificar(object elemento)
        {
            EMPRESA newEmp = (EMPRESA)elemento;
            var oldEmp = (from e in db.EMPRESAs
                          where e.EMPRESA_ID == newEmp.EMPRESA_ID
                          select e).Single();
            oldEmp.CEDULA = newEmp.CEDULA;
            oldEmp.LOGO = newEmp.LOGO;
            oldEmp.USUARIO_ID = newEmp.USUARIO_ID;

            
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }
    }
}