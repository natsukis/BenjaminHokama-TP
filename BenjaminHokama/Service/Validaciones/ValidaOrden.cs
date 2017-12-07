using Data;
using Data.Northwind;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validaciones
{
    public class ValidaOrden
    {
        private Repository<Orders> Ordenes = new Repository<Orders>();

        public ModelOrder BuscaProducto(int orderId)
        {

            var aux = Ordenes.Set().FirstOrDefault(c => c.OrderID == orderId);

            if (aux != null)
            {

                List<ModelOrderDetails> listaDetalles = new List<ModelOrderDetails>();

                foreach (var x in aux.Order_Details)
                {
                    listaDetalles.Add(new ModelOrderDetails()
                    {

                        OrderID = x.OrderID,
                        ProductID = x.ProductID,
                        UnitPrice = x.UnitPrice,
                        Quantity = x.Quantity,
                        Discount = x.Discount


                    });
                }


                var orden = new ModelOrder()
                {
                    OrderID = aux.OrderID,
                    CustomerID = aux.CustomerID,
                    EmployeeID = aux.EmployeeID,
                    OrderDate = aux.OrderDate,
                    RequiredDate = aux.RequiredDate,
                    ShippedDate = aux.ShippedDate,
                    ShipVia = aux.ShipVia,
                    Freight = aux.Freight,
                    ShipName = aux.ShipName,
                    ShipAddress = aux.ShipAddress,
                    ShipCity = aux.ShipCity,
                    ShipRegion = aux.ShipRegion,
                    ShipPostalCode = aux.ShipCountry,
                    ShipCountry = aux.ShipCountry,
                    Order_Details = listaDetalles

                };

                return orden;
            }
            else
            {

                return null;

            }

        }

    }
}
