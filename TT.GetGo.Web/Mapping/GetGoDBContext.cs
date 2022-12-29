using Microsoft.EntityFrameworkCore;
using TT.GetGo.Core.Domain;

namespace TT.GetGo.Web.Mapping
{
    /// <summary>
    /// Represent the GetGo Database Configuration
    /// </summary>
    public class GetGoDBContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected readonly IConfiguration Configuration;

        public GetGoDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("GetGoConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.CarName).HasMaxLength(300).IsRequired().IsUnicode(true);
                entity.Property(e => e.Brand).HasMaxLength(250).IsRequired().IsUnicode(true);
                entity.Property(e => e.Model).HasMaxLength(500).IsRequired().IsUnicode(true);
                entity.Property(e => e.Color).HasMaxLength(250).IsRequired().IsUnicode(false);
                entity.Property(e => e.NoPlate).HasMaxLength(20).IsRequired().IsUnicode(false);
                entity.Property(e => e.Rate).IsRequired().HasPrecision(18, 6);
                entity.Property(e => e.Status).IsRequired();

                entity.Property(e => e.CreatedBy).IsRequired();
                entity.Property(e => e.CreatedUTCDate).IsRequired();
                entity.Property(e => e.CreatedIP).HasMaxLength(30).IsRequired().IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsRequired();
                entity.Property(e => e.UpdatedUTCDate).IsRequired();
                entity.Property(e => e.UpdatedIP).HasMaxLength(30).IsRequired().IsUnicode(false);
                entity.Property(e => e.Deleted).IsRequired();

                entity.HasData(new Car
                {
                    Id = 1,
                    CarName = "CarA",
                    Brand = "ASTON MARTIN",
                    Model = "Cygnet Hatchback 2013",
                    Color = "Silver",
                    NoPlate = "ABC 1234",
                    Rate = (decimal)1.2,
                    CreatedBy = 1,
                    CreatedUTCDate = DateTime.UtcNow,
                    CreatedIP = "127.0.0.1",
                    UpdatedBy = 1,
                    UpdatedUTCDate = DateTime.UtcNow,
                    UpdatedIP = "127.0.0.1",
                    Deleted = false,
                });

                entity.HasData(new Car
                {
                    Id = 2,
                    CarName = "CarB",
                    Brand = "Audi",
                    Model = "Acura ILX Premium Sedan 2022",
                    Color = "Black",
                    NoPlate = "DEF 8517",
                    Rate = (decimal)1.7,
                    CreatedBy = 1,
                    CreatedUTCDate = DateTime.UtcNow,
                    CreatedIP = "127.0.0.1",
                    UpdatedBy = 1,
                    UpdatedUTCDate = DateTime.UtcNow,
                    UpdatedIP = "127.0.0.1",
                    Deleted = false,
                });

                entity.HasData(new Car
                {
                    Id = 3,
                    CarName = "CarC",
                    Brand = "BMW",
                    Model = "BMW 2 Series Coupe 2022",
                    Color = "Black",
                    NoPlate = "HIJ 1235",
                    Rate = (decimal)1.9,
                    CreatedBy = 1,
                    CreatedUTCDate = DateTime.UtcNow,
                    CreatedIP = "127.0.0.1",
                    UpdatedBy = 1,
                    UpdatedUTCDate = DateTime.UtcNow,
                    UpdatedIP = "127.0.0.1",
                    Deleted = false,
                });


                entity.HasData(new Car
                {
                    Id = 4,
                    CarName = "CarD",
                    Brand = "BMW",
                    Model = "BMW 2 Series M240i Coupe 2022",
                    Color = "Red",
                    NoPlate = "KLM 3435",
                    Rate = (decimal)2.0,
                    CreatedBy = 1,
                    CreatedUTCDate = DateTime.UtcNow,
                    CreatedIP = "127.0.0.1",
                    UpdatedBy = 1,
                    UpdatedUTCDate = DateTime.UtcNow,
                    UpdatedIP = "127.0.0.1",
                    Deleted = false,
                });

                entity.HasData(new Car
                {
                    Id = 5,
                    CarName = "CarF",
                    Brand = "LEXUS",
                    Model = "Lexus IS 300 Sedan 2022",
                    Color = "White",
                    NoPlate = "ZZZ 9999",
                    Rate = (decimal)1.2,
                    CreatedBy = 1,
                    CreatedUTCDate = DateTime.UtcNow,
                    CreatedIP = "127.0.0.1",
                    UpdatedBy = 1,
                    UpdatedUTCDate = DateTime.UtcNow,
                    UpdatedIP = "127.0.0.1",
                    Deleted = false,
                });
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.CarId).IsRequired();
                entity.Property(e => e.GeoX).IsRequired();
                entity.Property(e => e.GeoY).IsRequired();

                entity.Property(e => e.CreatedBy).IsRequired();
                entity.Property(e => e.CreatedUTCDate).IsRequired();
                entity.Property(e => e.CreatedIP).HasMaxLength(30).IsRequired().IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsRequired();
                entity.Property(e => e.UpdatedUTCDate).IsRequired();
                entity.Property(e => e.UpdatedIP).HasMaxLength(30).IsRequired().IsUnicode(false);
                entity.Property(e => e.Deleted).IsRequired();
                entity.HasOne<Car>(e => e.Car).WithMany(w => w.LocationHistory).HasForeignKey(z => z.CarId);
                
                entity.HasData(new Location
                {
                    Id = 1,
                    CarId = 1,
                    GeoX = 2,
                    GeoY = 3,
                    CreatedBy = 1,
                    CreatedUTCDate = DateTime.UtcNow,
                    CreatedIP = "127.0.0.1",
                    UpdatedBy = 1,
                    UpdatedUTCDate = DateTime.UtcNow,
                    UpdatedIP = "127.0.0.1",
                    Deleted = false,
                });

                entity.HasData(new Location
                {
                    Id = 2,
                    CarId = 2,
                    GeoX = 1,
                    GeoY = 2,
                    CreatedBy = 1,
                    CreatedUTCDate = DateTime.UtcNow,
                    CreatedIP = "127.0.0.1",
                    UpdatedBy = 1,
                    UpdatedUTCDate = DateTime.UtcNow,
                    UpdatedIP = "127.0.0.1",
                    Deleted = false,
                });

                entity.HasData(new Location
                {
                    Id = 3,
                    CarId = 3,
                    GeoX = 4,
                    GeoY = 5,
                    CreatedBy = 1,
                    CreatedUTCDate = DateTime.UtcNow,
                    CreatedIP = "127.0.0.1",
                    UpdatedBy = 1,
                    UpdatedUTCDate = DateTime.UtcNow,
                    UpdatedIP = "127.0.0.1",
                    Deleted = false,
                });

                entity.HasData(new Location
                {
                    Id = 4,
                    CarId = 4,
                    GeoX = 5,
                    GeoY = 6,
                    CreatedBy = 1,
                    CreatedUTCDate = DateTime.UtcNow,
                    CreatedIP = "127.0.0.1",
                    UpdatedBy = 1,
                    UpdatedUTCDate = DateTime.UtcNow,
                    UpdatedIP = "127.0.0.1",
                    Deleted = false,
                });

                entity.HasData(new Location
                {
                    Id = 5,
                    CarId = 5,
                    GeoX = 6,
                    GeoY = 7,
                    CreatedBy = 1,
                    CreatedUTCDate = DateTime.UtcNow,
                    CreatedIP = "127.0.0.1",
                    UpdatedBy = 1,
                    UpdatedUTCDate = DateTime.UtcNow,
                    UpdatedIP = "127.0.0.1",
                    Deleted = false,
                });
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("Records");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.CarId).IsRequired();
                entity.Property(e => e.BookDate).IsRequired();
                entity.Property(e => e.GeoX).IsRequired();
                entity.Property(e => e.GeoY).IsRequired();
                entity.Property(e => e.isComplete).IsRequired();
                entity.Property(e => e.Rate).IsRequired().HasPrecision(18, 2);
                entity.Property(e => e.Total).IsRequired().HasPrecision(18, 2);
                entity.Property(e => e.Hour).IsRequired().HasPrecision(18, 2);

                entity.Property(e => e.CreatedBy).IsRequired();
                entity.Property(e => e.CreatedUTCDate).IsRequired();
                entity.Property(e => e.CreatedIP).HasMaxLength(30).IsRequired().IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsRequired();
                entity.Property(e => e.UpdatedUTCDate).IsRequired();
                entity.Property(e => e.UpdatedIP).HasMaxLength(30).IsRequired().IsUnicode(false);
                entity.Property(e => e.Deleted).IsRequired();
                entity.HasOne<Car>(e => e.Car).WithMany(w => w.Records).HasForeignKey(z => z.CarId);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.LogLevelId).IsRequired();
                entity.Property(e => e.ShortMessage).HasMaxLength(3000).IsRequired().IsUnicode(true);
                entity.Property(e => e.FullMessage).IsRequired(false).IsUnicode(true);
                entity.Property(e => e.IpAddress).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.PageUrl).HasMaxLength(3000).IsUnicode(false);
                entity.Property(e => e.ReferrerUrl).HasMaxLength(3000).IsUnicode(false);
                entity.Property(e => e.CreatedUTCDate).IsRequired();
            });
        }
    }
}
