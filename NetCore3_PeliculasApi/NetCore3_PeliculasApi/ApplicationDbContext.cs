using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCore3_PeliculasApi.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCore3_PeliculasApi
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Crear llave compuestas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Llave compuesta ActorId y PeliculaId
            modelBuilder.Entity<PeliculasActores>()
                .HasKey(x => new { x.ActorId, x.PeliculaId });

            //Llave compuesta GeneroId y PeliculaId
            modelBuilder.Entity<PeliculasGeneros>()
                .HasKey(x => new { x.GeneroId, x.PeliculaId });

            //Llave compuesta PeliculaID y SalaDeCineId
            modelBuilder.Entity<PeliculasSalasDeCine>()
                .HasKey(x => new { x.PeliculaId, x.SalaDeCineId });

            var rolAdminId = "5de7957b-1f82-4b64-855c-3eaccdb9316a";
            var usuarioAdminId = "67ae3fce-2cf9-48d8-a61c-6c851293442e";

            var roleAdmin = new IdentityRole()
            {
                Id = rolAdminId,
                Name = "Admin",
                NormalizedName = "Admin"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();

            var username = "duvan@gmail.com";

            var usuarioAdmin = new IdentityUser()
            {
                Id = usuarioAdminId,
                UserName = username,
                NormalizedUserName = username,
                Email = username,
                PasswordHash = passwordHasher.HashPassword(null, "Aa1313151!")
            };

            //modelBuilder.Entity<IdentityUser>().HasData(usuarioAdmin);

            //modelBuilder.Entity<IdentityRole>().HasData(roleAdmin);

            //modelBuilder.Entity<IdentityUserClaim<string>>()
            //    .HasData(new IdentityUserClaim<string>()
            //    {
            //        Id = 1,
            //        ClaimType = ClaimTypes.Role,
            //        UserId = usuarioAdminId,
            //        ClaimValue = "Admin"
            //    });

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Genero> Generos { get; set; }       
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PeliculasActores> PeliculasActores { get; set; }
        public DbSet<PeliculasGeneros> PeliculasGeneros { get; set; }
        public DbSet<PeliculasSalasDeCine> PeliculasSalasDeCine { get; set; }
        public DbSet<SalaDeCine> SalaDeCine { get; set; }
        public DbSet<Review> Reviews { get; set; }


    }
}
