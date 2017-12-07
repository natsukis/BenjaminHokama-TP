using Data;
using Data.Northwind;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ValidaProducto
    {

        private Repository<Products> Productos = new Repository<Products>();

        public ModelProducts BuscaProducto(string nombre)
        {

            var aux = Productos.Set().FirstOrDefault(c => c.ProductName == nombre);

            if (aux != null)
            {
                var producto = new ModelProducts()
                {
                    ProductID = aux.ProductID,
                    SupplierID = aux.SupplierID,
                    CategoryID = aux.CategoryID,
                    QuantityPerUnit = aux.QuantityPerUnit,
                    UnitPrice = aux.UnitPrice,
                    UnitsInStock = aux.UnitsInStock,
                    UnitsOnOrder = aux.UnitsOnOrder,
                    ReorderLevel = aux.ReorderLevel,
                    Discontinued = aux.Discontinued

                };

                return producto;
            }
            else
            {

                return null;

            }


        }

        public ModelProducts BuscaProductoId(int id)
        {

            var aux = Productos.Set().FirstOrDefault(c => c.ProductID == id);

            if (aux != null)
            {
                var producto = new ModelProducts()
                {
                    ProductID = aux.ProductID,
                    ProductName = aux.ProductName,
                    SupplierID = aux.SupplierID,
                    CategoryID = aux.CategoryID,
                    QuantityPerUnit = aux.QuantityPerUnit,
                    UnitPrice = aux.UnitPrice,
                    UnitsInStock = aux.UnitsInStock,
                    UnitsOnOrder = aux.UnitsOnOrder,
                    ReorderLevel = aux.ReorderLevel,
                    Discontinued = aux.Discontinued

                };

                return producto;
            }
            else
            {

                return null;

            }

        }

    }
}
