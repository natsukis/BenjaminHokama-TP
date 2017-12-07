using Presentation.NuevaOrdenMenu;
using Service;
using Service.Operaciones;
using Service.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {

            string opcion;

            var EliminarMostrar = new EliminarMostrar();

            do
            {
                Console.WriteLine("");
                Console.WriteLine("***********************************************************************************");
                Console.WriteLine("Bienvenido al menu de Northwind - Elija una opcion");
                Console.WriteLine("1-Eliminacion de una orden");
                Console.WriteLine("2-Creacion de una orden");
                Console.WriteLine("3-Edicion de una orden");
                Console.WriteLine("4-Mostrar una orden");
                Console.WriteLine("5-Mostrar todas las ordenes");
                Console.WriteLine("6-Mostrar x país cliente con mayor compra y producto más vendido");
                Console.WriteLine("7-Salir");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":

                        bool evalua;
                        int opcion1;
                        do
                        {
                            Console.WriteLine("Ingrese id de orden a eliminar");
                            evalua = Int32.TryParse(Console.ReadLine(), out opcion1);
                        } while (!evalua);



                        var response = EliminarMostrar.Eliminacion(opcion1);

                        if (response == 1)
                        {
                            Console.WriteLine("Se elimino exitosamente");
                        }

                        else if (response == 2)
                        {
                            Console.WriteLine("Id incorrecto");
                        }
                        else
                        {
                            Console.WriteLine("No se puede eliminar la orden por provenir de México o Francia");
                        }

                        break;

                    case "2":

                        var agregar = new AgregarOrden();
                        agregar.IngresarOrden();


                        break;

                    case "3":
                        var editar = new Editar();
                        editar.EditarOrden();
                        break;

                    case "4":

                        bool evalua4;
                        int opcion4;

                        do
                        {
                            Console.WriteLine("Ingrese id a buscar(Formato correcto numero)");
                            evalua4 = Int32.TryParse(Console.ReadLine(), out opcion4);
                        } while (!evalua4);

                        var orden = EliminarMostrar.Mostrar(opcion4);

                        if (orden != null)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Detalles de su orden: ");
                            Console.WriteLine($"Id: {orden.OrderID} - ClienteId: {orden.CustomerID} - EmpleadoId: {orden.EmployeeID} - Freight: {orden.Freight}");
                            Console.WriteLine($"Fecha Orden: {orden.OrderDate} - RequiredDate: {orden.RequiredDate} - ShippedDate: {orden.ShippedDate} - ShipVia: {orden.ShipVia}");
                            Console.WriteLine($"ShipName: {orden.ShipName} - ShipAddress: {orden.ShipAddress} - ShipCity: {orden.ShipCity}");
                            Console.WriteLine($"ShipRegion: {orden.ShipRegion} - ShipPostalCode: {orden.ShipPostalCode} - ShipCountry: {orden.ShipCountry}");

                        }
                        else
                        {
                            Console.WriteLine("Id incorrecto ");
                        }

                        break;

                    case "5":

                        Console.WriteLine("Mostrando todas las ordenes: ");

                        var lista = EliminarMostrar.MostrarTodo();
                        foreach (var item in lista)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"Id de factura: {item.OrderID} - Nombre de cliente: {new BuscarCliente().BuscaCliente(item.CustomerID)} - Importe total: {new PrecioTotal().CalcularTotal(item.OrderID)} ");

                        }

                        break;

                    case "6":
                        var x = new MejorXPais();
                        var imprimir = x.Paises();
                        foreach (var item in imprimir)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"Pais: {item.Country} - Nombre de cliente con mayor compra: {item.ContactName} - Importe total: {item.Total} - Producto mas vendido: {item.Producto} ");

                        }

                        break;
                }
            } while (opcion != "7");

            Console.WriteLine("Fin del programa, ingrese una tecla para continuar");
            Console.ReadLine();

        }


    }

}
