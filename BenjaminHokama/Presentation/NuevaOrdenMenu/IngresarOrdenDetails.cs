using Service;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class IngresarOrdenDetails
    {

        public ICollection<ModelOrderDetails> CargarOrden(int ordenId)
        {

            ICollection<ModelOrderDetails> ListaProductos = new List<ModelOrderDetails>();
            string opcion;

            do
            {
                Console.WriteLine("Desea cargar un nuevo producto a su orden? S / N");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "s":
                    case "S":

                        var producto = new ModelProducts(); ;
                        var validacionProducto = new ValidaProducto();
                        var ordenDetail = new ModelOrderDetails();

                        do
                        {
                            Console.WriteLine("Ingrese nombre del producto:");
                            var nombre = Console.ReadLine();

                            producto = validacionProducto.BuscaProducto(nombre);

                            if (producto == null)
                            {
                                Console.WriteLine("Producto no registrado, reingrese dato: ");
                            }

                        } while (producto == null);

                        short cantidad;
                        bool cantValida;
                        do
                        {
                            Console.WriteLine("Ingrese cantidad (debe ser mayor a 0):");
                            cantValida = short.TryParse(Console.ReadLine(), out cantidad);
                        } while (!cantValida || cantidad < 0);

                        float descuento;
                        bool descValida;
                        do
                        {
                            Console.WriteLine("Ingrese descuento (debe ser mayor o igual a 0 y menor a 30):");
                            descValida = float.TryParse(Console.ReadLine(), out descuento);
                        } while (!descValida || descuento <= 0 || descuento > 30);


                        ordenDetail.OrderID = ordenId;
                        ordenDetail.ProductID = producto.ProductID;
                        ordenDetail.UnitPrice = (decimal)producto.UnitPrice;
                        ordenDetail.Quantity = cantidad;
                        ordenDetail.Discount = descuento;
                        ordenDetail.Products = producto;

                        ListaProductos.Add(ordenDetail);

                        break;

                    case "n":
                    case "N":
                        Console.WriteLine("Terminado carga de productos");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta, ingrese S para nuevo producto, N para salir");
                        break;
                }

            } while (opcion.ToLower() != "n");

            return ListaProductos;

        }

    }
}
