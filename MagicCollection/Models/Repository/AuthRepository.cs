using MagicCollection.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicCollection.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicCollection.API.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly MagicCollectionContext _db;

        public AuthRepository(MagicCollectionContext db)
        {
            _db = db;
        }
        
        public async Task<CollectionUser> Login(string username, string password)
        {
            var user = await _db.CollectionUsers.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
                return null;

            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                passwordSalt = hmac.Key;
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<CollectionUser> Register(CollectionUser user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // TODO: need to regen the EF code for Users DbSet()
            await _db.CollectionUsers.AddAsync(user);
            await _db.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _db.CollectionUsers.AnyAsync(x => x.UserName == username))
                return true;

            return false;
        }
    }
}
