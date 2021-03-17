using IGTI.gabrielmoutinho.demoacmeap.API.Models;
using IGTI.gabrielmoutinho.demoacmeap.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        private readonly ClientesRepository _clientesRepository;

        public ClientesController(ClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }
        [HttpGet]
        public IEnumerable<Cliente> Index()
        {
            return _clientesRepository.GetClientes();
        }
        [HttpGet]
        [Route("[action]")]
        public Cliente GetByCpf(string cpf)
        {
            return _clientesRepository.GetClienteByCpf(cpf);
        }
        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            try
            {
                _clientesRepository.AddCliente(cliente);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
