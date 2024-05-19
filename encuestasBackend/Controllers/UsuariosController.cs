using Microsoft.AspNetCore.Mvc;
using encuestasBackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace encuestasBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ContextoDb _context;
        
        public UsuariosController (ContextoDb context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            List<Usuario> usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);
        }
    }
}