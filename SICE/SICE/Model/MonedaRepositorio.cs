using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.Model
{
    public class MonedaRepositorio : IRepositorio
    {
        SICEDataContext db = new SICEDataContext();

        public IQueryable<object> ObtenerTodos()
        {
            return from mon in db.MONEDAs
                   select mon;
        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from mon in db.MONEDAs
                       where mon.NOMBRE.Equals(nombre)
                       select mon;
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
                return from mon in db.MONEDAs
                       where mon.MONEDA_ID.Equals(id)
                       select mon;
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }

        public void Borrar(object elemento)
        {
            MONEDA mon = (MONEDA)elemento;

            db.MONEDAs.DeleteOnSubmit(mon);
        }

        public void Agregar(object elemento)
        {
            MONEDA mon = (MONEDA)elemento;
            db.MONEDAs.InsertOnSubmit(mon);
        }

        public void Modificar(object elemento)
        {
            MONEDA newMon = (MONEDA)elemento;
            var oldMon = (from m in db.MONEDAs
                          where m.MONEDA_ID == newMon.MONEDA_ID
                          select m).Single();
            oldMon.NOMBRE = newMon.NOMBRE;
            oldMon.VALOR = newMon.VALOR;
            
            
            db.SubmitChanges();
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }
    }
}