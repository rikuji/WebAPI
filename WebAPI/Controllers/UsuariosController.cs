using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public UsuariosController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioRepo.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return new ObjectResult(usuario);
        }

    }
}