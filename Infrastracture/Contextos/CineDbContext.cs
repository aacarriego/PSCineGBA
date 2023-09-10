using Domain.Entities.Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contextos
{
    internal class CineDbContext : DbContext
    {
        // Set de tablas
        public DbSet<Sala> Salas { get; set; }

        public DbSet<Pelicula> Peliculas { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Funcion> Funciones { get; set; }


        //Configuracion relaciones y FK
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // UNA PELICULA ASOCIADA A MUCHAS FUNCIONES + FK
            modelBuilder.Entity<Funcion>()
                .HasOne(fun => fun.Peliculas)
                .WithMany(pel => pel.Funciones)
                .HasForeignKey(fun => fun.PeliculaId);

            // UN GENERO ASOCIADO A MUCHAS PELICULAS + FK
            modelBuilder.Entity<Genero>()
              .HasMany(gen => gen.Peliculas)
              .WithOne(pel => pel.genero)
              .HasForeignKey(p => p.GeneroId);

            //// UNA SALA TIENE MUCHAS FUNCIONES + FK
            modelBuilder.Entity<Sala>()
                .HasMany(s => s.Funciones)
                .WithOne(f => f.Salas)
                .HasForeignKey(f => f.SalaId);

            // UNA FUNCION TIENE MUCHOS TICKETS + FK
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.funcion)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FuncionId);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-N8FS7SBV;Database=CineDataBase;Trusted_Connection=True;TrustServerCertificate=True");
        }



    }
}
