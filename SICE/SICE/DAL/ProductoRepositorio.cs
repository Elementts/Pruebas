using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICE.DAL
{
    public class ProductoRepositorio : IRepositorio
    {
        DataClassesSICEDataContext db = new DataClassesSICEDataContext();
        public IQueryable<object> ObtenerTodos()
        {
            return from pro in db.PRODUCTOS
                   select pro;

        }

        public object ObtenerIndividual(object elemento)
        {
            try
            {
                string nombre = elemento.ToString();
                return from pro in db.PRODUCTOS
                       where pro.NOMBRE.Equals(nombre)
                       select pro;
                           
                       
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
                return from pro in db.PRODUCTOS
                       where pro.PRODUCTO_ID.Equals(id)
                       select pro;
            }
            catch (InvalidCastException ex)
            {
                return null;
            }
        }

        public void Borrar(object elemento)
        {
            PRODUCTOS pro = (PRODUCTOS)elemento;
                       
            db.PRODUCTOS.DeleteOnSubmit(pro);
            
        }

        public void Agregar(object elemento)
        {

            PRODUCTOS pro = (PRODUCTOS)elemento;
            db.PRODUCTOS.InsertOnSubmit(pro);
        }

        public void Modificar(object elemento)
        {
            PRODUCTOS newPro = (PRODUCTOS)elemento;
            var oldPro = (from p in db.PRODUCTOS
                          where p.PRODUCTO_ID == newPro.PRODUCTO_ID
                          select p).Single();
            oldPro.NOMBRE = newPro.NOMBRE;
            oldPro.CATEGORIA_ID = newPro.CATEGORIA_ID;
            oldPro.DESCRIPCION = newPro.DESCRIPCION;
            oldPro.CANTIDAD = newPro.CANTIDAD;
            oldPro.PRECIO_COMPRA = newPro.PRECIO_COMPRA;
            oldPro.PRECIO_VENTA = newPro.PRECIO_VENTA;
            oldPro.UNIDAD_ID = newPro.UNIDAD_ID;
            oldPro.USUARIO_ID = newPro.USUARIO_ID;
            // habra cambios en los nombres de unos campos
            //  a checar IMPUESTOS y demas
            oldPro.IMPUESTOS = newPro.IMPUESTOS;
            db.SubmitChanges();
        }

        public void Salvar()
        {
            db.SubmitChanges();
        }




























        /*
        private DataClassesSICEDataContext db = new DataClassesSICEDataContext();

        public IQueryable<PRODUCTOS> TodosLosProductos(int usuario_id)
        {
            return from p in db.PRODUCTOS
                   where p.USUARIO_ID.Equals(usuario_id)
                   orderby p.NOMBRE
                   select p;
        }


        public IQueryable<PRODUCTOS> ObtenerProducto(int usuario_id, string nombre)
        {
            return from p in db.PRODUCTOS
                   where p.USUARIO_ID.Equals(usuario_id) && p.NOMBRE.Contains(nombre)
                   orderby p.NOMBRE
                   select p;
        }

        public void Borrar_Producto(PRODUCTOS p, int usuario_id)
        {
            db.IMPUESTOS_PRODUCTOS.DeleteAllOnSubmit(p.IMPUESTOS_PRODUCTOS);
            db.PRODUCTOS.DeleteOnSubmit(p);


        }
        public void Agregar_Producto(PRODUCTOS p, int usuario_id)
        {
            db.PRODUCTOS.InsertOnSubmit(p);

        }

        public void Save()
        {
            db.SubmitChanges();
        }
         * 
         */ 
          
          
        /*
         * private NerdDinnerDataContext db = new NerdDinnerDataContext();
        //
        // Query Methods
        public IQueryable<Dinner> FindAllDinners()
        {
            return db.Dinners;
        }
        public IQueryable<Dinner> FindUpcomingDinners()
        {
            return from dinner in db.Dinners
                   where dinner.EventDate > DateTime.Now
                   orderby dinner.EventDate
                   select dinner;
        }
        public Dinner GetDinner(int id)
        {
            return db.Dinners.SingleOrDefault(d => d.DinnerID == id);
        }
        //
        // Insert/Delete Methods
        public void Add(Dinner dinner)
        {
            db.Dinners.InsertOnSubmit(dinner);
        }
        public void Delete(Dinner dinner)
        {
            db.RSVPs.DeleteAllOnSubmit(dinner.RSVPs);
            db.Dinners.DeleteOnSubmit(dinner);
        }
        //
        // Persistence
        public void Save()
        {
            db.SubmitChanges();
        }*/
        
    }
        
    
}