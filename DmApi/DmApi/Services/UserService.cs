using System;
using System.Collections.Generic;
using System.Linq;
using DmApi.Extensions;
using DmApi.Helpers;
using DmApi.Models;

namespace DmApi.Services
{
    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext pContext)
        {
            _context = pContext;
        }

        private static void createPasswordHash(string pPassword, out byte[] pPasswordHash, out byte[] pPasswordSalt)
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

        private static bool verifyPasswordHash(string pPassword, byte[] pStoredHash, byte[] pStoredSalt)
        {
            if (pPassword == null)
                throw new ArgumentNullException(nameof(pPassword));
            if (string.IsNullOrWhiteSpace(pPassword))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(pPassword));
            if (pStoredHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", nameof(pStoredHash));
            if (pStoredSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", nameof(pStoredHash));

            using (var hmac = new System.Security.Cryptography.HMACSHA512(pStoredSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pPassword));
                for (var i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != pStoredHash[i]) return false;
            }

            return true;
        }

        public User Authenticate(string pUsername, string pPassword)
        {
            if (string.IsNullOrEmpty(pUsername) || string.IsNullOrEmpty(pPassword))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == pUsername);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!verifyPasswordHash(pPassword, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public User Create(User pUser, string pPassword)
        {
            // validation
            if (string.IsNullOrWhiteSpace(pPassword))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.Username == pUser.Username))
                throw new AppException("Username \"" + pUser.Username + "\" is already taken");

            createPasswordHash(pPassword, out var passwordHash, out var passwordSalt);

            pUser.PasswordHash = passwordHash;
            pUser.PasswordSalt = passwordSalt;
            pUser.Roles = "Player";

            _context.Users.Add(pUser);
            _context.SaveChanges();

            return pUser;
        }

        public void Delete(int pID)
        {
            var user = _context.Users.Find(pID);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int pID)
        {
            return _context.Users.Find(pID);
        }

        public void Update(User pUser, string pPassword = null)
        {
            var user = _context.Users.Find(pUser.Id);

            if (user == null)
                throw new AppException("User not found");

            if (pUser.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (_context.Users.Any(x => x.Username == pUser.Username))
                    throw new AppException("Username " + pUser.Username + " is already taken");
            }

            // update user properties
            user.FirstName = pUser.FirstName;
            user.LastName = pUser.LastName;
            user.Username = pUser.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(pPassword))
            {
                createPasswordHash(pPassword, out var passwordHash, out var passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public bool SetRoles(int pId, string pRoles)
        {
            var user = _context.Users.Find(pId);
            if (user == null)
                return false;

            var userRoles = user.Roles.Split(",");
            foreach (var role in pRoles.Split(","))
            {
                if (role != "Dm" && role != "Player")
                    return false;

                if (!userRoles.Contains(role))
                    userRoles.Append($",{role.Capitalize()}");
            }

            return true;
        }
    }
}
