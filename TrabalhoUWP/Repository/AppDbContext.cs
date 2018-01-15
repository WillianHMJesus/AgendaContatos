using Microsoft.EntityFrameworkCore;
using TrabalhoUWP.Model;

namespace TrabalhoUWP.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TrabalhoUWPBD.db");
        }
    }
}
