using IGTI.gabrielmoutinho.demoacmeap.API.Models;
using IGTI.gabrielmoutinho.demoacmeap.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Repositories
{
    public class ClientesRepository
    {
        private readonly APIDbContext _context;

        public ClientesRepository(APIDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes
                .Include(a => a.Endereco)
                .Include(a => a.Instalacao)
                    .ThenInclude(a => a.Fatura)
                .Include(a => a.Instalacao)
                    .ThenInclude(a => a.Endereco)
                .ToList();
        }

        public Cliente GetClienteByCpf(string cpf)
        {
            return _context.Clientes
                .Include(a => a.Endereco)
                .Include(a => a.Instalacao)
                    .ThenInclude(a => a.Fatura)
                .Include(a=> a.Instalacao)
                    .ThenInclude(a=> a.Endereco)
                .FirstOrDefault(a => a.CPF == cpf);
        }

        public void AddCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Erro ao criar");
            }
        }
    }
}
