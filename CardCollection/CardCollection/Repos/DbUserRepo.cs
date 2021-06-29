using CardCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CardCollection.Repos
{
    public class DbUserRepo : IUserRepo
    {

        
        CardDbContext _context;

        public DbUserRepo(CardDbContext context)
        {
            _context = context;
        }

       

        public int AddUser(User toAdd)
        {
            _context.Users.Add(toAdd);
            _context.SaveChanges();
            return toAdd.Id;
        }

        public User GetUserById(int id)
        {
            User user = _context.Users.Find(id);
            return user;
        }

        public string DeleteUserById(int id)
        {
            User toDelete = _context.Users.Find(id);

            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
            return $"User {id} deleted.";
            
        }

        public int AddToCollection(int id, string cardId)
        {
            User user = _context.Users.Find(id);
            Card card = _context.Cards.Find(cardId);

            user.PersonalCollection.Add(card);
            card.Owners.Add(user);

            _context.SaveChanges();
            return user.Id;
        }

        public List<Card> GetUserCollection(int id)
        {
            User user = _context.Users.Find(id);
            user.PersonalCollection = _context.Cards.Where(c => c.Owners.Contains(user)).ToList();
            return user.PersonalCollection;
        }

        public string RemoveFromCollection(int id, string cardId)
        {
            Card toRemove = _context.Cards.Find(cardId);
            User user = _context.Users.Include(user => user.PersonalCollection).SingleOrDefault(u => u.Id == id);

            user.PersonalCollection.Remove(user.PersonalCollection.Single(c => c.Id == cardId));
            _context.SaveChanges();
            //user.PersonalCollection = _context.Cards.Where(c => c.Owners.Contains(user)).ToList();
            //_context.Attach(toRemove);
            //user.PersonalCollection.Remove(toRemove);

            //toRemove.Owners = _context.Users.Where(o => o.PersonalCollection.Contains(toRemove)).ToList();
            //_context.Attach(user);
            //toRemove.Owners.Remove(user);
            

            return $"Card {cardId} removed.";

        }
    }
}
