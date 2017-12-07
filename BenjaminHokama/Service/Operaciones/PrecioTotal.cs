using Data;
using Data.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PrecioTotal
    {
        private Repository<Orders> Ordenes = new Repository<Orders>();

        public decimal CalcularTotal(int orderId)
        {

            var orden = Ordenes.Set().FirstOrDefault(c => c.OrderID == orderId);
            decimal total = 0;

            foreach (var x in orden.Order_Details)
            {
                total = total + ((decimal)x.Quantity * x.UnitPrice - ((decimal)x.Quantity * x.UnitPrice * (decimal)(x.Discount/100))); 
            }
                    return total;

                }

    }
}
