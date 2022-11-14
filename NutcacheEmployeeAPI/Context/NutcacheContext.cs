using Microsoft.EntityFrameworkCore;
using NutcacheEmployeeAPI.Models;

namespace NutcacheEmployeeAPI.Context
{
    public class NutcacheContext : DbContext
    {
        public NutcacheContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
