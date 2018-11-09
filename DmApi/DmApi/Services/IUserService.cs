using System.Collections.Generic;
using DmApi.Models;

namespace DmApi.Services
{
    public interface IUserService
    {
        User Authenticate(string pUsername, string pPassword);
        IEnumerable<User> GetAll();
        User GetById(int pID);
        User Create(User pUser, string pPassword);
        void Update(User pUser, string pPassword = null);
        void Delete(int pID);
        bool SetRoles(int pId, string pRoles);
    }
}
