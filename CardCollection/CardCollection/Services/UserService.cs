using CardCollection.Entities;
using CardCollection.Helpers;
using CardCollection.Models;
using CardCollection.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
        List<Card> GetUserCollection(int id);
        void AddToCollection(int id, string cardId);
        string RemoveFromCollection(int id, string cardId);
        int GetSetCount(int id, string setId);
    }


    public class UserService : IUserService
    {
        private CardDbContext _context;
        IUserRepo _userRepo;

        public UserService(CardDbContext context)
        {
            _context = context;
            _userRepo = new DbUserRepo(context);
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            //var user = _context.Users.SingleOrDefault(x => x.Username == username);
            User user = _userRepo.Authenticate(username, password);

            
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepo.GetAll();
        }

        public User GetById(int id)
        {
            User user = _userRepo.GetById(id);
            return user;
        }

        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            

            return _userRepo.Create(user, password);
        }

        public void Update(User userParam, string password = null)
        {
            _userRepo.Update(userParam, password);
        }

        public void Delete(int id)
        {
            _userRepo.Delete(id);
        }


        public List<Card> GetUserCollection(int id)
        {
            return _userRepo.GetUserCollection(id);
        }

        public void AddToCollection(int id, string cardId)
        {
            _userRepo.AddToCollection(id, cardId);
        }

        public string RemoveFromCollection(int id, string cardId)
        {
            return _userRepo.RemoveFromCollection(id, cardId);
        }

       

        public int GetSetCount(int id, string setId)
        {
            return _userRepo.GetSetCount(id, setId);
        }







        //internal void AddUser(User toAdd)
        //{
        //    _userRepo.AddUser(toAdd);
        //}

        //internal User GetUserById(int id)
        //{
        //    User user = _userRepo.GetUserById(id);
        //    return user;
        //}

        //internal void DeleteUserById(int id)
        //{
        //    _userRepo.DeleteUserById(id);
        //}


    }
}
