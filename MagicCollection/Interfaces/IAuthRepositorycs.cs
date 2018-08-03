using MagicCollection.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicCollection.API.Interfaces
{
    public interface IAuthRepository
    {
        Task<CollectionUser> Register(CollectionUser user, string password);

        Task<CollectionUser> Login(string  username, string password);

        Task<bool> UserExists(string username);
    }
}
