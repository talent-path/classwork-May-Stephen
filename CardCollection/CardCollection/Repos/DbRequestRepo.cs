using CardCollection.Entities;
using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class DbRequestRepo : IRequestRepo
    {

        CardDbContext _context;

        public DbRequestRepo(CardDbContext context)
        {
            _context = context;
        }

        public Request AddRequest(int id, List<Card> req)
        {
            User u = _context.Users.Find(id);
            Request toAdd = new Request();
            toAdd.RequestedCards = req;
            toAdd.trade = _context.AvailableTrades.Where(t => t.user == u).LastOrDefault();
            _context.Requests.Add(toAdd);
            
           
            foreach(Card c in req)
            {
                _context.Cards.Find(c.Id).Requests.Add(toAdd);
            }
            

            
            _context.SaveChanges();

            return toAdd;
        }

        
    }
}
