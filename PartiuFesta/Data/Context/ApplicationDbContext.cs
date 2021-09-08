using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PartiuFesta.Models;
using System.Linq;

namespace PartiuFesta.Data.Context {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {


        }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Festa> Festas { get; set; }
        public DbSet<FestaPrivada> FestasPrivadas { get; set; }
        public DbSet<ParticipantePrivado> ParticipantesPrivados { get; set; }


      


    }
}
