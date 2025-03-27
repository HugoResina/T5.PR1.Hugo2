using Microsoft.EntityFrameworkCore;
using T5PPR1Hugo2.Model;
using T5PR1Hugo2.Model;

namespace T5PPR1Hugo2.Data
{
    public class ApplicationDbContext : DbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Simulation> Simulations { get; set; }
        public DbSet<Consum> Consums { get; set; }
        public DbSet<Indicador> Indicadors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);


        }
        

    }
}
