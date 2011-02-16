using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.Model
{
    public class TipoPagoRepositorio : IRepositorio
    {
        SICEDataContext db = new SICEDataContext();
        public IQueryable<object> ObtenerTodos()
        {
            return from tp in db.TIPO_PAGOs
                   select tp;

            
        }

        public object ObtenerIndividual(object elemento)
        {

            throw new NotImplementedException();

            
        }

        public object ObtenerPorId(object elemento)
        {
            throw new NotImplementedException();
        }

        public void Borrar(object elemento)
        {
            throw new NotImplementedException();
        }

        public void Agregar(object elemento)
        {
            throw new NotImplementedException();
        }

        public void Modificar(object elemento)
        {
            throw new NotImplementedException();
        }

        public void Salvar()
        {
            throw new NotImplementedException();
        }
    }
}