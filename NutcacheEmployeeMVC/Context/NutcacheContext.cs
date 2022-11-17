using Microsoft.EntityFrameworkCore;
using NutcacheEmployeeMVC.Models;

namespace NutcacheEmployeeMVC.Context
{
    public class NutcacheContext : DbContext
    {
        public NutcacheContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
