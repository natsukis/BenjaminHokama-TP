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
    public class EliminarMostrar
    {

        private Repository<Orders> Ordenes = new Repository<Orders>();
        private Repository<Order_Details> Detalles = new Repository<Order_Details>();


        public int Eliminacion(int id)
        {

            var aux = Ordenes.Set().FirstOrDefault(c => c.OrderID == id);

            if (aux == null)
            {
                return 2;
            }

            if (aux.ShipCountry == "France" || aux.ShipCountry == "Mexico")
            {
                return 0;
            }

            var aux1 = Detalles.Set().Where(c => c.OrderID == id);

            foreach (var ord in aux1)
            {
                Detalles.Remove(ord);


            }
            Detalles.SaveChanges();

            Ordenes.Remove(aux);

            Ordenes.SaveChanges();


            return 1;
        }


        public ModelOrder Mostrar(int id)
        {

            var orden = Ordenes.Set().FirstOrDefault(c => c.OrderID == id);

            if (orden != null)
            {
                var modelo = new ModelOrder
                {
                    OrderID = orden.OrderID,
                    CustomerID = orden.CustomerID,
                    EmployeeID = orden.EmployeeID,
                    OrderDate = orden.OrderDate,
                    RequiredDate = orden.RequiredDate,
                    ShippedDate = orden.ShippedDate,
                    ShipVia = orden.ShipVia,
                    Freight = orden.Freight,
                    ShipName = orden.ShipName,
                    ShipAddress = orden.ShipAddress,
                    ShipCity = orden.ShipCity,
                    ShipRegion = orden.ShipRegion,
                    ShipPostalCode = orden.ShipPostalCode,
                    ShipCountry = orden.ShipCountry
                };


                return modelo;
            }
            else
            {
                return null;
            }


        }

    
        public List<ModelOrder> MostrarTodo()
        {

            var ordenes = Ordenes.Set();
            var Lista = new List<ModelOrder>();

            foreach(var orden in ordenes)
            {
                Lista.Add(new ModelOrder
                {
                    OrderID = orden.OrderID,
                    CustomerID = orden.CustomerID,
                    EmployeeID = orden.EmployeeID,
                    OrderDate = orden.OrderDate,
                    RequiredDate = orden.RequiredDate,
                    ShippedDate = orden.ShippedDate,
                    ShipVia = orden.ShipVia,
                    Freight = orden.Freight,
                    ShipName = orden.ShipName,
                    ShipAddress = orden.ShipAddress,
                    ShipCity = orden.ShipCity,
                    ShipRegion = orden.ShipRegion,
                    ShipPostalCode = orden.ShipPostalCode,
                    ShipCountry = orden.ShipCountry
                });
            }
           
            return Lista;
        }


    }



}

