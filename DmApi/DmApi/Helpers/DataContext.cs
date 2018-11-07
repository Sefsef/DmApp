using DmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DmApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> pOptions) : base(pOptions)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Spell> Spells { get; set; }
    }
}
