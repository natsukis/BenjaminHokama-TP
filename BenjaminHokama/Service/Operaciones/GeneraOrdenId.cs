using Data;
using Data.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GeneraOrdenId
    {
        private Repository<Orders> Orden = new Repository<Orders>();

        public int OrdenId()
        {
            var x= Orden.Set().Max(c=>c.OrderID);
            return x + 1;
        }
    }
}
