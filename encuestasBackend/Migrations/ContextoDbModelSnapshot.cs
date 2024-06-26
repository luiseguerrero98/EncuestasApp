﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace encuestasBackend.Migrations
{
    [DbContext(typeof(ContextoDb))]
    partial class ContextoDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("encuestasBackend.Models.Encuesta", b =>
                {
                    b.Property<int>("IdEncuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEncuesta"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreEncuesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEncuesta");

                    b.ToTable("Encuestas");
                });

            modelBuilder.Entity("encuestasBackend.Models.EncuestaCampo", b =>
                {
                    b.Property<int>("IdEncuestaCampo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEncuestaCampo"));

                    b.Property<int>("IdEncuesta")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("requerido")
                        .HasColumnType("BIT");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEncuestaCampo");

                    b.HasIndex("IdEncuesta");

                    b.ToTable("EncuestaCampos");
                });

            modelBuilder.Entity("encuestasBackend.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("contraseniaHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("encuestasBackend.Models.EncuestaCampo", b =>
                {
                    b.HasOne("encuestasBackend.Models.Encuesta", "Encuesta")
                        .WithMany("EncuestaCampos")
                        .HasForeignKey("IdEncuesta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encuesta");
                });

            modelBuilder.Entity("encuestasBackend.Models.Encuesta", b =>
                {
                    b.Navigation("EncuestaCampos");
                });
#pragma warning restore 612, 618
        }
    }
}
