using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Practica.Models;

namespace Practica.Context
{
    public class PracticaDbContxt : DbContext
    {
        public PracticaDbContxt(DbContextOptions<PracticaDbContxt> options) : base(options) { 
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
