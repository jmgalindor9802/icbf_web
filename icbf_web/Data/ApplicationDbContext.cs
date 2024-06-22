using icbf_web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace icbf_web.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Usuario>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Usuarios");

            });
        }

        public DbSet<Jardin> Jardines { get; set; }
        public DbSet<MadreComunitaria> MadresComunitarias { get; set; }
        public DbSet<Nino> Ninos { get; set; }
        public DbSet<RegistroAsistencia> RegistrosAsistencia { get; set; }
        public DbSet<RegistroAvanceAcademico> RegistrosAvanceAcademicos { get; set; }

    }
}
