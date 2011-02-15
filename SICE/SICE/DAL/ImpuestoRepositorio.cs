using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.DAL
{
    public class ImpuestoRepositorio : IRepositorio
    {
        SICEDataContextDataContext db = new SICEDataContextDataContext();
        public IQueryable<object> ObtenerTodos()
        {
            return from imp in db.IMPUESTOs
                   select imp;
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from imp in db.IMPUESTOs
                       where imp.NOMBRE.Equals(nombre)
                       select imp;
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
                return from imp in db.IMPUESTOs
                       where imp.IMPUESTO_ID.Equals(id) 
                       select imp;
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }

        public void Borrar(object elemento)
        {
            IMPUESTO imp = (IMPUESTO)elemento;
            db.IMPUESTOs.DeleteOnSubmit(imp);
        }
        
        public void Agregar(object elemento)
        {
            MONEDA mon = (MONEDA)elemento;
            db.MONEDAs.InsertOnSubmit(mon);
        }

        public void Modificar(object elemento)
        {
            IMPUESTO newImp = (IMPUESTO)elemento;
            var oldImp = (from imp in db.IMPUESTOs
                          where imp.IMPUESTO_ID == newImp.IMPUESTO_ID
                          select imp).Single();
            oldImp.NOMBRE = newImp.NOMBRE;
            oldImp.PORCENTAJE = newImp.PORCENTAJE;
            oldImp.DESCRIPCION = newImp.DESCRIPCION;
            oldImp.TIPO_IMPUESTO = newImp.TIPO_IMPUESTO;

            db.SubmitChanges();
            
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }
    }
}