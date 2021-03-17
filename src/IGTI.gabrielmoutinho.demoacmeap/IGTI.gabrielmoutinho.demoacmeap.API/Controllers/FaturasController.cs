using IGTI.gabrielmoutinho.demoacmeap.API.Models;
using IGTI.gabrielmoutinho.demoacmeap.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FaturasController : Controller
    {
        private readonly FaturasRepository _faturasRepository;
        public FaturasController(FaturasRepository faturasRepository)
        {
            _faturasRepository = faturasRepository;
        }

        [HttpGet]
        public IEnumerable<Fatura> Index()
        {
            return _faturasRepository.GetFaturas();
        }

        [HttpGet]
        [Route("[action]")]
        public Fatura GetByCodigo(string codigo)
        {
            return _faturasRepository.GetFaturaByCodigo(codigo);
        }

        [HttpGet]
        [Route("[action]")]
        public Fatura GetByCliente(string cpf)
        {
            return _faturasRepository.GetFaturaByClienteCpf(cpf);
        }
        [HttpPost]
        public IActionResult CreateFatura(Fatura fatura)
        {
            try
            {
                _faturasRepository.AddFatura(fatura);
                return StatusCode(201);
            }
            catch 
            {
                return StatusCode(500);
            }
        }
    }
}
