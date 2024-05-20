using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using encuestasBackend.Models;

public class ContextoDb : DbContext

{
    public ContextoDb(DbContextOptions<ContextoDb> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios {get; set;}
    public DbSet <Encuesta> Encuestas {get; set;}
    public DbSet <EncuestaCampo> EncuestaCampos {get; set;}

    protected override void OnModelCreating (ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<EncuestaCampo>(entity =>
        {
            entity.HasKey(e => e.IdEncuestaCampo);
             entity.Property(e => e.IdEncuestaCampo)
                  .UseIdentityColumn();
            entity.Property(e => e.nombre).IsRequired();
            entity.Property(e => e.titulo).IsRequired();
            entity.Property(e => e.requerido).IsRequired();

            entity.HasOne(e => e.Encuesta)
                  .WithMany(e => e.EncuestaCampos) 
                  .HasForeignKey(e => e.IdEncuesta)
                  .OnDelete(DeleteBehavior.Cascade);
        });

    }

}