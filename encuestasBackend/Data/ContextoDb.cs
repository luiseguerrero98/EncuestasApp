using Microsoft.EntityFrameworkCore;
using encuestasBackend.Models;

public class ContextoDb : DbContext

{
    public ContextoDb(DbContextOptions<ContextoDb> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios {get; set;}
}