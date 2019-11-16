using Microsoft.EntityFrameworkCore;
using univespApiPI.model;
using univespApiPI.repository.Mapeamentos;

namespace univespApiPI.repository
{
    public class DbFunc : DbContext
    {
        //DbFunc(DbContextOptions options) : base(options) { }
        public DbSet<Staff> staffs { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new StaffMap());
        }
    }
}