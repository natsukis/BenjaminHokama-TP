using Presentation.Elementos;
using Service;
using Service.Models;
using Service.NuevaOrden;
using Service.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class AgregarOrden
    {
        public void IngresarOrden()
        {
            int empleadoId;
            string id;
            var orden = new ModelOrder();

            var ordenId = new GeneraOrdenId().OrdenId();

            orden.OrderID = ordenId;

            bool clientValid;
            do
            {
                Console.WriteLine("Ingrese su cliente ID (5 Letras)");
                id = Console.ReadLine().ToUpper();
                clientValid = new BuscarCliente().ValidarCliente(id);

                if (!clientValid)
                {
                    Console.WriteLine("Ingrese INCORRECTO");
                }

            } while ((id.Length) != 5 || !clientValid);
            orden.CustomerID = id;


            var validacionEmpleado = new ValidaEmpleado();

            do
            {
                Console.WriteLine("Ingrese Nombre del empleado");
                var nombreEmpleado = Console.ReadLine();

                Console.WriteLine("Ingrese Apellido del empleado");
                var apellidoEmpleado = Console.ReadLine();

                empleadoId = validacionEmpleado.BuscaEmpleado(nombreEmpleado, apellidoEmpleado);

                if (empleadoId == 0)
                {
                    Console.WriteLine("Empleado no registrado, reingrese datos: ");
                }

            } while (empleadoId == 0);
            orden.EmployeeID = empleadoId;

            decimal freight;
            bool validofreight;
            do
            {
                Console.WriteLine("Ingrese Freight");
                validofreight = decimal.TryParse(Console.ReadLine(), out freight);
            } while (!validofreight);
            orden.Freight = freight;


            Console.WriteLine("Ingrese RequiredDate (en formato dd-mm-YYYY)");
            var fechaRequerida = DateTime.TryParse(Console.ReadLine(), out var requiredDate);
            requiredDate = new ValidadFecha().ValidaFecha(fechaRequerida, requiredDate);
            orden.RequiredDate = requiredDate;


            Console.WriteLine("Ingrese fecha de envio estimado (en formato dd-mm-YYYY)");
            var fechaShip = DateTime.TryParse(Console.ReadLine(), out var shippedDate);
            shippedDate = new ValidadFecha().ValidaFecha(fechaShip, shippedDate);
            orden.ShippedDate = shippedDate;


            bool validoshipvia;
            int shipVia;
            do
            {
                Console.WriteLine("Ingrese ShipVia: 1-Speedy 2-United 3-Federal");
                validoshipvia = Int32.TryParse(Console.ReadLine(), out shipVia);
                if (shipVia < 1 || shipVia > 3)
                {
                    validoshipvia = false;
                }
            } while (!validoshipvia);
            orden.ShipVia = shipVia;


            Console.WriteLine("Ingrese ShipName");
            var shipName = Console.ReadLine();
            orden.ShipName = shipName;

            Console.WriteLine("Ingrese ShipAddress");
            var shipAddress = Console.ReadLine();
            orden.ShipAddress = shipAddress;

            Console.WriteLine("Ingrese ShipCity");
            var shipCity = Console.ReadLine();
            orden.ShipCity = shipCity;

            Console.WriteLine("Ingrese ShipRegion");
            var shipRegion = Console.ReadLine();
            orden.ShipRegion = shipRegion;

            Console.WriteLine("Ingrese ShipPostalCode");
            var shipPostalCode = Console.ReadLine();
            orden.ShipPostalCode = shipPostalCode;

            Console.WriteLine("Ingrese ShipCountry");
            var shipCountry = Console.ReadLine();
            orden.ShipCountry = shipCountry;

            orden.Order_Details = new IngresarOrdenDetails().CargarOrden(ordenId);

            var nuevaOrden = new OrdenMethods();
            nuevaOrden.GuardarOrden(orden);


            Console.WriteLine($"Orden Id {ordenId} con importe {new PrecioTotal().CalcularTotal(ordenId)} se ha creado correctamente");

        }




    }
}
