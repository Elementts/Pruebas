using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICE.DAL
{
    interface IRepositorio
    {
        public IQueryable<object> ObtenerTodos();
        public object ObtenerIndividual(object elemento);
        public object ObtenerPorId(object elemento);
        public void Borrar(object elemento);
        public void Agregar(object elemento);
        public void Modificar(object elemento);
        public void Salvar();
    }
}
