using Data;
using Data.Northwind;
using Service.Models;
using Service.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Operaciones
{
    public class MejorXPais
    {
        private Repository<Customers> Clientes = new Repository<Customers>();
        private Repository<Order_Details> Detalles = new Repository<Order_Details>();
        private Repository<Orders> Ordenes = new Repository<Orders>();


        public List<ModeloPaisGanancia> Paises()
        {
            var clientes = Clientes.Set().GroupBy(c => c.Country).ToList();
            var ordenes = Ordenes.Set().ToList();

            var detalles = Detalles.Set().ToList();
            

            var list = new List<ModeloPaisGanancia>();


            var prodCant = 0;
            decimal total = 0;

            foreach (var x in clientes)
            {
                var model = new ModeloPaisGanancia();
                model.Country = (x.Key);


                foreach (var y in x.Select(c => c.CustomerID))
                {
                    
                    foreach (var orden in ordenes)
                    {
                        if (orden.CustomerID == y)
                        {
                            total += orden.Order_Details.Sum(c => c.Quantity * c.UnitPrice);

                            foreach (var prod in orden.Order_Details)
                            {
                                if (prod.Quantity > prodCant)
                                {
                                    model.Producto = new ValidaProducto().BuscaProductoId(prod.ProductID).ProductName;
                                }
                            }

                        }

                        if (model.Total < total)
                        {
                            model.Total = total;
                            model.ContactName = new BuscarCliente().BuscaCliente(y);

                        }
                    }
                }

                list.Add(model);
            }

            return list;
        }

    }

}

