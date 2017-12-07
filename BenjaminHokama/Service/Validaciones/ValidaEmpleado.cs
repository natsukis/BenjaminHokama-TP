using Data;
using Data.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ValidaEmpleado
    {

        private Repository<Employees> Empleados = new Repository<Employees>();

        public int BuscaEmpleado(string nombre, string apellido)
        {

            var aux = Empleados.Set().FirstOrDefault(c => c.FirstName == nombre && c.LastName == apellido);

            if (aux == null)
            {
                return 0;
            }
            else
            {
                return aux.EmployeeID;
            }

        }

        public bool ValidaPorId(int id)
        {

            var aux = Empleados.Set().FirstOrDefault(c => c.EmployeeID == id);

            if (aux == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
