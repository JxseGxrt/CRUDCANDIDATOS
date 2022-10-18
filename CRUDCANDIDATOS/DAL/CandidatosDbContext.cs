using CRUDCANDIDATOS.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CRUDCANDIDATOS.DAL
{
    public class CandidatosDbContext : DbContext
    {
        public CandidatosDbContext()
        {

        }

        public CandidatosDbContext(DbContextOptions<CandidatosDbContext> options):base(options)
        {

        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<CadidateExperiences> CandidateExperiences { get; set; }

 

        protected override void OnConfiguring(DbContextOptionsBuilder opciones)
        {
            //if (!opciones.IsConfigured)
            //    opciones.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CRUDCANDIDATOS;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}

