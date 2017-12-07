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
    public class ActualizarOrden
    {
        private Repository<Orders> Ordenes = new Repository<Orders>();

        public void Actualizar(ModelOrder orden)
        {
            var ordenAux = new Orders();

            var order = Ordenes.Set().FirstOrDefault(c => c.OrderID == orden.OrderID);

            order.OrderID = orden.OrderID;
            order.CustomerID = orden.CustomerID;
            order.EmployeeID = orden.EmployeeID;
            order.OrderDate = orden.OrderDate;
            order.RequiredDate = orden.RequiredDate;
            order.ShippedDate = orden.ShippedDate;
            order.ShipVia = orden.ShipVia;
            order.Freight = orden.Freight;
            order.ShipName = orden.ShipName;
            order.ShipAddress = orden.ShipAddress;
            order.ShipCity = orden.ShipCity;
            order.ShipRegion = orden.ShipRegion;
            order.ShipPostalCode = orden.ShipPostalCode;
            order.ShipCountry = orden.ShipCountry;
            
            Ordenes.SaveChanges();


            /* No me actualizaba en bd de esta forma, horas sufriendo, pero de la otra si T.T
             * foreach (var x in orden.Order_Details)
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


             Ordenes.Update(nuevaOrden);

             Ordenes.SaveChanges();
          */

        }

    }
}
