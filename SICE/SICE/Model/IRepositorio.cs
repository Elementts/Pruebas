using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICE.Model
{
    interface IRepositorio
    {
        IQueryable<object> ObtenerTodos();
        object ObtenerIndividual(object elemento);
        object ObtenerPorId(object elemento);
        void Borrar(object elemento);
        void Agregar(object elemento);
        void Modificar(object elemento);
        void Salvar();
    }
}
