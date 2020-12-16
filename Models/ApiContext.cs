using Microsoft.EntityFrameworkCore;

namespace Sample.API.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> opt) : base(opt) { }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialty> Specialties { get; set; }

        //protected override void OnModelCreating(ModelBuilder bld)
        //{   
        //}
    }
}
