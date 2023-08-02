using Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Common.Infra
{
    public class MainContext : DbContext
    {
        protected readonly IConfiguration _Configuration;
        public string? ConnectionString;

        public MainContext(IConfiguration configuration) : base()
        {
            _Configuration = configuration;
            this.ChangeTracker.LazyLoadingEnabled = true;


        }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<City> City { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConnectionString = _Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder
           .UseLazyLoadingProxies(true)
           .EnableSensitiveDataLogging(true)
            .UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Debugger.Launch();
            base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<State>()
                .HasOne<Country>(b => b.Country)
                .WithMany(t => t.StateList)
                .HasForeignKey(f => f.Country_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<District>()
                .HasOne<State>(b => b.State)
                .WithMany(t => t.DistrictList)
                .HasForeignKey(f => f.State_Id)
                .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<City>()
                .HasOne<District>(b => b.District)
                .WithMany(t => t.CityList)
                .HasForeignKey(f => f.District_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
    
}