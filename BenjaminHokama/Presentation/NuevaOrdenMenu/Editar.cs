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

namespace Presentation.NuevaOrdenMenu
{
    public class Editar
    {

        public void EditarOrden()
        {
            int ordenId;
            bool validarId;

            do
            {
                Console.WriteLine("Ingrese numero de Orden ID a editar");
                validarId = Int32.TryParse(Console.ReadLine(), out ordenId);
            } while (!validarId);

            var validacion = new ValidaOrden().BuscaProducto(ordenId);

            if (validacion == null)
            {
                Console.WriteLine("La orden no se encuentra en la base de datos");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine($"OrderID: {validacion.OrderID }");
                Console.WriteLine("");

                string opcionMenu;



                Console.WriteLine($"1 - ClienteID: {validacion.CustomerID}");
                Console.WriteLine($"2 - Empleado ID: {validacion.EmployeeID}");
                Console.WriteLine($"3 - Order Date: {validacion.OrderDate}");
                Console.WriteLine($"4 - Required Date: {validacion.RequiredDate}");
                Console.WriteLine($"5 - Shipped Date: {validacion.ShippedDate}");
                Console.WriteLine($"6 - Ship Via: {validacion.ShipVia}");
                Console.WriteLine($"7 - Freight: {validacion.Freight}");
                Console.WriteLine($"8 - Ship Name: {validacion.ShipName}");
                Console.WriteLine($"9 - Ship Address: {validacion.ShipAddress}");
                Console.WriteLine($"10 - Ship City: {validacion.ShipCity}");
                Console.WriteLine($"11 - Ship Region: {validacion.ShipRegion}");
                Console.WriteLine($"12 - Ship Postal Code: {validacion.ShipPostalCode}");
                Console.WriteLine($"13 - Ship Country: {validacion.ShipCountry}");
                Console.WriteLine("14 - Salir");
                do
                {
                    Console.WriteLine("Orden encontrada, que desea modificar?");

                    opcionMenu = Console.ReadLine();



                    switch (opcionMenu)
                    {
                        case "1":

                            bool clientValid;
                            do
                            {
                                Console.WriteLine("Ingrese su nuevo cliente ID (5 Letras)");
                                validacion.CustomerID = Console.ReadLine().ToUpper();
                                clientValid = new BuscarCliente().ValidarCliente(validacion.CustomerID);

                            } while ((validacion.CustomerID.Length) != 5 || !clientValid);

                            break;
                        case "2":


                            var validacionEmpleado = new ValidaEmpleado();
                            bool empleado, empleado1;
                            do
                            {
                                Console.WriteLine("Ingrese nuevo nombre del empleado");
                                empleado1 = Int32.TryParse(Console.ReadLine(), out var aux);

                                empleado = validacionEmpleado.ValidaPorId(aux);

                                if (!empleado)
                                {
                                    Console.WriteLine("Empleado no registrado, reingrese datos: ");
                                }
                                validacion.EmployeeID = aux;
                            } while (!empleado1 || !empleado);

                            break;

                        case "3":
                            Console.WriteLine("Nuevo OrderDate: (en formato dd-mm-YYYY)");
                            var fechaRequerida = DateTime.TryParse(Console.ReadLine(), out var orderDate);
                            orderDate = new ValidadFecha().ValidaFecha(fechaRequerida, orderDate);
                            validacion.OrderDate = orderDate;
                            break;

                        case "4":
                            Console.WriteLine("Nuevo RequiredDate: (en formato dd-mm-YYYY)");
                            var fechaRequerida1 = DateTime.TryParse(Console.ReadLine(), out var requiredDate);
                            requiredDate = new ValidadFecha().ValidaFecha(fechaRequerida1, requiredDate);
                            validacion.RequiredDate = requiredDate;

                            break;
                        case "5":
                            Console.WriteLine("Nuevo ShippedDate: (en formato dd-mm-YYYY)");
                            var fechaRequerida2 = DateTime.TryParse(Console.ReadLine(), out var shipDate);
                            shipDate = new ValidadFecha().ValidaFecha(fechaRequerida2, shipDate);
                            validacion.ShippedDate = shipDate;

                            break;
                        case "6":
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
                            validacion.ShipVia = shipVia;

                            break;
                        case "7":

                            decimal freight;
                            bool validofreight;
                            do
                            {
                                Console.WriteLine("Ingrese Freight");
                                validofreight = decimal.TryParse(Console.ReadLine(), out freight);
                            } while (!validofreight);

                            validacion.Freight = freight;
                            break;

                        case "8":
                            Console.WriteLine("Nuevo ShipName: ");
                            validacion.ShipName = Console.ReadLine();
                            break;

                        case "9":
                            Console.WriteLine("Nuevo ShipAddress: ");
                            validacion.ShipAddress = Console.ReadLine();
                            break;
                        case "10":
                            Console.WriteLine("Nuevo ShipCity: ");
                            validacion.ShipCity = Console.ReadLine();
                            break;
                        case "11":
                            Console.WriteLine("Nuevo ShipRegion: ");
                            validacion.ShipRegion = Console.ReadLine();
                            break;
                        case "12":
                            Console.WriteLine("Nuevo ShipPostalCode: ");
                            validacion.ShipPostalCode = Console.ReadLine();
                            break;
                        case "13":
                            Console.WriteLine("Nuevo ShipCountry: ");
                            validacion.ShipCountry = Console.ReadLine();
                            break;

                        case "14":
                            var actualizar = new ActualizarOrden();
                            actualizar.Actualizar(validacion);
                            Console.WriteLine("Actualizacion aplicada ");
                            break;

                        default:
                            Console.WriteLine("Ingrese opcion correcta ");
                            break;
                    }
                } while (opcionMenu != "14");


                /*
                 * Otra manera editando solo el order details y no la order aunque no llegue a comprobar que no tuviera fallas
                * var selector = 0;
                * foreach (var detalles in validacion.Order_Details)
                {

                    Console.WriteLine($"{selector}- ProductID: {detalles.ProductID }, UnitPrice: {detalles.UnitPrice }, Quantity: {detalles.Quantity }, Discount): {detalles.Discount }");
                    selector++;
                }

                bool valid;
                int opcion;
                do
                {

                    valid = Int32.TryParse(Console.ReadLine(), out opcion);

                    if (!valid || opcion < 0 || opcion >= selector)
                    {
                        Console.WriteLine("Opcion incorrecta, elija correctamente");
                    }

                } while (!valid || opcion < 0 || opcion >= selector);

                int productId;
                bool validId;
                ModelProducts producto = null;
                do
                {
                    Console.WriteLine($"ProductID actual: {validacion.Order_Details.ElementAt(opcion).ProductID}, ingrese nuevo valido:");
                    validId = Int32.TryParse(Console.ReadLine(), out productId);

                    if (validId)
                    {
                        producto = new ValidaProducto().BuscaProductoId(productId);
                    }

                } while (!validId || (producto == null));

                decimal unitPrice;
                bool validUnit;
                do
                {
                    Console.WriteLine($"UnitPrice actual: {validacion.Order_Details.ElementAt(opcion).UnitPrice}, ingrese nuevo");
                    validUnit = decimal.TryParse(Console.ReadLine(), out unitPrice);
                } while (!validUnit);

                short quantity;
                bool validquantity;
                do
                {
                    Console.WriteLine($"Quantity actual: {validacion.Order_Details.ElementAt(opcion).Quantity}, ingrese nuevo");
                    validquantity = short.TryParse(Console.ReadLine(), out quantity);
                } while (!validquantity);

                float discount;
                bool validDiscount;
                do
                {
                    Console.WriteLine($"Discount actual: {validacion.Order_Details.ElementAt(opcion).Discount}, ingrese nuevo");
                    validDiscount = float.TryParse(Console.ReadLine(), out discount);
                } while (!validDiscount);

            
                validacion.Order_Details.ElementAt(opcion).ProductID = productId;
                validacion.Order_Details.ElementAt(opcion).UnitPrice = unitPrice;
                validacion.Order_Details.ElementAt(opcion).Quantity = quantity;
                validacion.Order_Details.ElementAt(opcion).Discount = discount ;

                var actualizacion = new ActualizarOrden();
                actualizacion.Actualizar(validacion);*/

                /*  var detalleActualizado = new ModelOrderDetails()
                {
                    OrderID = ordenId,
                    ProductID = productId,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    Discount = discount

                };
                */

                /*var actualizacion = new DetailMethod();
                actualizacion.ActualizarOrden(detalleActualizado);*/

            }


        }






    }
}
