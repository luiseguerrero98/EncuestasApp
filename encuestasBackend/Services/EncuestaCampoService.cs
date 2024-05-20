using Microsoft.EntityFrameworkCore;
using encuestasBackend.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace encuestasBackend.Services 
{
    public class EncuestaCampoService {
        private readonly ContextoDb _context;

        public EncuestaCampoService (ContextoDb context) {
            _context = context;
        }

        public async Task AddEncuestaCampo(EncuestaCampo campo)
        {   
            campo.IdEncuestaCampo = 0;
            // var sql = "INSERT INTO EncuestaCampos (IdEncuesta, Nombre, Titulo, Requerido) VALUES (@IdEncuesta, @Nombre, @Titulo, @Requerido)";
        
            // await _context.Database.ExecuteSqlRawAsync(sql, 
            //     new SqlParameter("@IdEncuesta", campo.IdEncuesta), 
            //     new SqlParameter("@Nombre", campo.nombre), 
            //     new SqlParameter("@Titulo", campo.titulo), 
            //     new SqlParameter("@Requerido", campo.requerido));

            _context.EncuestaCampos.Add(campo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEncuestaCampos(int idEncuesta, Encuesta encuesta) {

            var listaEncuestaCamposDb = await _context.EncuestaCampos.Where(e => e.IdEncuesta == idEncuesta).ToListAsync();

            foreach(var campo in listaEncuestaCamposDb) {
                var campoExistente = encuesta.EncuestaCampos.FirstOrDefault(e => e.IdEncuestaCampo == campo.IdEncuestaCampo);
                if (campoExistente == null) {
                    _context.EncuestaCampos.Remove(campo);
                }
            }

            foreach (var campoActualizado in encuesta.EncuestaCampos) {
                var campoExistente = await _context.EncuestaCampos.FindAsync(campoActualizado.IdEncuestaCampo);

                if (campoExistente != null) {
                    campoExistente.nombre = campoActualizado.nombre;
                    campoExistente.requerido = campoActualizado.requerido;
                    campoExistente.titulo = campoActualizado.titulo;
                } else {
                    _context.EncuestaCampos.Add(campoActualizado);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}