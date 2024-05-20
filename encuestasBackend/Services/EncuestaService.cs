using Microsoft.EntityFrameworkCore;
using encuestasBackend.Models;
// using System.Collections.Generic;
// using System.Linq;

namespace encuestasBackend.Services
{
    public class EncuestaService {

        private readonly ContextoDb _context;

        public EncuestaService(ContextoDb context) {
            _context = context;
        }

        public List<Encuesta> GetEncuestasConCampos() 
        {
            return _context.Encuestas.Include(f => f.EncuestaCampos).ToList();
        }

        public async Task CrearEncuesta(Encuesta encuesta)
        {
            _context.Encuestas.Add(encuesta);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteEncuesta(int id)
        {
            var encuesta = await _context.Encuestas
                            .Include(e => e.EncuestaCampos)
                            .FirstOrDefaultAsync(e => e.IdEncuesta == id);

            if (encuesta == null)
            {
                return false;
            }
            _context.Encuestas.Remove(encuesta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Encuesta> UpdateEncuesta(int id, Encuesta encuesta)
        {
            var encuestaExistente =  await _context.Encuestas.FindAsync(id);

            if (encuestaExistente == null) 
            {   
                return null;
            }

            encuestaExistente.nombreEncuesta = encuesta.nombreEncuesta;
            encuestaExistente.descripcion = encuesta.descripcion;

            await _context.SaveChangesAsync();

            return encuestaExistente;
        }


    }
}