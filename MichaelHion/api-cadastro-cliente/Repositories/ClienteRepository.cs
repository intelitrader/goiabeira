using api_cadastro_cliente.Context;
using api_cadastro_cliente.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cadastro_cliente.Repositories
{
    public class ClienteRepository : IClientes
    {
        public void deleteCliente(string Id)
        {
            using (var ctx = new ClienteContexto())
            {
                var existe = findById(Id);
                if (existe != null)
                {
                    ctx.Clientes.Remove(existe);
                    ctx.SaveChanges();
                }

            }
        }

        public void editarCliente(string Id, ClienteModel cliente)
        {
            using (var ctx = new ClienteContexto())
            {
                var existe = findById(Id);
                if (existe != null)
                {
                    ctx.Clientes.Update(cliente);
                    ctx.SaveChanges();
                }

            }
        }

        public ClienteModel findById(string Id)
        {
            using (var ctx = new ClienteContexto())
            {
                return ctx.Clientes.FirstOrDefault(c => c.Id == Id);

            }
        }

        public void inserirCliente(ClienteModel cliente)
        {
            using (var ctx = new ClienteContexto())
            {
                ctx.Clientes.Add(cliente);
                ctx.SaveChanges();

            }
        }

        public List<ClienteModel> listarCliente()
        {
            using (var ctx = new ClienteContexto())
            {
                return ctx.Clientes.ToList();
            }
        }
    }
}

