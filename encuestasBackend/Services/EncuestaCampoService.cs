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
    }
}