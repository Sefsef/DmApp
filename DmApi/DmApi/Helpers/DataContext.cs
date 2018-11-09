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

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    FirstName = "Severin",
                    LastName = "Fitriyadi",
                    Roles = "Admin,Dm,Player",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Spell> Spells { get; set; }
    }
}
