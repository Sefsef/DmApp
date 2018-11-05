using Microsoft.EntityFrameworkCore;

namespace DnDApi.Models
{
    public class SpellContext : DbContext
    {
        public SpellContext(DbContextOptions<SpellContext> pOptions) : base(pOptions)
        {

        }

        public DbSet<Spell> Spells { get; set; }
    }
}
