using Microsoft.EntityFrameworkCore;
using qualita.WebApi.model;
using qualita.WebApi.repository.Mapeamentos;

namespace qualita.WebApi.repository
{
    public class DbFunc : DbContext
    {
        public DbFunc(DbContextOptions<DbFunc> options) : base(options) { }
        public DbSet<Staff> staffs { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new StaffMap());
        }
    }
}