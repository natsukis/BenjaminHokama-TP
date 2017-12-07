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
    public class DetailMethod
    {
        private Repository<Order_Details> Detalles = new Repository<Order_Details>();

        public void ActualizarOrden(ModelOrderDetails detalle)
        {
            
            var ordenActualizada = new Order_Details()
            {

                OrderID = detalle.OrderID,
                ProductID = detalle.ProductID,
                UnitPrice = detalle.UnitPrice,
                Quantity = detalle.Quantity,
                Discount = detalle.Discount

            };

            Detalles.Update(ordenActualizada);

            Detalles.SaveChanges();

        }

    }
}
