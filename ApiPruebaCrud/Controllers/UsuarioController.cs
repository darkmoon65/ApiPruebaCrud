using ApiPruebaCrud.Models;
using ApiPruebaCrud.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ApiPruebaCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UsuarioController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _userRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return _userRepository.GetById(id);
        }
        [HttpPost]
        public void Add([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Add(usuario);
            }
        }
        [HttpPut]
        public void Update(int id, [FromBody] Usuario usuario)
        {
            usuario.UserId = id;
            if (ModelState.IsValid)
            {
                _userRepository.Update(usuario);
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
