using System;
using DmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DmApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> pOptions) : base(pOptions)
        {

        }

        /// <summary>
        /// Seed database with admin user
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const string password = "admin";

            void createPasswordHash(string pPassword, out byte[] pPasswordHash, out byte[] pPasswordSalt)
            {
                if (pPassword == null)
                    throw new ArgumentNullException(nameof(pPassword));
                if (string.IsNullOrWhiteSpace(pPassword))
                    throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(pPassword));

                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    pPasswordSalt = hmac.Key;
                    pPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pPassword));
                }
            }

            createPasswordHash(password, out var passwordHash, out var passwordSalt);

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Username = "admin",
                FirstName = "Severin",
                LastName = "Fitriyadi",
                Roles = "Admin,Dm,Player",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            });

            modelBuilder.Entity<Spell>().HasData(new Spell()
            {
                Id = 1,
                Name = "Fireball",
                CastingTime = "1 action",
                Duration = "Instantaneous",
                Level = 3,
                School = "evocation",
                Verbal = true,
                Somatic = true,
                Materials = "a tiny ball of bat guano and sulfur",
                Range = 150,
                Description = "A bright streak flashes from your pointing finger to a point you choose within range and then blossoms with a low roar into an explosion of flame. " +
                              "Each creature in a 20-foot-radius sphere centered on that point must make a Dexterity saving throw. " +
                              "A target takes 8d6 fire damage on a failed save, or half as much damage on a successful one. " +
                              "The fire spreads around corners. It ignites flammable objects in the area that aren't being worn or carried. " +
                              "At Higher Levels.When you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd.",
            }, new Spell()
            {
                Id = 2,
                Name = "Fire Bolt",
                CastingTime = "1 action",
                Duration = "Instantaneous",
                Level = 0,
                School = "evocation",
                Verbal = true,
                Somatic = true,
                Materials = string.Empty,
                Range = 120,
                Description = "You hurl a mote of fire at a creature or object within range. " +
                              "Make a ranged spell attack against the target. " +
                              "On a hit, the target takes 1d10 fire damage. " +
                              "A flammable object hit by this spell ignites if it isn't being worn or carried. " +
                              "This spell's damage increases by 1d10 when you reach 5th level (2d10), 11th level (3d10), and 17th level (4d10)."
            });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Spell> Spells { get; set; }
    }
}
