using Data;
using Data.Northwind;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.NuevaOrden
{
    public class OrdenMethods
    {

        private Repository<Orders> Ordenes = new Repository<Orders>();
        
        public void GuardarOrden(ModelOrder orden)
        {

            var ordenAux = new Orders();

            foreach (var x in orden.Order_Details)
            {

                ordenAux.Order_Details.Add(new Order_Details()
                {

                    OrderID = x.OrderID,
                    ProductID = x.ProductID,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity,
                    Discount = x.Discount

                });

            }
            
            var nuevaOrden = new Orders
            {
                OrderID = orden.OrderID,
                CustomerID = orden.CustomerID,
                EmployeeID = orden.EmployeeID,
                OrderDate = DateTime.Today,
                RequiredDate = orden.RequiredDate,
                ShippedDate = orden.ShippedDate,
                ShipVia = orden.ShipVia,
                Freight = orden.Freight,
                ShipName = orden.ShipName,
                ShipAddress = orden.ShipAddress,
                ShipCity = orden.ShipCity,
                ShipRegion = orden.ShipRegion,
                ShipPostalCode = orden.ShipCountry,
                ShipCountry = orden.ShipCountry,
                Order_Details = ordenAux.Order_Details

            };


            Ordenes.Persist(nuevaOrden);

            Ordenes.SaveChanges();
            
        }
                
    }
}
