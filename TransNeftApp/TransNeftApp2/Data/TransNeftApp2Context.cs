using Microsoft.EntityFrameworkCore;

namespace TransNeftApp2.Data
{
    public class TransNeftApp2Context : DbContext
    {
        public TransNeftApp2Context (DbContextOptions<TransNeftApp2Context> options)
            : base(options)
        {
        }

        public DbSet<TransNeftEnergo.DTO.IdNumber> IdNumber { get; set; }
    }
}
