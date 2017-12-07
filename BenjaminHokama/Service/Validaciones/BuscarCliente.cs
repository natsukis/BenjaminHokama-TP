using Data;
using Data.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validaciones
{
    public class BuscarCliente
    {

        private Repository<Customers> Clientes = new Repository<Customers>();

        public string BuscaCliente(string id)
        {

            var cliente = Clientes.Set().FirstOrDefault(c => c.CustomerID == id);

           
                return cliente.ContactName;
           
        }

        public bool ValidarCliente(string id)
        {
            var cliente = Clientes.Set().FirstOrDefault(c => c.CustomerID == id);

            if(cliente != null)
            {
                return true;
            }
            else
            {
                return false;
            }
                        
        }

    }
}
