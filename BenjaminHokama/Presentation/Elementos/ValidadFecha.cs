using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Elementos
{
    public class ValidadFecha
    {
       
            public DateTime ValidaFecha(bool fecha, DateTime fechaIngresada)
            {

                while (!fecha)
                {
                    Console.WriteLine("Formato incorrecto de fecha, reingreselo");
                    fecha = DateTime.TryParse(Console.ReadLine(), out fechaIngresada);
                }

                return fechaIngresada;

            }
        

    }
}
