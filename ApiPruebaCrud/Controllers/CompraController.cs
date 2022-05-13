using ApiPruebaCrud.Models;
using ApiPruebaCrud.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPruebaCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly CompraRepository _CompraRepository;

        public CompraController()
        {
            _CompraRepository = new CompraRepository();
        }

        [HttpGet]
        public IEnumerable<Compra> Get()
        {
            return _CompraRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Compra Get(int id)
        {
            return _CompraRepository.GetById(id);
        }

        [HttpPost]
        public void Add([FromBody] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _CompraRepository.Add(compra);
            }
        }
        [HttpPut]
        public void Update(int id, [FromBody] Compra compra)
        {
            compra.CompraId = id;
            if (ModelState.IsValid)
            {
                _CompraRepository.Update(compra);
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _CompraRepository.Delete(id);
        }
    }
}
