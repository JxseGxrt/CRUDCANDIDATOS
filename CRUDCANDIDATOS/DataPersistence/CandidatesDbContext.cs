using CRUDCANDIDATOS.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CRUDCANDIDATOS.DAL
{
    public class CandidatesDbContext : DbContext
    {
        public CandidatesDbContext()
        {

        }

        public CandidatesDbContext(DbContextOptions<CandidatesDbContext> options):base(options)
        {

        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }

 

        protected override void OnConfiguring(DbContextOptionsBuilder opciones)
        {
            if (!opciones.IsConfigured)
                opciones.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CRUDCANDIDATOS;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}

