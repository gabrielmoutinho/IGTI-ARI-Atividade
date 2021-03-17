using IGTI.gabrielmoutinho.demoacmeap.API.Models;
using IGTI.gabrielmoutinho.demoacmeap.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstalacoesController : Controller
    {
        private readonly InstalacoesRepository _instalacoesRepository;

        public InstalacoesController(InstalacoesRepository instalacoesRepository)
        {
            _instalacoesRepository = instalacoesRepository;
        }
        [HttpGet]
        public IEnumerable<Instalacao> Index()
        {
            return _instalacoesRepository.GetInstalacoes();
        }
        [HttpGet]
        [Route("[action]")]
        public Instalacao GetByCodigo(string codigo)
        {
            return _instalacoesRepository.GetInstalacao(codigo);
        }

        [HttpGet]
        [Route("[action]")]
        public Instalacao GetByCliente(string cpf)
        {
            return _instalacoesRepository.GetInstalacaoByCpfCliente(cpf);
        }

        [HttpPost]
        public IActionResult Create(Instalacao instalacao)
        {
            try
            {
                _instalacoesRepository.AddInstalacao(instalacao);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
