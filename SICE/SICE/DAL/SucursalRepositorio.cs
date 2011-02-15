using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.DAL
{
    // hay que modificar esta clase ya que la tabla matriz_sursal ha cambiado al nombre de sucursal
    public class SucursalRepositorio : IRepositorio
    {
        DataClassesSICEDataContext db = new DataClassesSICEDataContext();
        public IQueryable<object> ObtenerTodos()
        {
            return from ms in db.MATRIZ_SUCURSAL
                   select ms;
            
        }

        public object ObtenerIndividual(object elemento)
        {
            throw new NotImplementedException();
        }

        public object ObtenerPorId(object elemento)
        {
            // por lo pronto se busca por la id de la empresa pero esto debe de ser cambiado por
            // el id del campo matriz_sucursal, campo el cual hace falta agregar
            try
            {
                string empresaid = elemento.ToString();
                return from ms in db.MATRIZ_SUCURSAL
                       where ms.EMPRESA_ID.Equals(empresaid)
                       select ms;
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }

        public void Borrar(object elemento)
        {
            
            MATRIZ_SUCURSAL matsuc = (MATRIZ_SUCURSAL)elemento;
            db.MATRIZ_SUCURSAL.DeleteOnSubmit(matsuc);
        }

        public void Agregar(object elemento)
        {
            
            MATRIZ_SUCURSAL matsuc = (MATRIZ_SUCURSAL)elemento;
            db.MATRIZ_SUCURSAL.InsertOnSubmit(matsuc);
        }

        public void Modificar(object elemento)
        {
            //MATRIZ_SUCURSAL newMat = (MATRIZ_SUCURSAL)elemento;
            //var oldMat = (from ms in db.MATRIZ_SUCURSAL
            //            where ms.MATRIZ_SUCURSAL_ID == newMat.MATRIZ_SUCURSAL_ID
            //            select ms).Single();
            // oldMat.....   = newMat....
            // oldMat.....   = newMat....
            // oldMat.....   = newMat....

            throw new NotImplementedException();
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }
    }
}