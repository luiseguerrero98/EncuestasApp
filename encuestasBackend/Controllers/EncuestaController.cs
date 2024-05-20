using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using encuestasBackend.Models;
using encuestasBackend.Services;
using System.Linq;
using System.Diagnostics;
namespace encuestasBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EncuestaController : ControllerBase
    {
        private readonly EncuestaService _encuestaService;
        private readonly EncuestaCampoService _encuestaCampoService;

        public EncuestaController (EncuestaService encuestaService, EncuestaCampoService encuestaCampoService)
        {
            _encuestaService = encuestaService;
            _encuestaCampoService = encuestaCampoService;
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Encuesta>> GetEncuestasConCampos()
        {
            var encuestas = _encuestaService.GetEncuestasConCampos();
            return Ok(encuestas);
        }

        [HttpPost] 
        public async Task<IActionResult> CrearEncuesta([FromBody] Encuesta encuesta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var idEncuesta = 
            await _encuestaService.CrearEncuesta(encuesta);

            // foreach (var campo in encuesta.EncuestaCampos)
            // {
            //     //Console.WriteLine(campo);
            //     campo.IdEncuesta = idEncuesta;
            //     await _encuestaCampoService.AddEncuestaCampo(campo);
            // }

            return Ok(encuesta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncuesta(int id)
        {
            var result = await _encuestaService.DeleteEncuesta(id);

            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}