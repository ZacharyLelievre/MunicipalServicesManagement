using Microsoft.EntityFrameworkCore;

namespace MunicipalServicesManagementApp.Models
{

    public class MunicipalDbContext : DbContext
    {
        public DbSet<WaterSupply> WaterSupplies { get; set; }
        public DbSet<WasteManagement> WasteManagements { get; set; }
        public DbSet<ParkManagement> ParkManagements { get; set; }

        public MunicipalDbContext(DbContextOptions<MunicipalDbContext> options) : base(options) { }
    }
}
