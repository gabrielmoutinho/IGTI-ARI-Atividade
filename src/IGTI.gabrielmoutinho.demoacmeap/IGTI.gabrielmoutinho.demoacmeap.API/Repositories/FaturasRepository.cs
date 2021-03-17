using IGTI.gabrielmoutinho.demoacmeap.API.Models;
using IGTI.gabrielmoutinho.demoacmeap.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Repositories
{
    public class FaturasRepository
    {
        private readonly APIDbContext _context;

        public FaturasRepository(APIDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Fatura> GetFaturas()
        {
            return _context.Faturas
                .Include(a=> a.Instalacao)
                .ToList();
        }

        public Fatura GetFaturaByCodigo(string codigo)
        {
            return _context.Faturas
                .Include(a => a.Instalacao)
                .FirstOrDefault(a=> a.Codigo == codigo);
        }

        public Fatura GetFaturaByClienteCpf(string cpf)
        {
            return _context.Faturas
                .FirstOrDefault(a => a.Instalacao.Cliente.CPF == cpf);
        }

        public void AddFatura(Fatura fatura)
        {
            _context.Faturas.Add(fatura);
            _context.SaveChanges();
        }
    }
}
