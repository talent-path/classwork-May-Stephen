using CardCollection.Entities;
using CardCollection.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    interface IUserRepo
    {

        //int AddUser(UserModel toAdd);
        //UserModel GetUserById(int id);
        //string DeleteUserById(int id);
        //int AddToCollection(int id, string cardId);
        //List<Card> GetUserCollection(int id);
        //string RemoveFromCollection(int id, string cardId);
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User userParam, string password);
        void Delete(int id);
        List<Card> GetUserCollection(int id);
        int AddToCollection(int id, string cardId);
        string RemoveFromCollection(int id, string cardId);
        int GetSetCount(int id, string setId);
    }
}
