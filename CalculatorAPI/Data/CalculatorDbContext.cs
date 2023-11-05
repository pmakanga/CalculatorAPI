using CalculatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculatorAPI.Data
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options)
            : base(options)
        {
        }
        public DbSet<Calculation> Calculations { get; set; }
    }
}
