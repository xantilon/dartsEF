using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace EFmanymanymany
{
    public partial class DartsContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Player> Players { get; set; }

        public DartsContext()
        {
        }

        public DartsContext(DbContextOptions<DartsContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string cs = ConfigurationManager.ConnectionStrings["DartsDB"].ConnectionString ;//?? "Data Source=(localdb)\\batmanDB;Initial Catalog=darts;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                //optionsBuilder.UseSqlServer(cs);
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\batmanDB;Initial Catalog=darts;User ID=SA;Password=Start123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            //modelBuilder.Entity<Position>()
            //            .HasKey(p => new { p.PlayerId, p.GameId });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
