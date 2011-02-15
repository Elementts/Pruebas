using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.DAL
{
    public class TipoPagoRepositorio : IRepositorio
    {
        DataClassesSICEDataContext db = new DataClassesSICEDataContext();
        public IQueryable<object> ObtenerTodos()
        {
            return from tp in db.TIPO_PAGOS
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