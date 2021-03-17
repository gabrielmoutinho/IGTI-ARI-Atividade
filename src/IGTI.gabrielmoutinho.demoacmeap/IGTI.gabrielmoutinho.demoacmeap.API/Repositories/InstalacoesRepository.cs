using IGTI.gabrielmoutinho.demoacmeap.API.Models;
using IGTI.gabrielmoutinho.demoacmeap.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Repositories
{
    public class InstalacoesRepository
    {
        private readonly APIDbContext _context;

        public InstalacoesRepository(APIDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Instalacao> GetInstalacoes()
        {
            return _context.Instalacoes
                .Include(a=> a.Endereco)
                .Include(a=> a.Fatura)
                .ToList();
        }

        public Instalacao GetInstalacao(string codigo)
        {
            return _context.Instalacoes
                .Include(a => a.Endereco)
                .Include(a => a.Fatura)
                .FirstOrDefault(a=> a.Codigo == codigo);
        }

        public Instalacao GetInstalacaoByCpfCliente(string cpf)
        {
            return _context.Instalacoes
                .Include(a => a.Endereco)
                .Include(a => a.Fatura)
                .FirstOrDefault(a => a.Cliente.CPF == cpf);
        }

        public void AddInstalacao(Instalacao instalacao)
        {
            _context.Instalacoes.Add(instalacao);
            _context.SaveChanges();
        }
    }
}
