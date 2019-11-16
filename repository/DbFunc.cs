using Microsoft.EntityFrameworkCore;

namespace univespApiPI.repository
{
    public class DbFunc : DbContext
    {
        DbFunc(DbContextOptions options) : base(options) { }

    }
}