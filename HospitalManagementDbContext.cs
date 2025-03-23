using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
    public class HospitalManagementDbContext : DbContext
    {
        public HospitalManagementDbContext(DbContextOptions<HospitalManagementDbContext> options) : base(options)
        {
        }

       
        public DbSet<HospitalRegistration> HospitalRegistrations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PateintInfo> PateintInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HospitalRegistration>().ToTable("HospitalRegistration"); // Explicitly set the table name
        }
       

    }
}
