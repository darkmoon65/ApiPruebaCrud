using ApiPruebaCrud.Models;
using ApiPruebaCrud.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoController()
        {
            _productoRepository = new ProductoRepository();
        }

        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _productoRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Producto Get(int id)
        {
            return _productoRepository.GetById(id);
        }

        [HttpPost]
        public void Add([FromBody] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _productoRepository.Add(producto);
            }
        }
        [HttpPut]
        public void Update(int id, [FromBody] Producto producto)
        {
            producto.ProductoId = id;
            if (ModelState.IsValid)
            {
                _productoRepository.Update(producto);
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _productoRepository.Delete(id);
        }
    }
}
