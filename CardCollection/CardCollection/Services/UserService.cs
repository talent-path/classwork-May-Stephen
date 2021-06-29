using CardCollection.Models;
using CardCollection.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    public class UserService
    {
        
        IUserRepo _userRepo;

        public UserService(CardDbContext context)
        {
            _userRepo = new DbUserRepo(context);
        }
        internal void AddUser(User toAdd)
        {
            _userRepo.AddUser(toAdd);
        }

        internal User GetUserById(int id)
        {
            User user = _userRepo.GetUserById(id);
            return user;
        }

        internal void DeleteUserById(int id)
        {
            _userRepo.DeleteUserById(id);
        }

        internal List<Card> GetUserCollection(int id)
        {
            return _userRepo.GetUserCollection(id);
        }

        internal void AddToCollection(int id, string cardId)
        {
            _userRepo.AddToCollection(id, cardId);
        }

        internal string RemoveFromCollection(int id, string cardId)
        {
            return _userRepo.RemoveFromCollection(id, cardId);
        }
    }
}
