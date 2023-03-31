using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace ozka.Data
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options) 
		{ 

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=DESKTOP-1FS4KAI\\SQLEXPRESS; database=citydb; Trusted_Connection=true;TrustServerCertificate=true;");
		}

        public DbSet<City> Cities { get; set; }
    }
}
